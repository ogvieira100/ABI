using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;
using DeveloperEvaluation.CartsApi.Dto;
using FluentValidation;

namespace DeveloperEvaluation.CartsApi.Models.Request
{
    public class CreateCartsItensValidatorDto: AbstractValidator<CreateCardItensDto>
    {
        public CreateCartsItensValidatorDto()
        {
            RuleFor(x => x.ProductId).NotEmpty()
                   .WithMessage("Informe o Produto");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");
        }
    }
}


