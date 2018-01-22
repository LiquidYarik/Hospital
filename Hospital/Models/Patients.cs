using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hospital.Models
{
    public class Patients
    {
        [Key]
        public int PatientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int? DiseaseID { get; set; }
        [ForeignKey("DiseaseID")]
        public Disease disease { get; set; }
        public ICollection<Schedule> schedules { get; set; }
    }
}