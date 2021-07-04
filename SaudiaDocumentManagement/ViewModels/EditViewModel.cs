using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudiaDocumentManagement.ViewModels
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
        [Display(Name = "Old Password: ")]
        [DataType(DataType.Password)]
        public String oldPass { get; set; }
        [Display(Name = "New Password: ")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password: ")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public String PConfirmation { get; set; }
    }
}