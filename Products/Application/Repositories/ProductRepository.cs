using Products.Application.Models;

namespace Products.Application.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 1200 },
        new Product { Id = 2, Name = "Smartphone", Price = 800 },
    };

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }
    }
}
