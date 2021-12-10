using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Web;
using Sapphire.Common;
using Sapphire.Extensions;
using Sapphire.Tasks;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");


try
{

    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services
        .AddSingleton<IServiceCollection, ServiceCollection>();

    #region IOC ≥ı ºªØ◊¢≤·“¿¿µ◊¢»ÎInterface ∫Õ class Service
    string assemblyName = "Sapphire.Service";
    Assembly assembly = Assembly.Load(assemblyName);
    List<Type> ts = assembly.GetTypes().Where(u => u.IsClass && !u.IsAbstract && !u.IsGenericType).ToList();
    foreach (var item in ts.Where(s => !s.IsInterface))
    {
        var interfaceType = item.GetInterfaces();
        if (interfaceType.Length == 1)
        {

            builder.Services
                .AddTransient(interfaceType[0], item);
        }
        if (interfaceType.Length > 1)
        {
            builder.Services.AddTransient(interfaceType[1], item);
        }
    }
    #endregion


    builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddSingleton<ITaskSchedulingService, TaskSchedulingService>();

    #region Auth01
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/sapphireadmin/login");
    })
    .AddCookie(BbsUserAuthorizeAttribute.BbsUserAuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/bbs/nologin");
    })
    .AddJwtBearer(JwtAuthorizeAttribute.JwtAuthenticationScheme, o =>
    {
        var jwtConfig = new JwtAuthConfigModel();
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30),
            ValidAudience = jwtConfig.Audience,
            ValidIssuer = jwtConfig.Issuer,
            RequireExpirationTime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtAuth:SecurityKey"]))
        };
        o.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("Token-Expired", "true");
                }
                return Task.CompletedTask;
            }
        };
    });
    #endregion

    #region Auth02
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("App", policy => policy.RequireRole("App").Build());
        options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
        options.AddPolicy("AdminOrApp", policy => policy.RequireRole("Admin,App").Build());
    });
    #endregion

    #region Cache
    builder.Services.AddMemoryCache();
    builder.Services.AddSingleton<ICacheService, MemoryCacheService>();
    //RedisHelper.Initialization(new CSRedis.CSRedisClient(builder.Configuration["Cache:Configuration"]));
    #endregion

    //builder.Services.AddMvc().AddJsonOptions(option =>
    //{
    //    option.JsonSerializerOptions. = "yyyy-MM-dd HH:mm:ss";
    //});
    #region CORS
    builder.Services.AddCors(c =>
    {
        c.AddPolicy("Any", policy =>
        {
            policy.WithMethods("GET","POST","HEAD","PUT","DELETE","OPTIONS").AllowAnyOrigin()
            ;
        });

        c.AddPolicy("Limit", policy =>
        {
            policy
            .WithOrigins("localhost:4909")
            .WithMethods("get", "post", "put", "delete")
            //.WithHeaders("Authorization");
            .AllowAnyHeader();
        });
    });
    #endregion

    #region 
    builder.Services.AddResponseCompression();
    #endregion




    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    else
    {
        app.UseDeveloperExceptionPage();
    }
    app.UseStatusCodePagesWithReExecute("/Error");

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapRazorPages();

    #region «®“∆¥˙¬Î




    #region  UseForwardedHeaders
    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });
    #endregion

    #region Nlog
    NLog.LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
    NLog.LogManager.Configuration.Variables["connectionString"] = app.Configuration["DBConnection:MySqlConnectionString"];
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    #endregion

    var cbuilder = new ConfigurationBuilder()
                   .SetBasePath(app.Environment.ContentRootPath)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    var configuration = cbuilder.Build();
    Sapphire.Extensions.BaseConfigModel.SetBaseConfig(configuration, app.Environment.ContentRootPath, app.Environment.WebRootPath);

    //TaskScheduling redis
    //TaskSchedulingService.Instance.InitStart();

    app.UseResponseCompression();
    app.UseCookiePolicy();
    app.UseCors("Any");
    //app.UseMvc();


    #endregion

    app.Run();
}
catch (Exception ex)
{
    // NLog: catch setup errors
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
