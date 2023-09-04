using Castle.DynamicProxy;
using FluentValidation;
using FluentValidation.Results;

namespace ECommerce.Core.Application
{
    public class ValidationAspect : MethodInterceptor
    {
        private Type _validatorType;
        private List<ValidationFailure> _errors;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectConst.WrongValidationType);
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                _errors = ValidationTool.Validate(validator, entity);
            }

            IsSuccess = false;
        }

        protected override void OnAfter(IInvocation invocation)
        {
            IsSuccess = true;
            if (_errors != null)
            {
                List<string> validationErrors = new List<string>();

                foreach (var error in _errors)
                {
                    validationErrors.Add(error.ErrorMessage);
                }

                invocation.ReturnValue = new ValidationDataResult(validationErrors, "Validate Error");
            }
        }
    }
}
