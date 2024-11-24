

namespace Common
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    public static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositoriesFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            // Find all classes implementing IRepository<> or IRepository
            var repositoryTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract) // Only concrete classes
                .Where(t => t.GetInterfaces().Any(i =>
                    //i.IsGenericType && //i.GetGenericTypeDefinition() == typeof(IRepository<>) ||  Generic IRepository<>
                    i == typeof(IRepository))); // Marker interface IRepository

            foreach (var repositoryType in repositoryTypes)
            {
                var implementedInterfaces = repositoryType.GetInterfaces()
                    .Where(i => i.IsAssignableFrom(repositoryType) &&
                        //i.IsGenericType && //i.GetGenericTypeDefinition() == typeof(IRepository<>) || // Generic IRepository<>
                        i != typeof(IRepository)); // Marker interface IRepository

                foreach (var implementedInterface in implementedInterfaces)
                {
                    services.AddScoped(implementedInterface, repositoryType);
                }
            }

            return services;
        }
    }
}
