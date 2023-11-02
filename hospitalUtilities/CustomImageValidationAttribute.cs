using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalUtilities
{

    public class CustomImageValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file == null)
            {
                // The property is not an IFormFile
                return ValidationResult.Success;
            }

            // Perform your custom validation logic here
            // For example, you can check the file's size, format, or other criteria.

            // Replace the following line with your validation logic
            if (file.Length > 2 * 1024 * 1024) // 2MB limit
            {
                return new ValidationResult("The image size should be less than 2MB.");
            }

            return ValidationResult.Success;
        }
    }

}
