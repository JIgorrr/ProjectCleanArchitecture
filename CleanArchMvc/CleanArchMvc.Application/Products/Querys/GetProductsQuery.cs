using CleanArchMvc.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArchMvc.Application.Products.Querys
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
