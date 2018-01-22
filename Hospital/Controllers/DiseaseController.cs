using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
namespace Hospital.Controllers
{
    public class DiseaseController : Controller
    {
        HospitalDB hospitalDB = new HospitalDB();
        // GET: Disease
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Description(int id)
        {
            ViewBag.DiseaseID = id; 
            return View("Description");
        }
    }
}