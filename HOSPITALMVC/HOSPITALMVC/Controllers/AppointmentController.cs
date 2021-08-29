using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOSPITALMVC.Models.EntityFramework;
using HOSPITALMVC.ViewModels;

namespace HOSPITALMVC.Controllers
{
    public class AppointmentController : Controller
    {
        //HOSPITALEntities db = new HOSPITALEntities();

        db_hospitalEntities db = new db_hospitalEntities();

        // GET: Appointment
        public ActionResult Index()
        {
            var model = db.APPOINTMENT.ToList();
            return View(model);
        }

        public ActionResult newAppoint()
        {
            var model = new AppointmentFormViewModel()
            {
                doctor = db.DOCTOR.ToList(),
                patient = db.PATIENT.ToList()
            };
            return View("newAppoint",model);
        }

        public ActionResult Save(APPOINTMENT appointment)
        {
            if (appointment.ID == 0) //ekleme işlemi
            {
                db.APPOINTMENT.Add(appointment);
            }
            else //güncelleme işlemi
            {   
                //güncelleme işlemi için her bir değer için ayrıca atama yapmaya gerek kalmadan yapılabilmesi sağlandı
                db.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var model = new AppointmentFormViewModel()
            {
                patient = db.PATIENT.ToList(),
                doctor = db.DOCTOR.ToList(),
                appointment = db.APPOINTMENT.Find(id)

            };
            return View("newAppoint",model);
        }

        public ActionResult Delete(int id)
        {
            var deleteAppoint = db.APPOINTMENT.Find(id);

            if (deleteAppoint == null)
            {
                return HttpNotFound(); 
            }

            db.APPOINTMENT.Remove(deleteAppoint);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}