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
    [RoutePrefix("api/doctor")]
    public class DoctorController : ApiController
    {

        HospitalDB hospitalDB = new HospitalDB();
        [HttpGet]
        [Route("")]
        public List<Doctors> GetAll()
        {
            return hospitalDB.doctors.ToList();
        }

        [HttpGet]
        [Route("byid/{id}")]
        public Doctors SearchByID(int id)
        {
            var doctor = hospitalDB.doctors.Include("schedules").Include("Specialization").Where(x => x.DoctorID == id).FirstOrDefault();
            foreach (var x in doctor.schedules)
            {
                x.patients = hospitalDB.patients.FirstOrDefault(z => z.PatientID == x.PatientID);
                x.patients.schedules = null;
            }
            
            doctor.specialization.diseases = hospitalDB.diseases.Where(x => x.SpecializationID == doctor.SpecializationID).ToList();
            foreach (var x in doctor.specialization.diseases)
            {
                x.specialization = null;
            }
            return doctor;
        }
        [HttpGet]
        [Route("bydisease/{id}")]
        public Doctors[] GetDoctorsByDisease(int id)
        {
            var disease = hospitalDB.diseases.FirstOrDefault(z => z.DiseaseID == id);

            if (disease != null)
            {
                var doctor = hospitalDB.doctors.Where(x => x.SpecializationID == disease.SpecializationID).ToArray();
                return doctor;
            }
            return new Doctors[0];
        }
    }
}
