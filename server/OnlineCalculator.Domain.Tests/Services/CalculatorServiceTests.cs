using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineCalculator.Domain.Common;
using OnlineCalculator.Domain.Models;
using OnlineCalculator.Domain.Providers;
using OnlineCalculator.Domain.Services;
using System;

namespace OnlineCalculator.Domain.Tests.Services
{
    [TestClass]
    public class CalculatorServiceTests
    {
        private ICalculatorService _service;
        private Mock<IMathExpressionProvider> _providerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _providerMock = new Mock<IMathExpressionProvider>();
            _providerMock.Setup(x => x.Get(It.IsAny<MathOperations>())).Returns((x, y) => 3);

            _service = new CalculatorService(_providerMock.Object);
        }

        [TestMethod]
        public void Calculate_WhenCall_ReturnedResult()
        {
            const decimal expectedValue = 5;
            var data = new CalculationData { MathOperation = MathOperations.Multiply, Operand1 = 1, Operand2 = 1 };
            _providerMock.Setup(x => x.Get(It.IsAny<MathOperations>())).Returns((x, y) => expectedValue);

            var result = _service.Calculate(data);

            Assert.IsTrue(result.IsOk);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [TestMethod]
        public void Calculate_WhenCall_CalledProvider()
        {
            var data = new CalculationData { MathOperation = MathOperations.Multiply };

            var result = _service.Calculate(data);

            _providerMock.Verify(x => x.Get(MathOperations.Multiply), Times.Once);
        }

        [TestMethod]
        public void Calculate_WhenProviderThrowsException_ReturnedError()
        {
            var data = new CalculationData { MathOperation = MathOperations.Multiply };
            _providerMock.Setup(x => x.Get(It.IsAny<MathOperations>())).Throws<Exception>();

            var result = _service.Calculate(data);

            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("Operation 'Multiply' is not supported", result.ErrorMessage);
        }

        [TestMethod]
        public void Calculate_WhenDivideByZero_ReturnedError()
        {
            var data = new CalculationData { MathOperation = MathOperations.Divide, Operand2 = 0 };

            var result = _service.Calculate(data);

            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("Attempt to divide by zero", result.ErrorMessage);
        }

        [TestMethod]
        public void Calculate_WhenCalculationThrowsException_ReturnedError()
        {
            var data = new CalculationData();
            _providerMock.Setup(x => x.Get(It.IsAny<MathOperations>())).Returns((x, y) => throw new Exception());

            var result = _service.Calculate(data);

            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("Error executing 'Add' operation between 0 and 0", result.ErrorMessage);
        }
    }
}
