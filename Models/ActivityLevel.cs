using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogKennel_Project.Models
{
    public class ActivityLevel
    {
        public int Id { get; set; }
        [Display(Name ="Activity")]
        [Required]
        public string Activity_Level { get; set; }
        [Display(Name = "Barking")]
        public string Barking_Level { get; set; }
    }
}
