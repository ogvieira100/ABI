using AutoMapper;
using DeveloperEvaluation.CartsApi.Application.CreateCarts;
using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;
using DeveloperEvaluation.CartsApi.Application.CreateProducts;
using DeveloperEvaluation.CartsApi.Application.UpdateCartsItens;
using DeveloperEvaluation.CartsApi.Application.UpdateProducts;
using DeveloperEvaluation.CartsApi.Dto;
using DeveloperEvaluation.CartsApi.Models;
using DeveloperEvaluation.CartsApi.Models.Request;
using DeveloperEvaluation.CartsApi.Models.Response;
using DeveloperEvaluation.CartsApi.ValueObjects;
using DeveloperEvaluation.MessageBus.Models.Integration;

namespace DeveloperEvaluation.CartsApi.AutoMapper
{
    public class CartsProfile : Profile
    {
        public CartsProfile()
        {
            //
            CreateMap<CreateCartsRequest, DeleteProductsCommand>();

            //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Descricao))
            CreateMap<Products, UpdateCartsItensUnitPriceCommand>()
                    .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price))
                    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductIdIntegrated))
                    ;
            //UpdateProductsResult
            
            CreateMap<Products, UpdateProductsResult>();
            CreateMap<CreateCardItensDto, CreateCartsItensCommand>();
            CreateMap<DeleteProductsCommand , CreateCartsRequest>();
            CreateMap<CreateCartsItensCommand, CreateCardItensDto>();
            CreateMap<DeleteProductsCommand, Carts>();
            CreateMap<CreateCartsItensCommand, CartsItens>();
            CreateMap<Carts, DeleteProductsResult>();
            CreateMap<DeleteProductsResult, CreateCartsResponse>();
            CreateMap<CartsItens, CreateCartsItensResult>();
            CreateMap<InsertProductsIntegrationEvent, CreateProductsCommand>();
            CreateMap<UpdateProductsIntegrationEvent, UpdateProductsCommand>()
                 .ForPath(dest => dest.Ratting.Rate, opt => opt.MapFrom(src => src.Rate))
                 .ForPath(dest => dest.Ratting.Count, opt => opt.MapFrom(src => src.Count))
                 .AfterMap((src, dest) => dest.Ratting ??= new RattingValueObjects())
                ;

            CreateMap<CreateProductsCommand, Products>()
               .ForMember(dest => dest.ProductIdIntegrated, opt => opt.MapFrom(src => src.Id))
                ;
            CreateMap<Products, CreateProductsResult>();

            //

            


        }
    }
}
