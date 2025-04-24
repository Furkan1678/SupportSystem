using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SupportRequestManagement.Domain.Interfaces;


namespace SupportRequestManagement.Core.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddAutoMapper(typeof(Mapping.MappingProfile));
            return services;
        }
    }
}