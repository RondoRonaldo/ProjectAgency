using System.ComponentModel.DataAnnotations;

namespace API_Contracts.Validators
{
    public abstract class BaseAttribute : ValidationAttribute
    {
        protected abstract override ValidationResult IsValid(object value, ValidationContext validationContext);
    }
}