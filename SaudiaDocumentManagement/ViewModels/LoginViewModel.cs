using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaudiaDocumentManagement
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "Username: ")]
        public String UserName { get; set; }
        [Required]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public String Password { get; set; }


        [Display(Name = "Remember me ")]
        public bool RmemberMe { get; set; }


    }
}

