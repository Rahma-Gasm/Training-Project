using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudiaDocumentManagment
 {
public class activity_list
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Enter your ID")]
    public int activity_id { get; set; }
    public String admin_name { get; set; }
    public DateTime update_date { get; set; }
    public int category_name { get; set; }
    public string sub_category_name{ get; set; }
    public string process_name{ get; set; }
    public string file_name{ get; set; }
    }
}