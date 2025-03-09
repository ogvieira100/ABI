using DeveloperEvaluation.CartsApi.Application.CreateCarts;
using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;
using MediatR;

namespace DeveloperEvaluation.CartsApi.Application.UpdateCarts
{
    public class UpdateCartsCommand : IRequest<UpdateCartsResult>
    {
        public Guid UserIdUpdated { get; set; }
        public IEnumerable<ICartsItens> CardItens { get; set; }

        public UpdateCartsCommand()
        {
            CardItens = new List<ICartsItens>();
        }
    }
}
