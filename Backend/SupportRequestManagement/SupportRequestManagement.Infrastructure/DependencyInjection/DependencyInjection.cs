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

            // Repository'ler Geldi!!!
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISupportRequestRepository, SupportRequestRepository>();
            services.AddScoped<ISupportCategoryRepository, SupportCategoryRepository>();
            services.AddScoped<ISupportTypeRepository, SupportTypeRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<ISupportRequestCommentRepository, SupportRequestCommentRepository>();

            // Servisler Geeeldiiii
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<ILoggingService, LoggingService>(); // Bu satırı ekledik

            return services;
        }
    }
}