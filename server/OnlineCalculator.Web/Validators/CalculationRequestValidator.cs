using OnlineCalculator.Web.Models;

namespace OnlineCalculator.Web.Validators
{
    public class CalculationRequestValidator : BaseValidator<CalculationRequest>
    {
        public override ValidationResult Validate(CalculationRequest model)
        {
            return MergeResults(
                ValidateAsDecimalRequired(nameof(model.Operand1), model.Operand1),
                ValidateAsDecimalRequired(nameof(model.Operand2), model.Operand2),
                ValidateAsMathOperationRequired(nameof(model.MathOperation), model.MathOperation)
                );
        }
    }
}