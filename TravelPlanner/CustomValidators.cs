using System;
using System.ComponentModel.DataAnnotations;

namespace TravelPlanner
{
    public class CustomValidators
    {
        public class FutureDate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime date = (DateTime)value;
                return date < DateTime.Now ? new ValidationResult("must be in the future.") : ValidationResult.Success;
            }
        }

    }
}