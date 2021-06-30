using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudiaDocumentManagment
{
    public class EditViewModel
    {
        [Display(Name = "ID: ")]
        public String Id { get; set; }
        [Display(Name = "Phone Number: ")]
        public String PhoneNumber { get; set; }
        [Display(Name = "Email Address: ")]
        [EmailAddress]
        public String Email { get; set; }
        [Display(Name = "Username: ")]
        public String UserName { get; set; }
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public String PasswordHash { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password: ")]
        [Compare("PasswordHash", ErrorMessage = "Password and confirmation password do not match.")]
        public String PConfirmation { get; set; }
    }
}
