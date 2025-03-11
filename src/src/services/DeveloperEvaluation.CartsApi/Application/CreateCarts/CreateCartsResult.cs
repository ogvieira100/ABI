using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;

namespace DeveloperEvaluation.CartsApi.Application.CreateCarts
{
    public class CreateCartsResult
    {

        public Guid Id { get; set; }

        public List<CreateCartsItensResult> CreateCardItens { get; set; }

        public CreateCartsResult()
        {
            CreateCardItens = new List<CreateCartsItensResult>();
        }

    }
}
