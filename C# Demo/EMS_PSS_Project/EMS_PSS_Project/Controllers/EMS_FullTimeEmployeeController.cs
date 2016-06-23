/*
 * File Name : EMS_FullTimeEmployeeController.cs
 * 
 * Project : INFO2030 - EMS PSS Project
 * 
 * Programmer : Lingchen Meng (Walter) / 6818678 
 *              Xuan Zhang / 5283460 
 *              Geun Young Gil / 6944920 
 *              Markus Rankin / 3379187
 *              
 * First Verson : 2016-04-21
 * 
 * Description : The file is used to control full-time employee in database include (display, edit, create, delete)
 */


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS_PSS_Project.DAL;
using EMS_PSS_Project.Models;

namespace EMS_PSS_Project.Controllers
{
    public class EMS_FullTimeEmployeeController : Controller
    {
        private EMS_PSS_DBContext db = new EMS_PSS_DBContext();

        // GET: EMS_FullTimeEmployee
        public ActionResult Index()
        {
            var eMS_Fulltime = db.EMS_Fulltime.Include(e => e.Company).Include(e => e.Person);
            return View(eMS_Fulltime.ToList());
        }



        // GET: EMS_FullTimeEmployee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMS_FullTimeEmployee eMS_FullTimeEmployee = db.EMS_Fulltime.Find(id);
            if (eMS_FullTimeEmployee == null)
            {
                return HttpNotFound();
            }
            return View(eMS_FullTimeEmployee);
        }

        // GET: EMS_FullTimeEmployee/Create
        public ActionResult Create()
        {
            ViewBag.Company_ID = new SelectList(db.EMS_Company, "Company_ID", "CompanyDescription");
            ViewBag.Person_ID = new SelectList(db.EMS_Person, "Person_ID", "First_Name");
            return View();
        }

        // POST: EMS_FullTimeEmployee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(EMS_FullTimeEmployee eMS_FullTimeEmployee)
        {
            if (ModelState.IsValid)
            {
                db.EMS_Fulltime.Add(eMS_FullTimeEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Company_ID = new SelectList(db.EMS_Company, "Company_ID", "CompanyDescription", eMS_FullTimeEmployee.Company_ID);
            ViewBag.Person_ID = new SelectList(db.EMS_Person, "Person_ID", "First_Name", eMS_FullTimeEmployee.Person_ID);
            return View(eMS_FullTimeEmployee);
        }

        // GET: EMS_FullTimeEmployee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMS_FullTimeEmployee eMS_FullTimeEmployee = db.EMS_Fulltime.Find(id);
            if (eMS_FullTimeEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company_ID = new SelectList(db.EMS_Company, "Company_ID", "CompanyDescription", eMS_FullTimeEmployee.Company_ID);
            ViewBag.Person_ID = new SelectList(db.EMS_Person, "Person_ID", "First_Name", eMS_FullTimeEmployee.Person_ID);
            return View(eMS_FullTimeEmployee);
        }

        // POST: EMS_FullTimeEmployee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Fulltime_Employee_ID,Person_ID,Company_ID,Date_Of_Hire,Date_Of_Termination,Reason_For_Leaving,Salary,Status,Completion")] EMS_FullTimeEmployee eMS_FullTimeEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMS_FullTimeEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company_ID = new SelectList(db.EMS_Company, "Company_ID", "CompanyDescription", eMS_FullTimeEmployee.Company_ID);
            ViewBag.Person_ID = new SelectList(db.EMS_Person, "Person_ID", "First_Name", eMS_FullTimeEmployee.Person_ID);
            return View(eMS_FullTimeEmployee);
        }

        // GET: EMS_FullTimeEmployee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMS_FullTimeEmployee eMS_FullTimeEmployee = db.EMS_Fulltime.Find(id);
            if (eMS_FullTimeEmployee == null)
            {
                return HttpNotFound();
            }
            return View(eMS_FullTimeEmployee);
        }

        // POST: EMS_FullTimeEmployee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMS_FullTimeEmployee eMS_FullTimeEmployee = db.EMS_Fulltime.Find(id);
            db.EMS_Fulltime.Remove(eMS_FullTimeEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
