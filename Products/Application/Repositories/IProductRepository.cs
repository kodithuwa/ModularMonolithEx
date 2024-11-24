using Products.Application.Models;

namespace Products.Application.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
