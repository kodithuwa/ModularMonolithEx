using Products.Application.Models;

namespace Orders.Handlers
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}