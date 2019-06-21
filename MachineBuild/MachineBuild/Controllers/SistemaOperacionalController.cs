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
    public class SistemaOperacionalController : Controller
    {
        private Contexto db = new Contexto();

        // GET: SistemaOperacional
        public ActionResult Index()
        {
            return View(db.SistemaOperacionals.ToList());
        }

        // GET: SistemaOperacional/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SistemaOperacional sistemaOperacional = db.SistemaOperacionals.Find(id);
            if (sistemaOperacional == null)
            {
                return HttpNotFound();
            }
            return View(sistemaOperacional);
        }

        // GET: SistemaOperacional/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SistemaOperacional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,Link")] SistemaOperacional sistemaOperacional)
        {
            if (ModelState.IsValid)
            {
                db.SistemaOperacionals.Add(sistemaOperacional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sistemaOperacional);
        }

        // GET: SistemaOperacional/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SistemaOperacional sistemaOperacional = db.SistemaOperacionals.Find(id);
            if (sistemaOperacional == null)
            {
                return HttpNotFound();
            }
            return View(sistemaOperacional);
        }

        // POST: SistemaOperacional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,Link")] SistemaOperacional sistemaOperacional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sistemaOperacional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sistemaOperacional);
        }

        // GET: SistemaOperacional/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SistemaOperacional sistemaOperacional = db.SistemaOperacionals.Find(id);
            if (sistemaOperacional == null)
            {
                return HttpNotFound();
            }
            return View(sistemaOperacional);
        }

        // POST: SistemaOperacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SistemaOperacional sistemaOperacional = db.SistemaOperacionals.Find(id);
            db.SistemaOperacionals.Remove(sistemaOperacional);
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
