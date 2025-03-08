using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Identity;

namespace DeveloperEvaluation.ProductsApi.Application.CreateProducts
{
    public class CreateProductsValidator: AbstractValidator<CreateProductsCommand>
    {


        public CreateProductsValidator()
        {
            //RuleFor(user => user.Email).SetValidator(new EmailValidator());
            //RuleFor(user => user.Username).NotEmpty().Length(3, 50);
            //RuleFor(user => user.Password).SetValidator(new PasswordValidator());
            //RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
            //RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
            //RuleFor(user => user.Role).NotEqual(UserRole.None);
        }

    }
}
