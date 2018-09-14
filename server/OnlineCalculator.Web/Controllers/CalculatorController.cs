using OnlineCalculator.Domain.Models;
using OnlineCalculator.Domain.Services;
using OnlineCalculator.Web.Models;
using System.Web.Http;

namespace OnlineCalculator.Web.Controllers
{
    [RoutePrefix("api")]
    public class CalculatorController : ApiController
    {
        private readonly ICalculatorService _calculator;

        public CalculatorController(ICalculatorService calculator)
        {
            _calculator = calculator;
        }

        [HttpPost]
        [Route("calculate")]
        public OperationResult Calculate(CalculationRequest request)
        {
            return _calculator.Calculate(request.Operand1, request.Operand2, request.MathOperation);
        }
    }
}
