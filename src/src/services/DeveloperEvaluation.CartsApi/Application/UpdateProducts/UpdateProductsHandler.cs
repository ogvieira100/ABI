using AutoMapper;
using DeveloperEvaluation.CartsApi.Application.UpdateCartsItens;
using DeveloperEvaluation.CartsApi.Models;
using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.MessageBus.Models.Integration;

using FluentValidation;
using MediatR;
using Npgsql;

namespace DeveloperEvaluation.CartsApi.Application.UpdateProducts
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

            var productTitle = await _productsRepository.RepositoryConsult.SearchAsync(x => x.Title == command.Title && x.ProductIdIntegrated != command.Id, cancellationToken);
            if (productTitle != null && productTitle.Any())
                throw new InvalidOperationException($"Produto com o titulo {command.Title} já existe");


            var product = (await _productsRepository.RepositoryConsult.SearchAsync(x => x.ProductIdIntegrated == command.Id,cancellationToken))?.FirstOrDefault();
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

            /*atualizar carts com o preço unitario do produto*/
            await _productsRepository.UnitOfWork.CommitAsync();
            var cartsUpdate = _mapper.Map<UpdateCartsItensUnitPriceCommand>(product);
            await _mediator.Send(cartsUpdate,cancellationToken);

            var result = _mapper.Map<UpdateProductsResult>(product);
            return result;
        }
    }
}
