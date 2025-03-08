using FluentValidation;

namespace DeveloperEvaluation.ProductsApi.Models.Request
{
    public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
    {

        public DeleteProductRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required");
        }
    }
}
