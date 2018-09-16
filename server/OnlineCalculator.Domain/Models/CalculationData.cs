using OnlineCalculator.Domain.Common;

namespace OnlineCalculator.Domain.Models
{
    public class CalculationData
    {
        public decimal Operand1 { get; set; }
        public decimal Operand2 { get; set; }
        public MathOperations MathOperation { get; set; }
    }
}
