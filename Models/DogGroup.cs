using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogKennel_Project.Models
{
    public class DogGroup
    {
        public int Id { get; set; }
        [Display(Name = "Group")]
        [Required]
        public string Group_Name { get; set; }
        [Display(Name = "Coat Type")]
        public string Coat_Type { get; set; }
    }
}
