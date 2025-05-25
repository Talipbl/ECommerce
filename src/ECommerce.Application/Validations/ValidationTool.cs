using FluentValidation;
using FluentValidation.Results;

namespace ECommerce.Application.Validations
{
    public static class ValidationTool
    {
        public static List<ValidationFailure> Validate(this IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                return (List<ValidationFailure>)result.Errors;
            }
            return null;
        }
    }
}
