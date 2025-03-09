namespace DeveloperEvaluation.CartsApi.Models.Request
{
    public class CreateCartsRequest
    {
        public Guid UserIdInsert { get; set; }

        public IEnumerable<CreateCardItensDto> CreateCardItens { get; set; }
    }
}
