using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudiaDocumentManagment
{
public class category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int category_id { get; set; }
    public String category_name { get; set; }
    public int parent_id { get; set; }
    
    }
}