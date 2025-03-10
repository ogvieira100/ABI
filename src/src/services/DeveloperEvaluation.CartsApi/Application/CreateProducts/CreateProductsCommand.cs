using MediatR;

namespace DeveloperEvaluation.CartsApi.Application.CreateProducts
{
    public class CreateProductsCommand : IRequest<CreateProductsResult>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public decimal? Rate { get; set; }
        public int? Count { get; set; }


    }
}
