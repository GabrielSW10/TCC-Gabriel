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
    public class FonteController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Fonte
        public ActionResult Index()
        {
            return View(db.Fontes.ToList());
        }

        // GET: Fonte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fonte fonte = db.Fontes.Find(id);
            if (fonte == null)
            {
                return HttpNotFound();
            }
            return View(fonte);
        }

        // GET: Fonte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fonte/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,Watts,Link")] Fonte fonte)
        {
            if (ModelState.IsValid)
            {
                db.Fontes.Add(fonte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fonte);
        }

        // GET: Fonte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fonte fonte = db.Fontes.Find(id);
            if (fonte == null)
            {
                return HttpNotFound();
            }
            return View(fonte);
        }

        // POST: Fonte/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Marca,PrecoMedio,Watts,Link")] Fonte fonte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fonte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fonte);
        }

        // GET: Fonte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fonte fonte = db.Fontes.Find(id);
            if (fonte == null)
            {
                return HttpNotFound();
            }
            return View(fonte);
        }

        // POST: Fonte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fonte fonte = db.Fontes.Find(id);
            db.Fontes.Remove(fonte);
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
