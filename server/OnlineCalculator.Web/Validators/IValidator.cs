using OnlineCalculator.Web.Models;

namespace OnlineCalculator.Web.Validators
{
    public interface IValidator<T> where T: class
    {
        ValidationResult Validate(T model); 
    }
}