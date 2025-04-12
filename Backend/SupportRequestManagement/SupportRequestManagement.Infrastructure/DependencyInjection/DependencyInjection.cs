using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SupportRequestManagement.Domain.Interfaces;
using SupportRequestManagement.Infrastructure.Data; // Repository'ler için
using SupportRequestManagement.Infrastructure.Services; // Servisler için
using System.Data;

namespace SupportRequestManagement.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // PostgreSQL bağlantısı
            services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")));

            // Repository'ler gelecek
         

            // Servisler gelecek 
        

            return services;
        }
    }
}