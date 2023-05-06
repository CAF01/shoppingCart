using FluentValidation;
using ShoppingCart.Entitys.DTOs.Users;

namespace ShoppingCart.Entitys.ValidatorsDTOs.Clients
{
    public class CreateClientDTOValidator
        : AbstractValidator<CreateClientDTO>
    {
        public CreateClientDTOValidator()
        {
            RuleFor(u => u.Name)
                .NotNull()
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50);

            RuleFor(u => u.LastName)
                .NotNull()
                .NotEmpty().WithMessage("LastName is required.")
                .MaximumLength(100);

            RuleFor(u => u.Email)
                .NotNull()
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("The Email is not valid.")
                .MaximumLength(50);

            RuleFor(u => u.Address)
               .NotNull()
               .NotEmpty().WithMessage("Address is required.")
               .MaximumLength(150);

            RuleFor(u => u.Password)
            .NotNull()
            .NotEmpty().WithMessage("Password is required.")
            .MaximumLength(8);

        }
    }
}
