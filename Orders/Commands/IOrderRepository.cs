using Orders.Domain;

namespace Orders
{
    using Common;
    public interface IOrderRepository : IRepository
    {
        Task<Order> GetOrderByIdAsync(Guid id);
        Task CreateOrderAsync(Order order);
    }
}