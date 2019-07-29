using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeleDocTest.Models;

namespace TeleDocTest.Controllers
{
    public class FoundersController : Controller
    {
        private OrgContext db = new OrgContext();

        // GET: Founders
        public ActionResult Index()
        {
            return View(db.FoundersList.ToList());
        }

        // GET: Founders/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Founder founder = db.FoundersList.Find(id);
            if (founder == null)
            {
                return HttpNotFound();
            }
            return View(founder);
        }

        // GET: Founders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Founders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,MiddleName")] Founder founder)
        {
            if (ModelState.IsValid)
            {
                db.FoundersList.Add(founder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(founder);
        }

        // GET: Founders/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Founder founder = db.FoundersList.Find(id);
            if (founder == null)
            {
                return HttpNotFound();
            }
            return View(founder);
        }

        // POST: Founders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,MiddleName")] Founder founder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(founder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(founder);
        }

        // GET: Founders/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Founder founder = db.FoundersList.Find(id);
            if (founder == null)
            {
                return HttpNotFound();
            }
            return View(founder);
        }

        // POST: Founders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Founder founder = db.FoundersList.Find(id);
            db.FoundersList.Remove(founder);
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
