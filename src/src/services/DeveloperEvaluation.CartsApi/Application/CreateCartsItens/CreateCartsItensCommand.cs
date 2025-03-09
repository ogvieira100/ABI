using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;
using MediatR;

namespace DeveloperEvaluation.CartsApi.Application.CreateCartsItens
{
    public class CreateCartsItensCommand: ICartsItens,IRequest<CreateCartsItensResult>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

    }
}


