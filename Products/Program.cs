

namespace Products
{
    using Products.Application.Handlers;
    using Products.Application.Repositories;
    using System.Runtime.CompilerServices;
    using Common;

    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddMediatR(r =>
            {
                r.RegisterServicesFromAssemblies(typeof(Program).Assembly);
            });
            

            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllers();
            app.Run();
        }
    }
}