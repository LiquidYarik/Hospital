using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
using System.Web.Security;

namespace Hospital.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                Patients user = null;
                using (HospitalDB db = new HospitalDB())
                {
                    user = db.patients.FirstOrDefault(u => u.Name == model.Name && u.PatientPassword == model.Password && u.Surname == model.Surname);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Patients user = null;
                using (HospitalDB db = new HospitalDB())
                {
                    user = db.patients.FirstOrDefault(u => u.Name == model.Name && u.Surname == model.Surname);
                }
                if (user == null)
                {
                    // создаем нового пользователя
                    using (HospitalDB db = new HospitalDB())
                    {
                        db.patients.Add(new Patients { Name = model.Name, PatientPassword = model.Password, Age = model.Age, Surname = model.Surname });
                        db.SaveChanges();

                        user = db.patients.Where(u => u.Name == model.Name && u.PatientPassword == model.Password && u.Surname == model.Surname).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }
        //public ActionResult Logoff()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Index", "Home");
        //}
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}