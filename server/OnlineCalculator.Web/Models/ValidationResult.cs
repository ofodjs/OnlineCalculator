namespace OnlineCalculator.Web.Models
{
    public class ValidationResult
    {
        public static readonly ValidationResult OK = new ValidationResult();

        public string ErrorMessage { get; }
        public bool IsOk => ErrorMessage == null;

        private ValidationResult()
        {
        }

        public ValidationResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

    }
}