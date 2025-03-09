
using DeveloperEvaluation.CartsApi.ValueObjects;
using MediatR;

namespace DeveloperEvaluation.CartsApi.Application.UpdateProducts
{
    public class UpdateProductsCommand:IRequest<UpdateProductsResult>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

        public RattingValueObjects Ratting { get; set; }

    }
}
