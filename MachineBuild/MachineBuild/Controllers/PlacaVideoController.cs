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
    public class PlacaVideoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: PlacaVideo
        public ActionResult Index()
        {
            return View(db.PlacaVideos.ToList());
        }

        // GET: PlacaVideo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacaVideo placaVideo = db.PlacaVideos.Find(id);
            if (placaVideo == null)
            {
                return HttpNotFound();
            }
            return View(placaVideo);
        }

        // GET: PlacaVideo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlacaVideo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,NotaPerformance")] PlacaVideo placaVideo)
        {
            if (ModelState.IsValid)
            {
                db.PlacaVideos.Add(placaVideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(placaVideo);
        }

        // GET: PlacaVideo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacaVideo placaVideo = db.PlacaVideos.Find(id);
            if (placaVideo == null)
            {
                return HttpNotFound();
            }
            return View(placaVideo);
        }

        // POST: PlacaVideo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts,NotaPerformance")] PlacaVideo placaVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placaVideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(placaVideo);
        }

        // GET: PlacaVideo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlacaVideo placaVideo = db.PlacaVideos.Find(id);
            if (placaVideo == null)
            {
                return HttpNotFound();
            }
            return View(placaVideo);
        }

        // POST: PlacaVideo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlacaVideo placaVideo = db.PlacaVideos.Find(id);
            db.PlacaVideos.Remove(placaVideo);
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
