using OnlineCalculator.Domain.Common;

namespace OnlineCalculator.Web.Models
{
    public class CalculationRequest
    {
        public decimal Operand1 { get; set; }
        public decimal Operand2 { get; set; }
        public MathOperations MathOperation { get; set; }
    }
}