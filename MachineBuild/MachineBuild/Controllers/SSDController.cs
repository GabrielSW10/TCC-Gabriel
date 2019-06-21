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
    public class SSDController : Controller
    {
        private Contexto db = new Contexto();

        // GET: SSD
        public ActionResult Index()
        {
            return View(db.SSDs.ToList());
        }

        // GET: SSD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SSD sSD = db.SSDs.Find(id);
            if (sSD == null)
            {
                return HttpNotFound();
            }
            return View(sSD);
        }

        // GET: SSD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SSD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,Link")] SSD sSD)
        {
            if (ModelState.IsValid)
            {
                db.SSDs.Add(sSD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sSD);
        }

        // GET: SSD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SSD sSD = db.SSDs.Find(id);
            if (sSD == null)
            {
                return HttpNotFound();
            }
            return View(sSD);
        }

        // POST: SSD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,Link")] SSD sSD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sSD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sSD);
        }

        // GET: SSD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SSD sSD = db.SSDs.Find(id);
            if (sSD == null)
            {
                return HttpNotFound();
            }
            return View(sSD);
        }

        // POST: SSD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SSD sSD = db.SSDs.Find(id);
            db.SSDs.Remove(sSD);
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
