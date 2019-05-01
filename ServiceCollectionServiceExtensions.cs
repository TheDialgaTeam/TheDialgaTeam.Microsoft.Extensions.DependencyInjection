using System;
using Microsoft.Extensions.DependencyInjection;

namespace TheDialgaTeam.Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionServiceExtensions
    {
        public static IServiceCollection AddInterfacesAndSelfAsSingleton<TService>(this IServiceCollection serviceCollection) where TService : class
        {
            if (serviceCollection == null)
                throw new ArgumentNullException(nameof(serviceCollection));

            serviceCollection.AddSingleton<TService>();

            foreach (var type in typeof(TService).GetInterfaces())
                serviceCollection.AddSingleton(type, a => a.GetService<TService>());

            return serviceCollection;
        }
    }
}