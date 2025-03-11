using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;

namespace DeveloperEvaluation.CartsApi.Application.CreateCarts
{
    public class DeleteProductsResult
    {

        public Guid Id { get; set; }

        public List<CreateCartsItensResult> CreateCardItens { get; set; }

        public DeleteProductsResult()
        {
            CreateCardItens = new List<CreateCartsItensResult>();
        }

    }
}
