using OnlineCalculator.Domain.Common;
using OnlineCalculator.Domain.Models;
using OnlineCalculator.Domain.Services;
using OnlineCalculator.Web.Models;
using OnlineCalculator.Web.Validators;
using System;
using System.Web.Http;

namespace OnlineCalculator.Web.Controllers
{
    [RoutePrefix("api")]
    public class CalculatorController : ApiController
    {
        private readonly ICalculatorService _calculator;
        private readonly IValidator<CalculationRequest> _calculationRequestValidator;

        public CalculatorController(ICalculatorService calculator,
            IValidator<CalculationRequest> calculationRequestValidator)
        {
            _calculator = calculator;
            _calculationRequestValidator = calculationRequestValidator;
        }

        [HttpPost]
        [Route("calculate")]
        public OperationResult Calculate(CalculationRequest request)
        {
            var validationResult = _calculationRequestValidator.Validate(request);
            if (!validationResult.IsOk)
            {
                return new OperationResult(validationResult.ErrorMessage);
            }

            var calculationData = ParseRequest(request);

            return _calculator.Calculate(calculationData);
        }

        #region Private methods

        private CalculationData ParseRequest(CalculationRequest request)
        {
            return new CalculationData
            {
                Operand1 = decimal.Parse(request.Operand1),
                Operand2 = decimal.Parse(request.Operand2),
                MathOperation = (MathOperations)Enum.Parse(typeof(MathOperations), request.MathOperation)
            };
        }

        #endregion
    }
}
