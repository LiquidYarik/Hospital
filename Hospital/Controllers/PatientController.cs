using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
namespace Hospital.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        HospitalDB hospitalDB = new HospitalDB();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Find(int id)
        {
            //var patient = hospitalDB.patients.Include("Disease").Where(x => x.PatientID == id).FirstOrDefault();
            ViewBag.PatientID = id;
            ViewBag.DiseaseID = id;
            return View("Find"/*, patient*/);
        }

   

    }
}