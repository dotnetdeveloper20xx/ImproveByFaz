using ImproveByFaz.API.Extensions;
using ImproveByFaz.Infrastructure.Extensions;
using System.Reflection;
using ImproveByFaz.Application.Extensions;
using ImproveByFaz.Infrastructure.Persistence;
using ImproveByFaz.API.Middlewares;


var builder = WebApplication.CreateBuilder(args);

// Register Services from Different Layers
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddApiServices();


// Add MediatR manually
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.Load("ImproveByFaz.Application")
));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

//// Enable Middleware for Response Caching
//app.UseResponseCaching();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ImproveByFaz API V1");
        options.RoutePrefix = string.Empty; // Loads Swagger UI at root URL (`http://localhost:5000/`)
    });
}


// Seed database on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DatabaseSeeder.Initialize(services);
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program { } // This makes 'Program' accessible in tests
