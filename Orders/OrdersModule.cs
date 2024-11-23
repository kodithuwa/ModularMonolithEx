using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    public static class OrdersModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddMediatR( r => r.RegisterServicesFromAssemblies(typeof(OrdersModule).Assembly));
        }
    }
}
