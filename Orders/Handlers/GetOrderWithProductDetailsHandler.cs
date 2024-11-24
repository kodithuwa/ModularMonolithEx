

using MediatR;
using Orders.Queries;
using Products.Application.Queries;

namespace Orders.Handlers
{
    public class GetOrderWithProductDetailsHandler : IRequestHandler<GetOrderWithProductDetailsQuery, OrderDetails>
    {

        private readonly IMediator _mediator;

        public GetOrderWithProductDetailsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OrderDetails> Handle(GetOrderWithProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(request.ProductId), cancellationToken);
            if (product == null)
                throw new Exception("Product not found");

            // Fetch order details (mocked for simplicity)
            return new OrderDetails
            {
                OrderId = request.OrderId,
                Product = product,
                Quantity = 2
            };
        }
    }
}
