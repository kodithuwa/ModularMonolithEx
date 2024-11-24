using MediatR;
using Products.Application.Models;
using Products.Application.Queries;
using Products.Application.Repositories;

namespace Products.Application.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository repository;

        public GetProductByIdHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await this.repository.GetByIdAsync(request.Id, cancellationToken));
        }
    }
}
