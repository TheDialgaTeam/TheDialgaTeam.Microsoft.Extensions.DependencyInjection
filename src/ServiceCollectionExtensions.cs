using System;
using Microsoft.Extensions.DependencyInjection;

namespace TheDialgaTeam.Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class containing Service Collection extension functions.
    /// </summary>
    public static class ServiceCollectionExtensions
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

        public static IServiceCollection AddInterfacesAndSelfAsSingleton<TService>(this IServiceCollection serviceCollection, TService implementationInstance) where TService : class
        {
            if (serviceCollection == null)
                throw new ArgumentNullException(nameof(serviceCollection));

            if (implementationInstance == null)
                throw new ArgumentNullException(nameof(implementationInstance));

            serviceCollection.AddSingleton(implementationInstance);

            foreach (var type in typeof(TService).GetInterfaces())
                serviceCollection.AddSingleton(type, a => a.GetService<TService>());

            return serviceCollection;
        }
    }
}