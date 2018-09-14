namespace OnlineCalculator.Domain.Models
{
    public class OperationResult
    {
        public decimal Value { get; }
        public string ErrorMessage { get; }
        public bool IsOk => ErrorMessage == null;

        public OperationResult(decimal value)
        {
            Value = value;
        }

        public OperationResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

    }
}
