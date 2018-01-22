using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hospital.Models
{
    public class Disease
    {
        [Key]
        public int DiseaseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SpecializationID { get; set; }
        [ForeignKey("SpecializationID")]
        public Specialization specialization { get; set; }
    }
}