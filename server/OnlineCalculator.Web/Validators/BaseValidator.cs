using OnlineCalculator.Domain.Common;
using OnlineCalculator.Web.Models;
using System;
using System.Linq;

namespace OnlineCalculator.Web.Validators
{
    public abstract class BaseValidator<T> : IValidator<T> where T : class
    {
        public abstract ValidationResult Validate(T model);

        protected bool IsValidDecimal(string value)
        {
            return decimal.TryParse(value, out decimal parsedValue);
        }

        protected bool IsValidMathOperation(string value)
        {
            return Enum.IsDefined(typeof(MathOperations), value);
        }

        protected ValidationResult ValidateAsDecimalRequired(string propertyName, string value)
        {
            if (string.IsNullOrEmpty(value) || !IsValidDecimal(value))
            {
                return new ValidationResult($"{propertyName}: Field should have numeric format");
            }
            return ValidationResult.OK;
        }

        protected ValidationResult ValidateAsMathOperationRequired(string propertyName, string value)
        {
            if (string.IsNullOrEmpty(value) || !IsValidMathOperation(value))
            {
                return new ValidationResult($"{propertyName}: MathOperation is required");
            }
            return ValidationResult.OK;
        }

        protected ValidationResult MergeResults(params ValidationResult[] validationResult)
        {
            if (validationResult.All(x => x.IsOk))
            {
                return ValidationResult.OK;
            }

            return new ValidationResult(string.Join(", ", validationResult.Where(x => !x.IsOk).Select(x => x.ErrorMessage)));
        }
    }
}