using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Querys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);

            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO > GetByIdAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value) 
                ?? throw new Exception("Entity could not be loaded");

            var product = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value)
               ?? throw new Exception("Entity could not be loaded");

            var product = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery() 
                ?? throw new Exception("Entity could not be loaded");

            var product = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(product);
        }

        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value)
                ?? throw new Exception("Entity could not be loaded");

            await _mediator.Send(productRemoveCommand);   
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var productUpdaterCommand = _mapper.Map<ProductUpdateCommand>(productDTO);

            await _mediator.Send(productUpdaterCommand);
        }
    }
}
