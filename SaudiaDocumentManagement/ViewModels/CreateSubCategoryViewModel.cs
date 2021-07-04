using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaudiaDocumentManagement.ViewModels
{
    public class CreateSubCategoryViewModel
    {
        [Required]
        [Display(Name = "Enter the main categry name")]
        public String Category { get; set; }
        [Required]
        [Display(Name = "Enter the sub categry name")]
        public String SubCategory { get; set; }



    }
}
