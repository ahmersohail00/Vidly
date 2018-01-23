using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.CustomValidations
{
    public class Minimum18 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (!customer.BirthDate.HasValue)
                return new ValidationResult("Date of Birth is required");
            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;
            return (age >= 18)
            ? ValidationResult.Success :
            new ValidationResult("Cutomer should be atleast 18 for this membership");
        }
    }
}