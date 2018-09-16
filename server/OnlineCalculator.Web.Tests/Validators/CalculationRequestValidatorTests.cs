using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCalculator.Web.Models;
using OnlineCalculator.Web.Validators;

namespace OnlineCalculator.Web.Tests.Validators
{
    [TestClass]
    public class CalculationRequestValidatorTests
    {
        private IValidator<CalculationRequest> _validator;

        [TestInitialize]
        public void TestInitialize()
        {
            _validator = new CalculationRequestValidator();
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
        public void Validate_WhenValid_Ok()
        {
            var request = MakeCorrectRequest();

            var result = _validator.Validate(request);

            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public void Validate_WhenOperand1IsNull_Failed()
        {
            var request = MakeCorrectRequest();
            request.Operand1 = null;

            var result = _validator.Validate(request);

            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("Operand1: Field should have numeric format", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_WhenOperand1IsEmpty_Failed()
        {
            var request = MakeCorrectRequest();
            request.Operand1 = string.Empty;

            var result = _validator.Validate(request);

            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("Operand1: Field should have numeric format", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_WhenOperand1IsLetter_Failed()
        {
            var request = MakeCorrectRequest();
            request.Operand1 = "a";

            var result = _validator.Validate(request);

            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("Operand1: Field should have numeric format", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_WhenOperand2IsNull_Failed()
        {
            var request = MakeCorrectRequest();
            request.Operand2 = null;

            var result = _validator.Validate(request);

            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("Operand2: Field should have numeric format", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_WhenOperand2IsEmpty_Failed()
        {
            var request = MakeCorrectRequest();
            request.Operand2 = string.Empty;

            var result = _validator.Validate(request);

            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("Operand2: Field should have numeric format", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_WhenOperand2IsLetter_Failed()
        {
            var request = MakeCorrectRequest();
            request.Operand2 = "a";

            var result = _validator.Validate(request);

            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("Operand2: Field should have numeric format", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_WhenMathOperationIsNull_Failed()
        {
            var request = MakeCorrectRequest();
            request.MathOperation = null;

            var result = _validator.Validate(request);

            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("MathOperation: MathOperation is required", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_WhenMathOperationIsEmpty_Failed()
        {
            var request = MakeCorrectRequest();
            request.MathOperation = string.Empty;

            var result = _validator.Validate(request);

            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("MathOperation: MathOperation is required", result.ErrorMessage);
        }

        [TestMethod]
        public void Validate_WhenMathOperationUnknown_Failed()
        {
            var request = MakeCorrectRequest();
            request.MathOperation = "*";

            var result = _validator.Validate(request);

            Assert.IsFalse(result.IsOk);
            Assert.AreEqual("MathOperation: MathOperation is required", result.ErrorMessage);
        }
    }
}
