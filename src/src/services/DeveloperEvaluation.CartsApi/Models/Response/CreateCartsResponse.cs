using DeveloperEvaluation.CartsApi.Dto;

namespace DeveloperEvaluation.CartsApi.Models.Response
{
    public class CreateCartsResponse
    {
        public Guid UserIdInsert { get; set; }

        public IEnumerable<CreateCardItensDto> CreateCardItens { get; set; }

    }
}
