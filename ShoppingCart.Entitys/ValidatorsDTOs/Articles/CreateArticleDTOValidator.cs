using FluentValidation;
using ShoppingCart.Entitys.DTOs.Articles;


namespace ShoppingCart.Entitys.ValidatorsDTOs.Articles
{
    public class CreateArticleDTOValidator
        : AbstractValidator<CreateArticleDTO>
    {
        public CreateArticleDTOValidator()
        {
            RuleFor(a => a.Description)
                   .NotNull()
                   .NotEmpty().WithMessage("Description is required.")
                   .MaximumLength(150);

            RuleFor(a => a.Code)
                 .NotNull()
                 .NotEmpty().WithMessage("Code is required.")
                 .MaximumLength(30);

            RuleFor(a => a.Image)
               .NotNull()
               .NotEmpty().WithMessage("Image is required.");
            

            RuleFor(a => a.Price)
                 .GreaterThan(0).WithMessage("Price must be greater than $0");

            RuleFor(a => a.IdStore)
              .GreaterThan(0).WithMessage("IdStore no valid.");
        }
    }
}
