using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        HospitalDB hospitaldb = new HospitalDB();
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search(int id)
        {
            ViewBag.DoctorId = id;
            return View("Search");
        }
       
       
    }
}