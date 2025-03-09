using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;
using MediatR;

namespace DeveloperEvaluation.CartsApi.Application.CreateCarts
{
    public class CreateCartsCommand : IRequest<CreateCartsResult>
    {
        public Guid UserIdInsert { get; set; }
        public IEnumerable<CreateCartsItensCommand> CreateCardItens { get; set; }

        
        public CreateCartsCommand()
        {
            CreateCardItens = new List<CreateCartsItensCommand>();
        }
    }
}
