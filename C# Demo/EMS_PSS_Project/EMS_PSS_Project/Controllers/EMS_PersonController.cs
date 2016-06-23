/*
 * File Name : EMS_PersonController.cs
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
 * Description : The file is used to control Person in database include (display, edit, create, delete)
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
    public class EMS_PersonController : Controller
    {
        private EMS_PSS_DBContext db = new EMS_PSS_DBContext();

        // GET: EMS_Person
        public ActionResult Index()
        {
            return View(db.EMS_Person.ToList());
        }

        // GET: EMS_Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMS_Person eMS_Person = db.EMS_Person.Find(id);
            if (eMS_Person == null)
            {
                return HttpNotFound();
            }
            return View(eMS_Person);
        }

        // GET: EMS_Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EMS_Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(EMS_Person eMS_Person)
        {
            if (ModelState.IsValid)
            {
                db.EMS_Person.Add(eMS_Person);
                db.SaveChanges();
                return RedirectToAction("Create", "EMS_FullTimeEmployee", eMS_Person);
            }

            return View(eMS_Person);
        }

        // GET: EMS_Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMS_Person eMS_Person = db.EMS_Person.Find(id);
            if (eMS_Person == null)
            {
                return HttpNotFound();
            }
            return View(eMS_Person);
        }

        // POST: EMS_Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(EMS_Person eMS_Person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMS_Person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMS_Person);
        }

        // GET: EMS_Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMS_Person eMS_Person = db.EMS_Person.Find(id);
            if (eMS_Person == null)
            {
                return HttpNotFound();
            }
            return View(eMS_Person);
        }

        // POST: EMS_Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMS_Person eMS_Person = db.EMS_Person.Find(id);
            db.EMS_Person.Remove(eMS_Person);
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
