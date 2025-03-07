﻿

using DeveloperEvaluation.ProductsApi.ValueObjects;
using MediatR;

namespace DeveloperEvaluation.ProductsApi.Application.CreateProducts
{
    public class CreateProductsCommand : IRequest<CreateProductsResult>
    {
        public string Title { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

        public RattingValueObjects Ratting { get; set; }

    
    }
}
