using DeveloperEvaluation.Core.Validation;
using FluentValidation;

namespace DeveloperEvaluation.CartsApi.Application.UpdateCartsItens
{
    public class UpdateCartsItensUnitPriceValidator : AbstractValidator<UpdateCartsItensUnitPriceCommand>
    {
        public UpdateCartsItensUnitPriceValidator()
        {
            RuleFor(x=>x.UnitPrice)
                .GreaterThan(0)
                .WithMessage("A quantidade deve ser maior que zero.");

            RuleFor(x=>x.ProductId)
                .NotEmpty()
                .WithMessage("Atenção códido do produto inválido ");

        }

    }
}
