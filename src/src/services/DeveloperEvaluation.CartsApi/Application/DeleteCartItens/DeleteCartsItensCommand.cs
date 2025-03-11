using MediatR;

namespace DeveloperEvaluation.CartsApi.Application.DeleteCartItens
{
    public class DeleteCartsItensCommand:IRequest<DeleteCartsItensResult>
    {

        public IEnumerable<Guid> CartItensId { get; set; }

        public DeleteCartsItensCommand()
        {
            CartItensId = new List<Guid>();
        }

    }
}
