using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TeleDocTest.Models;

namespace TeleDocTest.Controllers
{
    public class OrganizationsController : Controller
    {
        private OrgContext db = new OrgContext();

        // GET: Organizations
        public ActionResult Index()
        {
            return View(db.Organizations.ToList());
        }

        // GET: Organizations/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            ViewBag.FounderIds = new SelectList(db.FoundersList, "Id", "FullInfo");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Title");
            return View();
        }

        // POST: Organizations/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Inn")] Organization organization, [Bind(Include = "Id,OrganizationId,FounderId,FounderIds")] FounderItem founderItem)
        {
            if (ModelState.IsValid)
            {
                db.Organizations.Add(organization);
                db.SaveChanges();
                if (founderItem.FounderIds != null)
                {
                    try
                    {
                        foreach (var id in founderItem.FounderIds)
                        {
                            founderItem.FounderId = id;
                            founderItem.OrganizationId = organization.Id;
                            db.FoundersItems.Add(founderItem);
                            db.SaveChanges();
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine(e);
                    }
                }
                return RedirectToAction("Index");
            }

            ViewBag.FounderIds = new SelectList(db.FoundersList, "Id", "FullInfo", founderItem.FounderIds);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Title", founderItem.OrganizationId);

            return View(organization);
        }

        // GET: Organizations1/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations1/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Inn")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Organization organization = db.Organizations.Find(id);
            db.Organizations.Remove(organization);
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
