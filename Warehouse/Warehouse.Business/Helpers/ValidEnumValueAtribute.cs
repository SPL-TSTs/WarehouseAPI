using System;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Business.Helpers
{
    public class ValidEnumValueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var enumType = value.GetType();
            var isDefined = Enum.IsDefined(enumType, value);
            if (!isDefined)
            {
                return new ValidationResult($"{value} is not a valid value for type {enumType.Name}");
            }
            return ValidationResult.Success;
        }
    }
}
