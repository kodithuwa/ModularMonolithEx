namespace Orders.Commands
{
    using MediatR;
    using Orders.Application;
    using Orders.Domain;

    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _repository;

        public CreateOrderHandler(IOrderRepository repository) => _repository = repository;

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerName = request.CustomerName,
                OrderDate = DateTime.UtcNow,
                Items = request.Items
            };

            await _repository.CreateOrderAsync(order);
            return order.Id;
        }
    }

}
