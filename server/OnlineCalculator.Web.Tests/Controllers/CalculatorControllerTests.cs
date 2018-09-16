using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineCalculator.Domain.Common;
using OnlineCalculator.Domain.Models;
using OnlineCalculator.Domain.Services;
using OnlineCalculator.Web.Controllers;
using OnlineCalculator.Web.Models;
using OnlineCalculator.Web.Validators;

namespace OnlineCalculator.Web.Tests.Controllers
{
    [TestClass]
    public class CalculatorControllerTests
    {
        private CalculatorController _controller;
        private Mock<ICalculatorService> _calculatorMock;
        private Mock<IValidator<CalculationRequest>> _requestValidatorMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _calculatorMock = new Mock<ICalculatorService>();
            _calculatorMock.Setup(x => x.Calculate(It.IsAny<CalculationData>())).Returns(new OperationResult(123));

            _requestValidatorMock = new Mock<IValidator<CalculationRequest>>();
            _requestValidatorMock.Setup(x => x.Validate(It.IsAny<CalculationRequest>())).Returns(ValidationResult.OK);

            _controller = new CalculatorController(_calculatorMock.Object, _requestValidatorMock.Object);
        }

        private CalculationRequest MakeCorrectRequest()
        {
            return new CalculationRequest
            {
                Operand1 = "2",
                Operand2 = "3",
                MathOperation = "Add"
            };
        }

        [TestMethod]
        public void Calculate_WhenCorrect_Ok()
        {
            var request = MakeCorrectRequest();

            var result = _controller.Calculate(request);

            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public void Calculate_WhenRequestInvalid_ReturnedError()
        {
            var request = MakeCorrectRequest();
            _requestValidatorMock.Setup(x => x.Validate(It.IsAny<CalculationRequest>())).Returns(new ValidationResult("error123"));

            var result = _controller.Calculate(request);

            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("error123", result.ErrorMessage);
        }

        [TestMethod]
        public void Calculate_WhenRequestValid_CalledCalculatorService()
        {
            var request = new CalculationRequest
            {
                Operand1 = "123",
                Operand2 = "456",
                MathOperation = "Divide"
            };

            var result = _controller.Calculate(request);

            _calculatorMock.Verify(x => x.Calculate(It.Is<CalculationData>(
                z => z.Operand1 == 123 && z.Operand2 == 456 && z.MathOperation == MathOperations.Divide
                )), Times.Once);
        }

        [TestMethod]
        public void Calculate_WhenCall_ReturnedResultFromService()
        {
            var request = MakeCorrectRequest();
            var expectedResult = new OperationResult(678);
            _calculatorMock.Setup(x => x.Calculate(It.IsAny<CalculationData>())).Returns(expectedResult);

            var result = _controller.Calculate(request);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
