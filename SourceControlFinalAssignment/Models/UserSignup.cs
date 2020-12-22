using Microsoft.AspNetCore.Http;
using SourceControlFinalAssignment.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SourceControlFinalAssignment.Models
{
    public class UserSignup
    {
        [Required]
        [DisplayName("First Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must have max length 50 and min length 3 ")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Image")]
        [CustomFileExtensionValidation("jpg png jpeg", ErrorMessage = "Only image can be used here")]
        public IFormFile Image { get; set; }

        [Required]
        [Phone]
        [StringLength(42)]
        [DisplayName("PhoneNo")]
        public string PhoneNo { get; set; }

        [Required]
        [Display(Name = "Age")]
        [Range(18, 40, ErrorMessage = "Age must be between 18 to 40 yrs")]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }

        [Required]
        [StringLength(70)]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain lower case ,upper case and an special charcter")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is Required")]
        [DisplayName("Confirm Password ")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
