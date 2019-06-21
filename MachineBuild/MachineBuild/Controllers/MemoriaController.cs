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
    public class MemoriaController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Memoria
        public ActionResult Index()
        {
            return View(db.Memorias.ToList());
        }

        // GET: Memoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memoria memoria = db.Memorias.Find(id);
            if (memoria == null)
            {
                return HttpNotFound();
            }
            return View(memoria);
        }

        // GET: Memoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Memoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,TipoRam,Frequencia,Link")] Memoria memoria)
        {
            if (ModelState.IsValid)
            {
                db.Memorias.Add(memoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memoria);
        }

        // GET: Memoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memoria memoria = db.Memorias.Find(id);
            if (memoria == null)
            {
                return HttpNotFound();
            }
            return View(memoria);
        }

        // POST: Memoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,TipoRam,Link")] Memoria memoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memoria);
        }

        // GET: Memoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memoria memoria = db.Memorias.Find(id);
            if (memoria == null)
            {
                return HttpNotFound();
            }
            return View(memoria);
        }

        // POST: Memoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Memoria memoria = db.Memorias.Find(id);
            db.Memorias.Remove(memoria);
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
