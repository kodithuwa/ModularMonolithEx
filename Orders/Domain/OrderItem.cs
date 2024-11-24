namespace Orders.Domain
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } = 0;
    }
}