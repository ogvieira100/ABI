using AutoMapper;
using DeveloperEvaluation.Core.Security;
using DeveloperEvaluation.ProductsApi.Application.CreateProducts;
using DeveloperEvaluation.ProductsApi.Models;
using DeveloperEvaluation.ProductsApi.Models.Request;
using DeveloperEvaluation.ProductsApi.Models.Response;
using DeveloperEvaluation.ProductsApi.ValueObjects;

namespace DeveloperEvaluation.ProductsApi.AutoMapper
{
    public class ProductsProfile:Profile
    {

        public ProductsProfile()
        {
            //
            CreateMap<CreateProductsResult, CreateProductResponse>();
            CreateMap<CreateProductsCommand, Products>();
            CreateMap<Products, CreateProductsResult>();
            CreateMap<CreateProductRequest, CreateProductsCommand>()
                .ForPath(dest => dest.Ratting.Rate, opt => opt.MapFrom(src => src.Rate))
                .ForPath(dest => dest.Ratting.Count, opt => opt.MapFrom(src => src.Count))
                .AfterMap((src, dest) => dest.Ratting ??= new RattingValueObjects())
                
                
                ;
        }

    }
}
