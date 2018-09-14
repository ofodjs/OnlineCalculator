using OnlineCalculator.Domain.Common;
using System;

namespace OnlineCalculator.Domain.Providers
{
    public interface IMathExpressionProvider
    {
        Func<decimal, decimal, decimal> Get(MathOperations operation);
    }
}