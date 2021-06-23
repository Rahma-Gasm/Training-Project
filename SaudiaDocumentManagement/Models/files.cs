using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SaudiaDocumentManagment
 {
public class files
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int file_id { get; set; }
    [Display(Name = "Enter file name")]
    public String name { get; set; }
    [Display(Name = "Enter file number")]
    public int file_number { get; set; }
    public String file_category { get; set; }
    public int pdf_file { get; set; }
    public int category_id { get; set;}
    public category category { get; set; }
    }
}