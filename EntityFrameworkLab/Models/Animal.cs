using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLab.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Species { get; set; }
        public double Weight { get; set; }
    }
}
