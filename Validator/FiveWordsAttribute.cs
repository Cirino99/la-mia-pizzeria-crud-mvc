using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Validator
{
    public class FiveWordsAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;

            if (fieldValue == null)
            {
                return new ValidationResult("Il campo deve contenere almeno cinque parole");
            }
            string[] fieldValueArr = fieldValue.Split(' ');
            if (fieldValueArr.Length < 5)
            {
                return new ValidationResult("Il campo deve contenere almeno cinque parole");
            }

            return ValidationResult.Success;
        }
    }
}
