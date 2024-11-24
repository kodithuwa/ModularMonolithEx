using MediatR;

public record GetOrderByWithProductQuery(string orderId) : IRequest<OrderResponse>;