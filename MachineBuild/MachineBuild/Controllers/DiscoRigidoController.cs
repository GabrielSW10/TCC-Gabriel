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
    public class DiscoRigidoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: DiscoRigido
        public ActionResult Index()
        {
            return View(db.DiscoRigidoes.ToList());
        }

        // GET: DiscoRigido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscoRigido discoRigido = db.DiscoRigidoes.Find(id);
            if (discoRigido == null)
            {
                return HttpNotFound();
            }
            return View(discoRigido);
        }

        // GET: DiscoRigido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiscoRigido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts")] DiscoRigido discoRigido)
        {
            if (ModelState.IsValid)
            {
                db.DiscoRigidoes.Add(discoRigido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(discoRigido);
        }

        // GET: DiscoRigido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscoRigido discoRigido = db.DiscoRigidoes.Find(id);
            if (discoRigido == null)
            {
                return HttpNotFound();
            }
            return View(discoRigido);
        }

        // POST: DiscoRigido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts")] DiscoRigido discoRigido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discoRigido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discoRigido);
        }

        // GET: DiscoRigido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscoRigido discoRigido = db.DiscoRigidoes.Find(id);
            if (discoRigido == null)
            {
                return HttpNotFound();
            }
            return View(discoRigido);
        }

        // POST: DiscoRigido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiscoRigido discoRigido = db.DiscoRigidoes.Find(id);
            db.DiscoRigidoes.Remove(discoRigido);
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
