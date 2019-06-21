using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MachineBuild.Models;

namespace MachineBuild.Controllers
{
    public class GabineteController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Gabinete
        public ActionResult Index()
        {
            return View(db.Gabinetes.ToList());
        }

        // GET: Gabinete/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gabinete gabinete = db.Gabinetes.Find(id);
            if (gabinete == null)
            {
                return HttpNotFound();
            }
            return View(gabinete);
        }

        // GET: Gabinete/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gabinete/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,Link")] Gabinete gabinete)
        {
            if (ModelState.IsValid)
            {
                db.Gabinetes.Add(gabinete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gabinete);
        }

        // GET: Gabinete/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gabinete gabinete = db.Gabinetes.Find(id);
            if (gabinete == null)
            {
                return HttpNotFound();
            }
            return View(gabinete);
        }

        // POST: Gabinete/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,Link")] Gabinete gabinete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gabinete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gabinete);
        }

        // GET: Gabinete/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gabinete gabinete = db.Gabinetes.Find(id);
            if (gabinete == null)
            {
                return HttpNotFound();
            }
            return View(gabinete);
        }

        // POST: Gabinete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gabinete gabinete = db.Gabinetes.Find(id);
            db.Gabinetes.Remove(gabinete);
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
