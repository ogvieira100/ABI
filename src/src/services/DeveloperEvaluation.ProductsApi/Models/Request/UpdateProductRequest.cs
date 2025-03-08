namespace DeveloperEvaluation.ProductsApi.Models.Request
{
    public class UpdateProductRequest: CreateProductRequest
    {

        public Guid Id { get; set; }
    }
}
