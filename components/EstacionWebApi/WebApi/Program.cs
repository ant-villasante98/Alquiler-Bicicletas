using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using WebApi.Dependencies;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.DependencyInjections(builder.Configuration);

// Cors
builder
    .Services
    .AddCors(options =>
    {
        options.AddPolicy(
            name: "CorsPolicy",
            builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }
        );
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Reorganizar en una funcion
    if (File.Exists("/.dockerenv") || Directory.Exists("/.docker"))
    {
        app.Urls.Add("http://0.0.0.0:5048");
        Console.WriteLine("-- Ejecutando dentro de Docker --");
    }
    Console.WriteLine($"-- Modo desarrollo --");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    Console.WriteLine($"-- Modo produccion --");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.MapHealthChecks("/hc", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseCors("CorsPolicy");

app.Run();
