using Microsoft.Extensions.DependencyInjection;

namespace Application.RestClients
{
    public static class RestClientsInstaller
    {
        public static IServiceCollection AddRestServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IUserServiceClient), typeof(UserServiceClient));
            return services;
        }
    }
}