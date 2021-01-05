using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProductMgmtMvc.Models
{
    public class admin
    {

        [DisplayName("Username")]
        [Required]
        public string username { get; set; }

        [DisplayName("Password")]
        [Required]
        public string password { get; set; }
        public string grant_type { get; set; }
    }
}