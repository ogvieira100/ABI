using DeveloperEvaluation.ProductsApi.Application.CreateProducts;
using MediatR;

namespace DeveloperEvaluation.ProductsApi.Application.DeleteProducts
{
    public class DeleteProductsCommand : IRequest<DeleteProductResult>
    {
        public Guid Id { get; set; }

    }
}
