using OnlineCalculator.Domain.Models;
using OnlineCalculator.Domain.Providers;
using System;

namespace OnlineCalculator.Domain.Services
{
    internal class CalculatorService : ICalculatorService
    {
        private readonly IMathExpressionProvider _mathExpressionProvider;

        public CalculatorService(IMathExpressionProvider mathExpressionProvider)
        {
            _mathExpressionProvider = mathExpressionProvider;
        }

        public OperationResult Calculate(CalculationData data)
        {
            Func<decimal, decimal, decimal> mathExpression;
            var operation = data.MathOperation;

            try
            {
                mathExpression = _mathExpressionProvider.Get(operation);
            }
            catch (Exception)
            {
                return new OperationResult($"Operation '{operation}' is not supported");
            }

            try
            {
                var value = mathExpression(data.Operand1, data.Operand2);
                return new OperationResult(value);
            }
            catch (Exception)
            {
                return new OperationResult($"Error executing '{operation}' operation between {data.Operand1} and {data.Operand2}");
            }
        }
    }
}
