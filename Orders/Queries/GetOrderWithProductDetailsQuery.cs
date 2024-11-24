using MediatR;
using Orders.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Queries
{
public record GetOrderWithProductDetailsQuery(int OrderId, int ProductId) : IRequest<OrderDetails>;
}
