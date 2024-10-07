using ClubFitnessInfrastructure;
using ClubFitnessInfrastructure.Interfaces;
using System.Reflection;

namespace ClubFitnessSolution
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAllRepositoriesFromAssemblies(this IServiceCollection services, params Assembly[] assemblies)
        {
            // Or use scoped/singleton as needed
            //ServiceLifetime.Transient
            //ServiceLifetime.Scoped
            //ServiceLifetime.Singleton

            foreach (var assembly in assemblies)
            {
                // Find all types that are interfaces and their implementations
                var serviceTypes = assembly.GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract)
                    .SelectMany(t => t.GetInterfaces(), (impl, service) => new { Service = service, Implementation = impl })
                    .Where(x => x.Service.Name == "I" + x.Implementation.Name &&
                                x.Service.FullName != null && x.Service.FullName.EndsWith("Repository"))
                    .ToList();

                // Register each service with the specified lifetime
                foreach (var serviceType in serviceTypes)
                    services.Add(new ServiceDescriptor(serviceType.Service, serviceType.Implementation, ServiceLifetime.Scoped));

            }

            return services;
        }

        public static IServiceCollection AddAllServicesFromAssemblies(this IServiceCollection services, params Assembly[] assemblies)
        {
            // Or use scoped/singleton as needed
            //ServiceLifetime.Transient
            //ServiceLifetime.Scoped
            //ServiceLifetime.Singleton

            foreach (var assembly in assemblies)
            {
                // Find all types that are interfaces and their implementations
                var serviceTypes = assembly.GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract)
                    .SelectMany(t => t.GetInterfaces(), (impl, service) => new { Service = service, Implementation = impl })
                    .Where(x => x.Service.Name == "I" + x.Implementation.Name &&
                                x.Service.FullName != null && x.Service.FullName.EndsWith("Service"))
                    .ToList();

                // Register each service with the specified lifetime
                foreach (var serviceType in serviceTypes)
                    services.Add(new ServiceDescriptor(serviceType.Service, serviceType.Implementation, ServiceLifetime.Transient));

            }

            return services;
        }
    }
}
