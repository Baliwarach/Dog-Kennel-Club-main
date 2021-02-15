using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogKennel_Project.Models
{
    public class Breed
    {
        public int Id { get; set; }
        [Display(Name = "Breed")]
        [Required]
        public string Breed_Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage ="Age should be greater than 0")]
        public int Age_Years { get; set; }

        public int DogGroupId { get; set; }
        public DogGroup DogGroup { get; set; }

        public int ActivityLevelId { get; set; }
        public ActivityLevel ActivityLevel { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }
    }
}
