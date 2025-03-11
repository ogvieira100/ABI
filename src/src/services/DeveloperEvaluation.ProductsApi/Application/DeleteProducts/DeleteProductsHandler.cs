using AutoMapper;
using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.MessageBus.Models.Integration;
using DeveloperEvaluation.ProductsApi.Application.CreateProducts;
using DeveloperEvaluation.ProductsApi.Models;
using MediatR;

namespace DeveloperEvaluation.ProductsApi.Application.DeleteProducts
{
    public class DeleteProductsHandler : IRequestHandler<DeleteProductsCommand, DeleteProductResult>
    {
        readonly IBaseRepository<Products> _productsRepository;
        readonly IMapper _mapper;
        readonly IMediator _mediator;
        public DeleteProductsHandler(IBaseRepository<Products> productsRepository,
            IMediator mediator,
            IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<DeleteProductResult> Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
        {
            var product =  (await _productsRepository.RepositoryConsult.SearchAsync(x => x.Id == request.Id))?.FirstOrDefault();
            if (product == null)
                throw new KeyNotFoundException($"Produto  ID {request.Id} não encontrado");

            _productsRepository.Remove(product);
            await _productsRepository.UnitOfWork.CommitAsync();

           var integration =  _mapper.Map<DeleteProductsIntegrationEvent>(product);
           await _mediator.Publish(integration);

            return new DeleteProductResult { Success = true };

        }
    }
}
