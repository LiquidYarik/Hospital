using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital.Helpers;
namespace Hospital.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public string TimeString
        {
            get
            {
                return Timeslots.GetTime(this.Time);
            }
            private set { }
        }
        public int Time { get; set; }
        public int DoctorID{ get; set; }
        public int PatientID { get; set; }
        public Patients patients { get; set; }
    }
}