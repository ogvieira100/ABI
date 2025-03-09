using FluentValidation;

namespace DeveloperEvaluation.CartsApi.Application.CreateCartsItens
{
    public class CreateCartsItensValidator: AbstractValidator<CreateCartsItensCommand>
    {

        public CreateCartsItensValidator()
        {
             RuleFor(x=>x.ProductId).NotEmpty()
                    .WithMessage("Informe o Produto");
             RuleFor(x=>x.Quantity).GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");
        }

    }
}
