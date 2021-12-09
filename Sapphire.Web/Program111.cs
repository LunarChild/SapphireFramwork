//using Microsoft.AspNetCore.HttpOverrides;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
//else
//{
//    app.UseDeveloperExceptionPage();
//}
//app.UseStatusCodePagesWithReExecute("/Error");

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

//#region Ç¨ÒÆ´úÂë

//#region  UseForwardedHeaders
//app.UseForwardedHeaders(new ForwardedHeadersOptions
//{
//    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
//});
//#endregion

//#region Nlog
//NLog.LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
//NLog.LogManager.Configuration.Variables["connectionString"] = Configuration["DBConnection:MySqlConnectionString"];
//Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
//#endregion

//var cbuilder = new ConfigurationBuilder()
//               .SetBasePath(app.Environment.ContentRootPath)
//               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
//var configuration = cbuilder.Build();
//Sapphire.Extensions.BaseConfigModel.SetBaseConfig(configuration, app.Environment.ContentRootPath, app.Environment.WebRootPath);




//#endregion

//app.Run();
