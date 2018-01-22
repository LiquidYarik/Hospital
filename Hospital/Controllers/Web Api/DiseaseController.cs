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
    [RoutePrefix("api/disease")]
    public class DiseaseController : ApiController
    {
        HospitalDB hospitalDB = new HospitalDB();

        [Route("")]
        [HttpGet]
        public List<Disease> GetAll()
        {
            return hospitalDB.diseases.ToList();
        }
        [Route("byid/{id}")]
        [HttpGet]
        public Disease GetByID(int id)
        {
          var disease = hospitalDB.diseases.Where(x => x.DiseaseID == id).FirstOrDefault();
          return disease;
        }
    }
}
