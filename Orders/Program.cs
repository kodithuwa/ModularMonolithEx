
namespace Orders
{
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                   .AddMediatR(r => r.RegisterServicesFromAssemblies(typeof(Program).Assembly))
               .BuildServiceProvider();

            var mediator = serviceProvider.GetRequiredService<IMediator>();
            //var helloCommand = new HelloCommand { Name = "World" };

            //var result = await mediator.Send(helloCommand);

            //Console.WriteLine(result);

            //Console.ReadLine();
        }

        private static void BuildServiceProvider()
        {
            throw new NotImplementedException();
        }
    }
}