using ImproveByFaz.API.Extensions;
using ImproveByFaz.Infrastructure.Extensions;
using System.Reflection;
using ImproveByFaz.Application.Extensions;
using ImproveByFaz.Infrastructure.Persistence;


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


// Seed database on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DatabaseSeeder.Initialize(services);
}


app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ImproveByFaz API V1");
        c.RoutePrefix = string.Empty; // Makes Swagger available at root URL
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
