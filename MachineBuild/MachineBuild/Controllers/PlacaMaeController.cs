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
    public class PlacaMaeController : Controller
    {
        private Contexto db = new Contexto();

        // GET: PlacaMae
        public ActionResult Index()
        {
            return View(db.PlacaMaes.ToList());
        }

        // GET: PlacaMae/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacaMae placaMae = db.PlacaMaes.Find(id);
            if (placaMae == null)
            {
                return HttpNotFound();
            }
            return View(placaMae);
        }

        // GET: PlacaMae/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlacaMae/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,Socket,Barramento,TipoRam,FrequenciaMaxima,Link")] PlacaMae placaMae)
        {
            if (ModelState.IsValid)
            {
                db.PlacaMaes.Add(placaMae);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(placaMae);
        }

        // GET: PlacaMae/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacaMae placaMae = db.PlacaMaes.Find(id);
            if (placaMae == null)
            {
                return HttpNotFound();
            }
            return View(placaMae);
        }

        // POST: PlacaMae/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,Socket,Barramento,TipoRam,Link")] PlacaMae placaMae)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placaMae).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(placaMae);
        }

        // GET: PlacaMae/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacaMae placaMae = db.PlacaMaes.Find(id);
            if (placaMae == null)
            {
                return HttpNotFound();
            }
            return View(placaMae);
        }

        // POST: PlacaMae/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlacaMae placaMae = db.PlacaMaes.Find(id);
            db.PlacaMaes.Remove(placaMae);
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
