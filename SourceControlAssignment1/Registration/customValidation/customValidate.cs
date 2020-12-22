using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Registration.customValidation
{
    public class customValidateAttribute:ValidationAttribute
    {
        private int _minYear;
        public customValidateAttribute(int value)
        {
            _minYear = value;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value!= null) 
            {
                if (value is int)
                {
                    int miniyear = (int)value;
                    if (miniyear > _minYear)
                    {
                        return new ValidationResult("Graduation Year  must be greater then 2021 " + _minYear);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}