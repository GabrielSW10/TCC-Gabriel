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
    public class ProcessadorController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Processador
        public ActionResult Index()
        {
            return View(db.Processadors.ToList());
        }

        // GET: Processador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processador processador = db.Processadors.Find(id);
            if (processador == null)
            {
                return HttpNotFound();
            }
            return View(processador);
        }

        // GET: Processador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Processador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,NotaPerformance,Socket,Link")] Processador processador)
        {
            if (ModelState.IsValid)
            {
                db.Processadors.Add(processador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(processador);
        }

        // GET: Processador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processador processador = db.Processadors.Find(id);
            if (processador == null)
            {
                return HttpNotFound();
            }
            return View(processador);
        }

        // POST: Processador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,NotaPerformance,Socket,Link")] Processador processador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(processador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processador);
        }

        // GET: Processador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processador processador = db.Processadors.Find(id);
            if (processador == null)
            {
                return HttpNotFound();
            }
            return View(processador);
        }

        // POST: Processador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Processador processador = db.Processadors.Find(id);
            db.Processadors.Remove(processador);
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
