using OnlineCalculator.Domain.Common;
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

        public OperationResult Calculate(decimal x, decimal y, MathOperations operation)
        {
            Func<decimal, decimal, decimal> mathExpression;

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
                var value = mathExpression(x, y);
                return new OperationResult(value);
            }
            catch (Exception)
            {
                return new OperationResult($"Error executing '{operation}' operation between {x} and {y}");
            }
        }
    }
}
