using Orders.Domain;

namespace Orders
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(Guid id);
        Task CreateOrderAsync(Order order);
    }
}