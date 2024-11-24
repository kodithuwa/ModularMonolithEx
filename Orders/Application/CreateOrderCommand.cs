using MediatR;
using Orders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application
{
    public record CreateOrderCommand(string CustomerName, List<OrderItem> Items): IRequest<Guid>;
}
