using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogKennel_Project.Models
{
    public class Size
    {
        public int Id { get; set; }
        [Display(Name = "Size")]
        [Required]
        public string Size_Name { get; set; }
        [Display(Name = "Shedding")]
        public string Shedding_Name { get; set; }
    }
}
