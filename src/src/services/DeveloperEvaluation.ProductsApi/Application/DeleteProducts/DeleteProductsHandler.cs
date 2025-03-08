using AutoMapper;
using DeveloperEvaluation.Core.Data;
using DeveloperEvaluation.ProductsApi.Application.CreateProducts;
using DeveloperEvaluation.ProductsApi.Models;
using MediatR;

namespace DeveloperEvaluation.ProductsApi.Application.DeleteProducts
{
    public class DeleteProductsHandler : IRequestHandler<DeleteProductsCommand, DeleteProductResult>
    {
        readonly IBaseRepository<Products> _productsRepository;
        readonly IMapper _mapper;
        public DeleteProductsHandler(IBaseRepository<Products> productsRepository,
            IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<DeleteProductResult> Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
        {
            var product =  (await _productsRepository.RepositoryConsult.SearchAsync(x => x.Id == request.Id))?.FirstOrDefault();
            if (product == null)
                throw new KeyNotFoundException($"Produto  ID {request.Id} não encontrado");

            _productsRepository.Remove(product);
            await _productsRepository.UnitOfWork.CommitAsync();

            return new DeleteProductResult { Success = true };

        }
    }
}
