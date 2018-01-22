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
    [RoutePrefix("api/patient")]
    public class PatientController : ApiController
    {
        HospitalDB hospitalDB = new HospitalDB();

        
        [HttpGet]
        [Route("")]
        public List<Patients> GetAll()
        {
            return hospitalDB.patients.ToList();
        }
 
        [HttpGet]
        [Route("find/{id}")]
        public Patients Find(int id)
        {
            var patient = hospitalDB.patients.Include("Disease").Where(x => x.PatientID == id).FirstOrDefault();
            return patient;
        }
        [HttpPost]
        [Route("add/{patients}")]
        public Patients ADD(Patients patients)
        {
            //Проверить можно ли так. или сделать как обычный метод с void.
            var add = hospitalDB.patients.Add(patients);
            hospitalDB.SaveChanges();
            return add;
        }
        // Каждая сущность должна находится в своем контроллере. Метод пост можно использовать так, но желательно что-то вернуть еще.
        //[HttpGet]
        //public List<Doctors> GetDoctors()
        //{
        //    return hospitalDB.doctors.ToList();
        //}

    }
}
