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
    public class SpecializationController : ApiController
    {
        HospitalDB hospitalDB = new HospitalDB();
        [HttpGet]
        public List<Specialization> GetAll()
        {
            return hospitalDB.specializations.ToList();
        }
    }
}
