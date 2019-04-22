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
    public class CpuCoolerController : Controller
    {
        private Contexto db = new Contexto();

        // GET: CpuCooler
        public ActionResult Index()
        {
            return View(db.CpuCoolers.ToList());
        }

        // GET: CpuCooler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CpuCooler cpuCooler = db.CpuCoolers.Find(id);
            if (cpuCooler == null)
            {
                return HttpNotFound();
            }
            return View(cpuCooler);
        }

        // GET: CpuCooler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CpuCooler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts")] CpuCooler cpuCooler)
        {
            if (ModelState.IsValid)
            {
                db.CpuCoolers.Add(cpuCooler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cpuCooler);
        }

        // GET: CpuCooler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CpuCooler cpuCooler = db.CpuCoolers.Find(id);
            if (cpuCooler == null)
            {
                return HttpNotFound();
            }
            return View(cpuCooler);
        }

        // POST: CpuCooler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,ConsumoWatts")] CpuCooler cpuCooler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cpuCooler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cpuCooler);
        }

        // GET: CpuCooler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CpuCooler cpuCooler = db.CpuCoolers.Find(id);
            if (cpuCooler == null)
            {
                return HttpNotFound();
            }
            return View(cpuCooler);
        }

        // POST: CpuCooler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CpuCooler cpuCooler = db.CpuCoolers.Find(id);
            db.CpuCoolers.Remove(cpuCooler);
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
