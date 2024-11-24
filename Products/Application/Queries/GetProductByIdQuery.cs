using MediatR;
using Products.Application.Models;

namespace Products.Application.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
