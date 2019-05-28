using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace TheDialgaTeam.Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Class containing Service Provider extension functions.
    /// </summary>
    public static class ServiceProviderExtensions
    {
        public static void InitializeServices(this IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IInitializable>();

            foreach (var service in services)
                service.Initialize();
        }

        public static void LateInitializeServices(this IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<ILateInitializable>();

            foreach (var service in services)
                service.LateInitialize();
        }

        public static void DisposeServices(this IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDisposable>();

            foreach (var service in services.Reverse())
                service.Dispose();
        }
    }
}