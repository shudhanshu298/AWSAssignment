using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreDataInDB.Models
{
    public class StudentModel
    {
        [Required]
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Branch is required")]
        public string Branch { get; set; }
        [Required(ErrorMessage = "City is  required")]
        public string City { get; set; }
        
    }
}
