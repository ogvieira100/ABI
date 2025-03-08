using DeveloperEvaluation.ProductsApi.ValueObjects;

namespace DeveloperEvaluation.ProductsApi.Models.Request
{
    public class CreateProductRequest
    {
        
        public string? Title { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }

        public string? Image { get; set; }

        public decimal? Rate { get; set; }
        public int? Count { get; set; }

    }
}
