using AutoMapper;
using DeveloperEvaluation.CartsApi.Application.CreateCarts;
using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;
using DeveloperEvaluation.CartsApi.Dto;
using DeveloperEvaluation.CartsApi.Models;
using DeveloperEvaluation.CartsApi.Models.Request;
using DeveloperEvaluation.CartsApi.Models.Response;

namespace DeveloperEvaluation.CartsApi.AutoMapper
{
    public class CartsProfile : Profile
    {
        public CartsProfile()
        {
            CreateMap<CreateCartsRequest, CreateCartsCommand>();
            CreateMap<CreateCardItensDto, CreateCartsItensCommand>();
            CreateMap<CreateCartsCommand , CreateCartsRequest>();
            CreateMap<CreateCartsItensCommand, CreateCardItensDto>();
            CreateMap<CreateCartsCommand, Carts>();
            CreateMap<CreateCartsItensCommand, CartsItens>();
            CreateMap<Carts, CreateCartsResult>();
            CreateMap<CreateCartsResult, CreateCartsResponse>();
            CreateMap<CartsItens, CreateCartsItensResult>();

            //CreateMap<DeleteProductRequest, DeleteProductsCommand>();
            ////DeleteProductRequest
            //CreateMap<CreateProductsResult, CreateProductResponse>();
            //CreateMap<CreateProductsCommand, Products>();
            //CreateMap<Products, CreateProductsResult>();
            //CreateMap<ProductsSearchDto, Products>()
            //    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Imagem))
            //    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Descricao))
            //    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Valor))
            //    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Categoria))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Titulo))

            //    .ForPath(dest => dest.Ratting.Rate, opt => opt.MapFrom(src => src.Rate))
            //    .ForPath(dest => dest.Ratting.Count, opt => opt.MapFrom(src => src.Contador))
            //    .AfterMap((src, dest) => dest.Ratting ??= new RattingValueObjects())
            //    ;

            //CreateMap<CreateProductRequest, CreateProductsCommand>()
            //    .ForPath(dest => dest.Ratting.Rate, opt => opt.MapFrom(src => src.Rate))
            //    .ForPath(dest => dest.Ratting.Count, opt => opt.MapFrom(src => src.Count))
            //    .AfterMap((src, dest) => dest.Ratting ??= new RattingValueObjects())
            //    ;
        }
    }
}
