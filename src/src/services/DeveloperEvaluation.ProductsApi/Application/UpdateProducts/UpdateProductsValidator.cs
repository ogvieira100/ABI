using DeveloperEvaluation.Core.Validation;
using FluentValidation;

namespace DeveloperEvaluation.ProductsApi.Application.UpdateProducts
{
    public class UpdateProductsValidator : AbstractValidator<UpdateProductsCommand>
    {
        public UpdateProductsValidator()
        {
            RuleFor(x => x.Id)
              .NotEmpty()
              .WithMessage("Product ID is required");
            RuleFor(pr => pr.Price).SetValidator(new PriceValidation(1, null));
            RuleFor(pr => pr.Description)
                .NotEmpty()
                .Length(15, 100)
                .WithMessage("Atenção a descrição deve ter entre 15 e 100 caracteres");

            RuleFor(pr => pr.Title)
                 .NotEmpty()
                 .Length(15, 50)
                 .WithMessage("Atenção o titulo deve conter entre 15 e 50 caracteres");

            RuleFor(pr => pr.Category)
               .NotEmpty()
               .Length(3, 50)
               .WithMessage("Atenção a categoria deve ter entre 3 e 50 caracteres");
        }

    }
}
