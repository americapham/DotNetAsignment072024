using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Bosch.Events.UseCases
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
