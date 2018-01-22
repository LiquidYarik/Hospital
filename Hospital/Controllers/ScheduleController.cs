using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
using Hospital.Helpers;
namespace Hospital.Controllers
{
    public class ScheduleController : Controller
    {
        HospitalDB hospitalDB = new HospitalDB();
        // GET: Schedule
       
   

        public ActionResult Get()
        {
            return View();
        }

       

        


    }
}