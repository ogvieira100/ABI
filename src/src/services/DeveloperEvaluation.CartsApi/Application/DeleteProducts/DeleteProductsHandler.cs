using AutoMapper;
using DeveloperEvaluation.CartsApi.Application.DeleteCartItens;
using DeveloperEvaluation.CartsApi.Models;
using DeveloperEvaluation.Core.Data;
using FluentValidation;
using MediatR;

namespace DeveloperEvaluation.CartsApi.Application.DeleteProducts
{
    public class DeleteProductsHandler : IRequestHandler<DeleteProductsCommand, DeleteProductsResult>
    {
        readonly IBaseRepository<Carts>  _cartsRepository;
        readonly IBaseRepository<CartsItens> _cartsItensRepository;
        readonly IBaseRepository<Products> _productsRepository;
        readonly IMapper _mapper;
        readonly IMediator _mediator;
       
        public DeleteProductsHandler(IBaseRepository<Products> productsRepository,
            IBaseRepository<Carts> cartsRepository,
            IMapper mapper,
            IBaseRepository<CartsItens> cartsItensRepository,
            IMediator mediator)
        {
            _cartsRepository = cartsRepository;
            _mapper = mapper;
            _productsRepository = productsRepository;
            _cartsItensRepository = cartsItensRepository;
            _mediator = mediator;
        }

        public async Task<DeleteProductsResult> Handle(DeleteProductsCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteProductsValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var product = (await _productsRepository.RepositoryConsult.SearchAsync(x => x.ProductIdIntegrated == command.Id))?.FirstOrDefault();
            if (product == null)
                throw new InvalidOperationException($"Produto não existe");

            var carItens =   await _cartsItensRepository.RepositoryConsult.SearchAsync(x => x.Product.ProductIdIntegrated == command.Id);
            if (carItens.Any())
            {
                var cartsItensDelete = carItens.Select(x => x.Id);
                await _mediator.Send(new DeleteCartsItensCommand { CartItensId = cartsItensDelete });
            }

            _productsRepository.Remove(product);
            await   _productsRepository.UnitOfWork.CommitAsync();
            return new DeleteProductsResult();
        }
       
    }
}
