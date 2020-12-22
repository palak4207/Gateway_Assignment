using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SourceControlFinalAssignment.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string  FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName{ get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        [Phone]
        [StringLength(42)]
        public string  PhoneNo { get; set; }

        [Required]
        public int Age{ get; set; }

        [Required]
        [EmailAddress]
        public string Email{ get; set; }

        [Required]
        [StringLength(70)]
        public string Password { get; set; }

       



    }
}
