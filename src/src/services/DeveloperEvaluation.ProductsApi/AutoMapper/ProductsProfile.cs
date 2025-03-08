﻿using AutoMapper;
using DeveloperEvaluation.Core.Security;
using DeveloperEvaluation.ProductsApi.Application.CreateProducts;
using DeveloperEvaluation.ProductsApi.Application.DeleteProducts;
using DeveloperEvaluation.ProductsApi.Dto;
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
            CreateMap<Products, GetProductResponse>();

            CreateMap<DeleteProductRequest, DeleteProductsCommand>();
            //DeleteProductRequest
            CreateMap<CreateProductsResult, CreateProductResponse>();
            CreateMap<CreateProductsCommand, Products>();
            CreateMap<Products, CreateProductsResult>();
            CreateMap<ProductsSearchDto, Products>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Imagem))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Valor))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Categoria))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Titulo))

                .ForPath(dest => dest.Ratting.Rate, opt => opt.MapFrom(src => src.Rate))
                .ForPath(dest => dest.Ratting.Count, opt => opt.MapFrom(src => src.Contador))
                .AfterMap((src, dest) => dest.Ratting ??= new RattingValueObjects())
                ;
            
            CreateMap<CreateProductRequest, CreateProductsCommand>()
                .ForPath(dest => dest.Ratting.Rate, opt => opt.MapFrom(src => src.Rate))
                .ForPath(dest => dest.Ratting.Count, opt => opt.MapFrom(src => src.Count))
                .AfterMap((src, dest) => dest.Ratting ??= new RattingValueObjects())
                ;
        }

    }
}
