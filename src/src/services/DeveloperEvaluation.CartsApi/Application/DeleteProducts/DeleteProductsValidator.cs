using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;
using FluentValidation;

namespace DeveloperEvaluation.CartsApi.Application.DeleteProducts
{
    public class DeleteProductsValidator: AbstractValidator<DeleteProductsCommand>
    {
        public DeleteProductsValidator()
        {
            RuleFor(x => x.Id)
                    .NotEmpty()
                    .WithMessage("Informe o Produto");

         
        }
    }
}
