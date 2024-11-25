
namespace Orders
{
    using Common;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Orders.Queries;
    using System.Reflection;

    public class Program
    {
        private async static Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddRepositoriesFromAssembly(new List<Assembly>{ typeof(Products.Program).Assembly, typeof(Program).Assembly});

            var serviceProvider  = services
            .AddMediatR(r => r.RegisterServicesFromAssemblies(typeof(Products.Program).Assembly))
                   .AddMediatR(r => r.RegisterServicesFromAssemblies(typeof(Orders.Program).Assembly))
               .BuildServiceProvider();
            var mediator = serviceProvider.GetRequiredService<IMediator>();
            var orderDetails = await mediator.Send(new GetOrderWithProductDetailsQuery(1, 1));
            var result = orderDetails;

            //Console.WriteLine(result);

            //Console.ReadLine();
        }
    }
}