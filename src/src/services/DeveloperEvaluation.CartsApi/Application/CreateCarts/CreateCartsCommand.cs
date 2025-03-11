using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;
using MediatR;

namespace DeveloperEvaluation.CartsApi.Application.CreateCarts
{
    public class DeleteProductsCommand : IRequest<DeleteProductsResult>
    {
        public Guid UserIdInsert { get; set; }
        public IEnumerable<CreateCartsItensCommand> CreateCardItens { get; set; }

        
        public DeleteProductsCommand()
        {
            CreateCardItens = new List<CreateCartsItensCommand>();
        }
    }
}
