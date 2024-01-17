using WebApi.Dependencies;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ApplicationDependencyInjection(builder.Configuration);
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Reorganizar en una funcion
    if (File.Exists("/.dockerenv") || Directory.Exists("/.docker"))
    {
        app.Urls.Add("http://0.0.0.0:5053");
        Console.WriteLine("-- Ejecutando dentro de Docker --");
    }
    Console.WriteLine($"-- Modo desarrollo --");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<MiddlewareException>();

app.UseAuthorization();

app.MapControllers();

app.Run();
