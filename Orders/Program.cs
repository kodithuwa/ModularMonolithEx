
namespace Orders
{
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Orders.Domain;
    using Orders.Handlers;
    using Orders.Queries;
    using Products.Application.Handlers;
    using Products.Application.Models;
    using Products.Application.Repositories;
    using System;
    using System.Reflection;
    using Common;

    public class Program
    {
        private async static Task Main(string[] args)
        {
            var services = new ServiceCollection();
                   

            services.AddRepositoriesFromAssembly(typeof(Products.Program).Assembly);

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

        private static void BuildServiceProvider()
        {
            throw new NotImplementedException();
        }
    }
}