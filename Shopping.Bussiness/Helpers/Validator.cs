using FluentValidation;

namespace ShoppingCart.Bussiness.Helpers
{
    public class Validator<Model>
    {
        public static void Validate(Model model, IEnumerable<IValidator<Model>> validators)
        {
            var Failures = validators.Select(v => v.Validate(model))
                                   .SelectMany(v => v.Errors)
                                   .Where(f => f != null)
                                   .ToList();

            if (Failures.Any())
            {
                throw new ValidationException(Failures);
            }
        }
    }
}
