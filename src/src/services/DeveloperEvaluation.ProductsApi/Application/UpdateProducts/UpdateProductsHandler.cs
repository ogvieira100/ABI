using AutoMapper;
using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.MessageBus.Models.Integration;
using DeveloperEvaluation.ProductsApi.Models;
using FluentValidation;
using MediatR;
using Npgsql;

namespace DeveloperEvaluation.ProductsApi.Application.UpdateProducts
{
    public class UpdateProductsHandler : IRequestHandler<UpdateProductsCommand, UpdateProductsResult>
    {
        readonly IBaseRepository<Products> _productsRepository;
        readonly IMapper _mapper;
        readonly IMediator _mediator;

        public UpdateProductsHandler(IBaseRepository<Products> productsRepository,
                    IMapper mapper,
                    IMediator mediator)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<UpdateProductsResult> Handle(UpdateProductsCommand command,
                                                        CancellationToken cancellationToken)
        {
            var validator = new UpdateProductsValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var productTitle = await _productsRepository.RepositoryConsult.SearchAsync(x => x.Title == command.Title && x.Id != command.Id, cancellationToken);
            if (productTitle != null && productTitle.Any())
                throw new InvalidOperationException($"Produto com o titulo {command.Title} já existe");


            var product = (await _productsRepository.RepositoryConsult.SearchAsync(x => x.Id == command.Id,cancellationToken))?.FirstOrDefault();
            if (product == null)
                throw new InvalidOperationException($"Produto não encontrado!");

            product.Description = command.Description;
            product.Price = command.Price ?? 0;
            product.Title = command.Title;
            product.Category = command.Category;
            product.Image = command.Image;
            if (command.Ratting != null)
            {
                product.Ratting.Rate = command.Ratting.Rate;
                product.Ratting.Count = command.Ratting.Count;
            }

            await _productsRepository.UnitOfWork.CommitAsync();

            var UpdateProductsIntegrationEvent = _mapper.Map<UpdateProductsIntegrationEvent>(product);

            await _mediator.Publish(UpdateProductsIntegrationEvent);
            var result = _mapper.Map<UpdateProductsResult>(product);
            return result;
        }
    }
}

