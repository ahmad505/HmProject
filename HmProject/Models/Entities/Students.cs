using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HmProject.Models.Entities
{
    public class Students
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Discription { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

    }
}
