using FluentValidation;

namespace DeveloperEvaluation.ProductsApi.Application.DeleteProducts
{
    public class DeleteProductsValidator : AbstractValidator<DeleteProductsCommand>
    {
        /// <summary>
        /// Initializes validation rules for DeleteUserCommand
        /// </summary>
        public DeleteProductsValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required");
        }
    }
}
