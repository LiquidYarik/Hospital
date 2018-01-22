using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hospital.Models;
using Hospital.Helpers;
namespace Hospital.Controllers.Web_Api
{
    [RoutePrefix("api/schedule")]
    public class ScheduleController : ApiController
    {
        HospitalDB hospitalDB = new HospitalDB();

        [Route("postschedule/{schedule}")]
        [HttpPost]
        public Schedule PostSchedule(Schedule schedule)
        {
           var result = hospitalDB.schedules.Add(schedule);
            hospitalDB.SaveChanges();
            return result;
        }
        [Route("")]
        [HttpGet]
        public KeyValuePair<int, string>[] GetScheduleDic()
        {
            var timeSlots = Timeslots.GetALL().ToArray();
            return timeSlots;
        }
        [Route("availtimeslots/{id}/{date}")]
        [HttpGet]        
        public KeyValuePair<int, string>[] GetAvailTimeSlots(int doctorId, DateTime date)
        {
            var AllSlots = Timeslots.GetALL();
            var BusySlots = hospitalDB.schedules.Where(x => x.DoctorID == doctorId).ToList().Where(x => x.Date.Date == date.Date);
            var AValSlots = AllSlots.Where(x => !(BusySlots.Select(z => z.Time).ToList().Contains(x.Key)));
            return AValSlots.ToArray();
        }
    }
}
