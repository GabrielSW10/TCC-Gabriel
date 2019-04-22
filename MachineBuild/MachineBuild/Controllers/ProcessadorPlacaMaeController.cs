using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MachineBuild.Models;
using MachineBuild.Models.Pecas;

namespace MachineBuild.Controllers
{
    public class ProcessadorPlacaMaeController : Controller
    {
        private Contexto db = new Contexto();

        // GET: ProcessadorPlacaMae
        public ActionResult Index()
        {
            var processadorPlacaMaes = db.ProcessadorPlacaMaes.Include(p => p.PlacaMae).Include(p => p.Processador);
            return View(processadorPlacaMaes.ToList());
        }

        // GET: ProcessadorPlacaMae/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessadorPlacaMae processadorPlacaMae = db.ProcessadorPlacaMaes.Find(id);
            if (processadorPlacaMae == null)
            {
                return HttpNotFound();
            }
            return View(processadorPlacaMae);
        }

        // GET: ProcessadorPlacaMae/Create
        public ActionResult Create()
        {
            ViewBag.PlacaMaeID = new SelectList(db.PlacaMaes, "Id", "Nome");
            ViewBag.ProcessadorID = new SelectList(db.Processadors, "Id", "Nome");
            return View();
        }

        // POST: ProcessadorPlacaMae/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProcessadorID,PlacaMaeID")] ProcessadorPlacaMae processadorPlacaMae)
        {
            if (ModelState.IsValid)
            {
                db.ProcessadorPlacaMaes.Add(processadorPlacaMae);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlacaMaeID = new SelectList(db.PlacaMaes, "Id", "Nome", processadorPlacaMae.PlacaMaeID);
            ViewBag.ProcessadorID = new SelectList(db.Processadors, "Id", "Nome", processadorPlacaMae.ProcessadorID);
            return View(processadorPlacaMae);
        }

        // GET: ProcessadorPlacaMae/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessadorPlacaMae processadorPlacaMae = db.ProcessadorPlacaMaes.Find(id);
            if (processadorPlacaMae == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlacaMaeID = new SelectList(db.PlacaMaes, "Id", "Nome", processadorPlacaMae.PlacaMaeID);
            ViewBag.ProcessadorID = new SelectList(db.Processadors, "Id", "Nome", processadorPlacaMae.ProcessadorID);
            return View(processadorPlacaMae);
        }

        // POST: ProcessadorPlacaMae/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProcessadorID,PlacaMaeID")] ProcessadorPlacaMae processadorPlacaMae)
        {
            if (ModelState.IsValid)
            {
                db.Entry(processadorPlacaMae).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlacaMaeID = new SelectList(db.PlacaMaes, "Id", "Nome", processadorPlacaMae.PlacaMaeID);
            ViewBag.ProcessadorID = new SelectList(db.Processadors, "Id", "Nome", processadorPlacaMae.ProcessadorID);
            return View(processadorPlacaMae);
        }

        // GET: ProcessadorPlacaMae/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessadorPlacaMae processadorPlacaMae = db.ProcessadorPlacaMaes.Find(id);
            if (processadorPlacaMae == null)
            {
                return HttpNotFound();
            }
            return View(processadorPlacaMae);
        }

        // POST: ProcessadorPlacaMae/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProcessadorPlacaMae processadorPlacaMae = db.ProcessadorPlacaMaes.Find(id);
            db.ProcessadorPlacaMaes.Remove(processadorPlacaMae);
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
