using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlannerDemo
{
    public class CustomerValidators
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