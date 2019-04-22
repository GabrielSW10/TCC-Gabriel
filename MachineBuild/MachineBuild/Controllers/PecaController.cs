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
    public class PecaController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Peca
        public ActionResult Index()
        {
            return View(db.Pecas.ToList());
        }

        // GET: Peca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peca peca = db.Pecas.Find(id);
            if (peca == null)
            {
                return HttpNotFound();
            }
            return View(peca);
        }

        // GET: Peca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peca/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao")] Peca peca)
        {
            if (ModelState.IsValid)
            {
                db.Pecas.Add(peca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peca);
        }

        // GET: Peca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peca peca = db.Pecas.Find(id);
            if (peca == null)
            {
                return HttpNotFound();
            }
            return View(peca);
        }

        // POST: Peca/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao")] Peca peca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peca);
        }

        // GET: Peca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peca peca = db.Pecas.Find(id);
            if (peca == null)
            {
                return HttpNotFound();
            }
            return View(peca);
        }

        // POST: Peca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Peca peca = db.Pecas.Find(id);
            db.Pecas.Remove(peca);
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
