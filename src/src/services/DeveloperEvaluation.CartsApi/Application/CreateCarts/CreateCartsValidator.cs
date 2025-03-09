﻿using DeveloperEvaluation.CartsApi.Application.CreateCartsItens;
using FluentValidation;

namespace DeveloperEvaluation.CartsApi.Application.CreateCarts
{
    public class CreateCartsValidator: AbstractValidator<CreateCartsCommand>
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
