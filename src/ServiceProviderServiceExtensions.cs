using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace TheDialgaTeam.Microsoft.Extensions.DependencyInjection
{
    public static class ServiceProviderServiceExtensions
    {
        public static void InitializeServices(this IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IInitializable>();

            foreach (var service in services)
                service.Initialize();
        }

        public static void DisposeServices(this IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDisposable>();

            foreach (var service in services.Reverse())
                service.Dispose();
        }
    }
}