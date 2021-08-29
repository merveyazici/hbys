using HOSPITALMVC.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOSPITALMVC.Controllers
{
    public class DoctorController : Controller
    {
        

        db_hospitalEntities db = new db_hospitalEntities();
        // GET: Doctor
        public ActionResult Index()
        {
            //var model = db.DOCTOR. Where(x=>x.STATUS==true).ToList();

            var model = db.DOCTOR.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult newDoctor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult newDoctor(DOCTOR doctor)
        {
            //doctor.STATUS = true;

            if (doctor.ID == 0)
            {
                db.DOCTOR.Add(doctor);
            }
            else
            {
                var updateDoctor = db.DOCTOR.Find(doctor.ID);

                //if (updateDoctor == null)
                //{
                //    return HttpNotFound();
                //}
                updateDoctor.FIRSTNAME = doctor.FIRSTNAME;
                updateDoctor.LASTNAME = doctor.LASTNAME;
                updateDoctor.PHONENUMBER = doctor.PHONENUMBER;
                updateDoctor.ADDRESS_ = doctor.ADDRESS_;

            }
            db.SaveChanges();
            return RedirectToAction("Index", "Doctor");
        }

        public ActionResult Update(int id)
        {
            var model = db.DOCTOR.Find(id);
            if (model == null)

                return HttpNotFound();

            return View("newDoctor", model);
        }

        public ActionResult Delete(int id)
        {
            var deleteDoctor = db.DOCTOR.Find(id);
            if (deleteDoctor == null)
                return HttpNotFound();
            db.DOCTOR.Remove(deleteDoctor);
            db.SaveChanges();
            return RedirectToAction("Index");

           
        }
    }
}