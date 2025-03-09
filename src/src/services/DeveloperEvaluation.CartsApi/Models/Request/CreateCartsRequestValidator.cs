using DeveloperEvaluation.CartsApi.Application.CreateCarts;
using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;
using FluentValidation;

namespace DeveloperEvaluation.CartsApi.Models.Request
{
    public class CreateCartsRequestValidator : AbstractValidator<CreateCartsRequest>
    {
        public CreateCartsRequestValidator()
        {
            RuleFor(x => x.UserIdInsert)
                    .NotEmpty()
                    .WithMessage("Informe o Usuario");

            RuleForEach(x => x.CreateCardItens)
                .SetValidator(new CreateCartsItensValidatorDto())
                 .NotEmpty().WithMessage("Atenção deve haver ao menos um item")
                ;
        }
    }
}
