var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//¿çÓòÉèÖÃ
builder.Services.AddCors();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyAll", policy =>
    {
        policy.WithMethods("GET", "POST", "HEAD", "PUT", "DELETE", "OPTIONS").AllowAnyOrigin()
        ;
    });
});
builder.Services.AddRouting();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AnyAll");
app.UseRouting();


app.Run();
