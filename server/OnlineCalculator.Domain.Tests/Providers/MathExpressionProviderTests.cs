using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCalculator.Domain.Common;
using OnlineCalculator.Domain.Providers;
using System;

namespace OnlineCalculator.Domain.Tests.Providers
{
    [TestClass]
    public class MathExpressionProviderTests
    {
        private IMathExpressionProvider _provider;

        [TestInitialize]
        public void TestInitialize() {
            _provider = new MathExpressionProvider();
        }

        [TestMethod]
        public void Get_WhenAdd_ReturnedExpressionAdd()
        {
            var operation = MathOperations.Add;

            var result = _provider.Get(operation);

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result(2, 3));
        }

        [TestMethod]
        public void Get_WhenSubtract_ReturnedExpressionSubtract()
        {
            var operation = MathOperations.Subtract;

            var result = _provider.Get(operation);

            Assert.IsNotNull(result);
            Assert.AreEqual(-1, result(2, 3));
        }

        [TestMethod]
        public void Get_WhenDivide_ReturnedExpressionDivide()
        {
            var operation = MathOperations.Divide;

            var result = _provider.Get(operation);

            Assert.IsNotNull(result);
            Assert.AreEqual(1.5m, result(3, 2));
        }

        [TestMethod]
        public void Get_WhenMultiply_ReturnedExpressionMultiply()
        {
            var operation = MathOperations.Multiply;

            var result = _provider.Get(operation);

            Assert.IsNotNull(result);
            Assert.AreEqual(6, result(2, 3));
        }

        [TestMethod]
        public void Get_WhenOther_ThrowedException()
        {
            MathOperations operation = (MathOperations)999;

            Action action = () => _provider.Get(operation);

            Assert.ThrowsException<ArgumentOutOfRangeException>(action);
        }
    }
}
