using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hospital.Models
{
    public class Specialization
    {
        [Key]
        public int SpecializationID { get; set; }
        public string Category { get; set; }
        public ICollection<Disease> diseases { get; set; }
    }
}