

namespace Common
{
    using System.ComponentModel;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Microsoft.Extensions.DependencyInjection;

    public static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositoriesFromAssembly(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            var typeList = new List<Type>();
            if(assemblies == null || !assemblies.Any())
            {
                return services;
            }

            assemblies.ToList().ForEach(assembly =>
            {
                var types = assembly.GetTypes().ToList();
                typeList.AddRange(types);
            });

            if (!typeList.Any())
            {
                return services;
            }

            // Find all classes implementing IRepository<> or IRepository
            var repositoryTypes = GetAssemblyTypes<IRepository>(typeList);

            // Find all classes implementing IRepository<> or IRepository
            var serviceTypes = GetAssemblyTypes<IService>(typeList);


            foreach (var repositoryType in repositoryTypes)
            {
                //var implementedInterfaces = repositoryType.GetInterfaces()
                //    //.Where(i => i.IsAssignableFrom(repositoryType) &&
                //    //    //i.IsGenericType && //i.GetGenericTypeDefinition() == typeof(IRepository<>) || // Generic IRepository<>
                //    //    i != typeof(IRepository))
                //    .Where(i =>
                //    {
                //        var interfaces = i.GetInterfaces();
                //        return interfaces.Any(i => i.Name == "I" + i.Name + "Repository");

                //    }); // Marker interface IRepository


                //foreach (var implementedInterface in implementedInterfaces)
                //{
                var repoInterface = repositoryType.GetInterface($"I{repositoryType.Name}");
                services.AddScoped(repoInterface, repositoryType);
            }

            foreach (var serviceType in serviceTypes)
            {
                //var implementedInterfaces = repositoryType.GetInterfaces()
                //    //.Where(i => i.IsAssignableFrom(repositoryType) &&
                //    //    //i.IsGenericType && //i.GetGenericTypeDefinition() == typeof(IRepository<>) || // Generic IRepository<>
                //    //    i != typeof(IRepository))
                //    .Where(i =>
                //    {
                //        var interfaces = i.GetInterfaces();
                //        return interfaces.Any(i => i.Name == "I" + i.Name + "Repository");

                //    }); // Marker interface IRepository


                //foreach (var implementedInterface in implementedInterfaces)
                //{
                var serviceInterface = serviceType.GetInterface($"I{serviceType.Name}");
                services.AddScoped(serviceInterface, serviceType);
            }

            return services;
        }

        public static IEnumerable<Type> GetAssemblyTypes<T>(List<Type> typeList) 
        {
            var serviceTypes = typeList
               .Where(t => t.IsClass && !t.IsAbstract) // Only concrete classes
               .Where(t => t.GetInterfaces().Any(i =>
                   //i.IsGenericType && //i.GetGenericTypeDefinition() == typeof(IRepository<>) ||  Generic IRepository<>
                   i == typeof(T)))
                .Where(i =>
                {
                    var interfaces = i.GetInterfaces();
                    return interfaces.Any(x => x.Name == "I" + i.Name); //

                });
            return serviceTypes;
        }
    }
}
