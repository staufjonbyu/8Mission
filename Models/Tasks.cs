using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _8Mission.Models
{
    public class Tasks
    {
        [Key]
        [Required]
        public int TaskID { get; set; }

        [Required]
        public string Task_Name { get; set; }

        public string Due_Date { get; set; }
        [Required]
        public int Quadrant { get; set; }
       
        public Boolean Completed { get; set; }

        // Build Foreign Key
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
