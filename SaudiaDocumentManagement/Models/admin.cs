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
    [Display(Name = "Enter your ID")]
    public int admin_id { get; set; }
    public String name { get; set; }
    public string password { get; set; }
    [Display(Name = "Enter your Password")]
    public DateTime date_of_birth { get; set; }
    public int mobile_number { get; set; }
}
}