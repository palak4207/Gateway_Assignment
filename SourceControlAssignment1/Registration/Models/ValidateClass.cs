using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;
using static FormValidation.CustomAttribute;

namespace Registration.Models
{
    public class ValidateClass
    {
        //Id Validation
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        //Name Validation
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must have max length 50 and min length 3 ")]
        public string Name { get; set; }

        //Age validation
        [Required(ErrorMessage = "Age is Required")]
        [Display(Name = "Age")]
        [Range(18, 40, ErrorMessage = "Age must be between 18 to 40 yrs")]
        public int Age { get; set; }


        //Email Validation
        [Required(ErrorMessage = "Email is Required")]
        [Display(Name = "Email ID")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Email Not Matched")]
        public string Email { get; set; }

        //PhoneNo Validation
        [Required(ErrorMessage = "PhoneNo is Required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})[-. ]?([0-9]{4})[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid Phone number")]
        public int PhoneNo { get; set; }


        ////DOB Validation
        [Required(ErrorMessage = "DateOfBirth is Required")]
        [Display(Name = "D.O.B.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }


        // Address Validation
        [Required(ErrorMessage = "Address is Required")]
        [Display(Name = "Address")]
        [MinLength(10,ErrorMessage ="Please specify the full Address")]
        public string Address { get; set; }
        
        //HigherSecondaryPercentage Validation
        [Required(ErrorMessage = "12th percentage is Required")]
        [Display(Name = "12th Percentage")]

        public float HigherSecondaryPercentage { get; set; }


        //SecondaryPercentage Validation
        [Required(ErrorMessage = "10th percentage  is Required")]
        [Display(Name = "10th Percentage")]
        public float SecondaryPercentage { get; set; }

        //University Name
        [Required(ErrorMessage = "University Name is Required")]
        [Display(Name = "University Name")]
        [MaxLength(50,ErrorMessage ="University Name should be greater than 5 letter")]
        public string UniversityName { get; set; }

        //Graduation Year

        [Required(ErrorMessage = "Graduation Year is Required")]
        [Registration.customValidation.customValidate(2021)]
        [Range(2021,2025,ErrorMessage ="The Gradutaion year must be betwwen 2021 to 2025  form")]
        [Display(Name = "Graduation Year ")]
        public int GraduationYear { get; set; }

        //GitHubLink Validation
        [Display(Name="Github link")]
        [Url][Required]
        public string GitHubLink{ get; set; }

       

        //Credit card Validation
        [Required]
        [Display(Name = "Credit Card Details")]
        [DataType(DataType.CreditCard)]
        public int  CreditCard { get; set; }

        

        //Gender Validation       
        [Required(ErrorMessage = "Gender is Required")]
        [Display(Name = "Gender")]  
        public string Gender { get; set; }

        //Password Validation

        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain lower case ,upper case and an special charcter)")]
        public string Password { get; set; }


        //RePassword Validation        
        [Required(ErrorMessage = "ConfirmPassword is Required")]
        [Display(Name = "Confirm Password ")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }

        //Organization Validation
        
        [Display(Name = "Organization Name")]
        [ReadOnly(true)]
        public string Organization { get; set; }

        //TermsandCondition Validation
        [Required(ErrorMessage = "TermsandCondition is Required")]
        [Display(Name = "Terms And Condition")]
        [Range(typeof(bool),"true","true",ErrorMessage = "Accept the TermsandCondition")]
        public bool TermsandCondition { get; set; }


    }
}