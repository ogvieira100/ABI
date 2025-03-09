namespace DeveloperEvaluation.CartsApi.Dto
{
    public class CreateCardItensDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
