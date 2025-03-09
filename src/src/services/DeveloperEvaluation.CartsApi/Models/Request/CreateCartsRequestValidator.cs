using DeveloperEvaluation.CartsApi.Application.CreateCarts;
using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;
using FluentValidation;

namespace DeveloperEvaluation.CartsApi.Models.Request
{
    public class CreateCartsRequestValidator : AbstractValidator<CreateCartsRequest>
    {
        public CreateCartsValidator()
        {
            RuleFor(x => x.UserIdInsert)
                    .NotEmpty()
                    .WithMessage("Informe o Usuario");

            RuleForEach(x => x.CreateCardItens)
                .SetValidator(new CreateCartsItensValidator());
        }
    }
}
