using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOSPITALMVC.Models.EntityFramework;
using HOSPITALMVC.Models;



namespace HOSPITALMVC.Controllers
{
    public class PatientController : Controller
    {
       

        db_hospitalEntities db = new db_hospitalEntities();

        // GET: Patient
        public ActionResult Index()
        {
            //var model = db.PATIENT.Where(x => x.STATUS == true).ToList();

            var model = db.PATIENT.ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult newPatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult newPatient(PATIENT patient)
        {
            //patient.STATUS = true;

            if (patient.ID==0)
            {
                db.PATIENT.Add(patient);
            }
            else
            {
                var updatePatient = db.PATIENT.Find(patient.ID);
                if (updatePatient==null)
                {
                    return HttpNotFound();
                }
                updatePatient.FIRSTNAME = patient.FIRSTNAME;
                updatePatient.LASTNAME = patient.LASTNAME;
                updatePatient.INSURANCENO = patient.INSURANCENO;
                updatePatient.PHONENUMBER = patient.PHONENUMBER;
                updatePatient.ADDRESS_ = patient.ADDRESS_;
               
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Patient");
        }

        public ActionResult Update(int id)
        {
            var model = db.PATIENT.Find(id);
            if (model == null)

                return HttpNotFound();
            
            return View("newPatient", model);
        }

        public ActionResult Delete(int id)
        {
            var deletePatient = db.PATIENT.Find(id);
            if (deletePatient == null)
                return HttpNotFound();
            db.PATIENT.Remove(deletePatient);
            db.SaveChanges();
            return RedirectToAction("Index");

           
        }
    }
}