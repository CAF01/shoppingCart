using FluentValidation;
using ShoppingCart.Entitys.DTOs.Account;

namespace ShoppingCart.Entitys.ValidatorsDTOs.Account
{
    public class LoginDTOValidator
        : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(lg => lg.Email)
                .NotNull()
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("The Email is not valid.")
                .MaximumLength(50);

            RuleFor(lg => lg.Password)
              .NotNull()
              .NotEmpty().WithMessage("Password is required.");
        }
    }
}
