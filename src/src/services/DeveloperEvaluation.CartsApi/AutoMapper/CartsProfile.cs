using AutoMapper;
using DeveloperEvaluation.CartsApi.Application.CreateCarts;
using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;
using DeveloperEvaluation.CartsApi.Application.CreateProducts;
using DeveloperEvaluation.CartsApi.Dto;
using DeveloperEvaluation.CartsApi.Models;
using DeveloperEvaluation.CartsApi.Models.Request;
using DeveloperEvaluation.CartsApi.Models.Response;
using DeveloperEvaluation.MessageBus.Models.Integration;

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
            CreateMap<InsertProductsIntegrationEvent, CreateProductsCommand>();
            CreateMap<CreateProductsCommand, Products>();
            CreateMap<Products, CreateProductsResult>();

            //

            


        }
    }
}
