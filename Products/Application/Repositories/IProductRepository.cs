using Common;
using Products.Application.Models;

namespace Products.Application.Repositories
{
    public interface IProductRepository:IRepository
    {
        Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
