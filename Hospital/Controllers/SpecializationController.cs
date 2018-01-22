using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
namespace Hospital.Controllers
{
    public class SpecializationController : Controller
    {
        HospitalDB hospitalDB = new HospitalDB();
        // GET: Specialization
        public ActionResult Index()
        {
            return View();
        }

    }
}