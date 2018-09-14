using OnlineCalculator.Domain.Common;
using OnlineCalculator.Domain.Models;

namespace OnlineCalculator.Domain.Services
{
    public interface ICalculatorService
    {
        OperationResult Calculate(decimal x, decimal y, MathOperations operation);
    }
}