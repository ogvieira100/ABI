using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;

namespace DeveloperEvaluation.CartsApi.Application.CreateCarts
{
    public class CreateCartsResult
    {

        public Guid Id { get; set; }

        public List<CreateCartsItensResult> CartsItens { get; set; }

        public CreateCartsResult()
        {
            CartsItens = new List<CreateCartsItensResult>();
        }

    }
}
