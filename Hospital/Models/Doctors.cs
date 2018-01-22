using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hospital.Models
{
    public class Doctors
    {
        [Key]
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public int? SpecializationID { get; set; }
        [ForeignKey("SpecializationID")]
        public Specialization specialization { get; set; }
        public ICollection<Schedule> schedules { get; set; }
    }
}