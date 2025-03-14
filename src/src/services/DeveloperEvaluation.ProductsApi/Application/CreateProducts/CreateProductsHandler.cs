﻿using AutoMapper;
using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.MessageBus.Interface;
using DeveloperEvaluation.MessageBus.Models.Integration;
using DeveloperEvaluation.ProductsApi.Models;
using FluentValidation;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DeveloperEvaluation.ProductsApi.Application.CreateProducts
{
    public class CreateProductsHandler : IRequestHandler<CreateProductsCommand, CreateProductsResult>
    {
        readonly IBaseRepository<Products> _productsRepository;
        readonly IMapper _mapper;
        readonly IMediator _mediator;

        public CreateProductsHandler(IBaseRepository<Products> productsRepository,
                    IMapper mapper,
                    IMediator mediator  )
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<CreateProductsResult> Handle(CreateProductsCommand command,
                                                        CancellationToken cancellationToken)
        {
            var validator = new CreateProductsValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var productTitle = await _productsRepository.RepositoryConsult.SearchAsync(x => x.Title == command.Title, cancellationToken);
            if (productTitle != null && productTitle.Any())
                throw new InvalidOperationException($"Produto com o titulo {command.Title} já existe");


            var productAdd = _mapper.Map<Products>(command);
            await _productsRepository.AddAsync(productAdd);
            await _productsRepository.UnitOfWork.CommitAsync();

            var insertProductsIntegrationEvent = _mapper.Map<InsertProductsIntegrationEvent>(productAdd);

            await _mediator.Publish(insertProductsIntegrationEvent);

            var result = _mapper.Map<CreateProductsResult>(productAdd);
            return result;
        }
    }
}
