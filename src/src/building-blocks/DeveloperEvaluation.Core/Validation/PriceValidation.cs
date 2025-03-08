using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Validation
{
    public class PriceValidation : AbstractValidator<decimal?>
    {
        public PriceValidation(decimal? minValue = null, decimal? maxValue = null)
        {
            RuleFor(x => x)
                .NotNull().WithMessage("O valor não pode ser nulo.")
                .Must(x => !minValue.HasValue || x >= minValue)
                .WithMessage(x => $"O valor deve ser maior ou igual a {minValue}.")
                .Must(x => !maxValue.HasValue || x <= maxValue)
                .WithMessage(x => $"O valor deve ser menor ou igual a {maxValue}.");
        }
    }
}
