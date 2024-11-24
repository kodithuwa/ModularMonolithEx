using MediatR;
using Products.Application.Models;
using Products.Application.Queries;
using Products.Application.Repositories;

namespace Products.Application.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdHandler()
        {
            
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult( new Product { Id = 2, Name = "Smartphone", Price = 800 });
        }
    }
}
