using OnlineCalculator.Domain.Common;
using System;

namespace OnlineCalculator.Domain.Providers
{
    internal class MathExpressionProvider : IMathExpressionProvider
    {
        public Func<decimal, decimal, decimal> Get(MathOperations operation)
        {
            switch (operation)
            {
                case MathOperations.Add:
                    return (x, y) => x + y;
                case MathOperations.Subtract:
                    return (x, y) => x - y;
                case MathOperations.Multiply:
                    return (x, y) => x * y;
                case MathOperations.Divide:
                    return (x, y) => x / y;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
