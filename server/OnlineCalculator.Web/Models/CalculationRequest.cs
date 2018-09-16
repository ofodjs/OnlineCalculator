using OnlineCalculator.Domain.Common;

namespace OnlineCalculator.Web.Models
{
    public class CalculationRequest
    {
        public string Operand1 { get; set; }
        public string Operand2 { get; set; }
        public string MathOperation { get; set; }
    }
}