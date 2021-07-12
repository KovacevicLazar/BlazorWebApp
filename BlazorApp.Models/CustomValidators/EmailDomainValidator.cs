using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorApp.Models.CustomValidators
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string AllowedDimain { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] strings = value.ToString().Split('@');
            if (strings.Length > 1 && strings[1].ToUpper() == AllowedDimain.ToUpper())
            {
                return null;
            }
            return new ValidationResult($"Domain must be {AllowedDimain}", new[] { validationContext.MemberName });
        }
    }
}
