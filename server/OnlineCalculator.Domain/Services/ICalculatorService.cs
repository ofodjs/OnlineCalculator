using OnlineCalculator.Domain.Models;

namespace OnlineCalculator.Domain.Services
{
    public interface ICalculatorService
    {
        OperationResult Calculate(CalculationData data);
    }
}