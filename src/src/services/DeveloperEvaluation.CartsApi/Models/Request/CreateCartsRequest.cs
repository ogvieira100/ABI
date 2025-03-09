using DeveloperEvaluation.CartsApi.Dto;

namespace DeveloperEvaluation.CartsApi.Models.Request
{
    public class CreateCartsRequest
    {
        public Guid UserIdInsert { get; set; }

        public IEnumerable<CreateCardItensDto> CreateCardItens { get; set; }

        public CreateCartsRequest()
        {
            CreateCardItens = new List<CreateCardItensDto>();
        }
    }
}
