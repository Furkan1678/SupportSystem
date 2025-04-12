using Microsoft.AspNetCore.Hosting;
using SupportRequestManagement.Presentation;
using SupportRequestManagement.Presentation.WebApi.Startup;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices(builder.Configuration);
var app = builder.Build();

var startup = new Startup(builder.Configuration);
startup.Configure(app, app.Environment);

app.Run();

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var startup = new Startup(configuration);
        startup.ConfigureServices(services);
        return services;
    }
}