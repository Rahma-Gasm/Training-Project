using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudiaDocumentManagment
 {
public class admin
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    [Display(Name = "ID: ")]
    public int admin_id { get; set; }

    [Display(Name = "Full Name: ")]
    public String name { get; set; }

    [Display(Name = "Email Address: ")]
    public String Email { get; set; }

    [Display(Name = "Password: ")]
    public string password { get; set; }

    [Display(Name = "Date Of Birth: ")]
    public DateTime date_of_birth { get; set; }

    [Display(Name = "Mobile Number: ")]
     public int mobile_number { get; set; }
}
}