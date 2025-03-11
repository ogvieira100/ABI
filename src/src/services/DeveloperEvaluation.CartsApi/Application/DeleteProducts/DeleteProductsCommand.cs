using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;
using MediatR;

namespace DeveloperEvaluation.CartsApi.Application.DeleteProducts
{
    public class DeleteProductsCommand : IRequest<DeleteProductsResult>
    {
        public Guid Id { get; set; }
        
        public DeleteProductsCommand()
        {
        
        }
    }
}
