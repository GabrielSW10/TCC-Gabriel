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
    public class JogoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Jogo
        public ActionResult Index()
        {
            var jogos = db.Jogos.Include(j => j.PcConfig);
            return View(jogos.ToList());
        }
        [HttpPost]
        public ActionResult AddImage(Jogo model, HttpPostedFileBase image1)
        {
            if (image1 != null)
            {
                model.ImageByte = new byte[image1.ContentLength];
                image1.InputStream.Read(model.ImageByte, 0, image1.ContentLength);

            }
            db.Jogos.Add(model);
            db.SaveChanges();
            return View(model);
        }

        // GET: Jogo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // GET: Jogo/Create
        public ActionResult Create()
        {
            ViewBag.PcConfigID = new SelectList(db.Configs, "Id", "Nome");
            return View();
        }

        // POST: Jogo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Desenvolvedora,ImageByte,PlacaVideoNota,ProcessadorNota,PcConfigID")] Jogo jogo, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                if (image1 != null)
                {
                    jogo.ImageByte = new byte[image1.ContentLength];
                    image1.InputStream.Read(jogo.ImageByte, 0, image1.ContentLength);

                }
                db.Jogos.Add(jogo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PcConfigID = new SelectList(db.Configs, "Id", "Nome", jogo.PcConfigID);
            return View(jogo);
        }

        // GET: Jogo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PcConfigID = new SelectList(db.Configs, "Id", "Nome", jogo.PcConfigID);
            return View(jogo);
        }

        // POST: Jogo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Desenvolvedora,ImageByte,PlacaVideoNota,ProcessadorNota,PcConfigID")] Jogo jogo, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                if (image1 != null)
                {
                    jogo.ImageByte = new byte[image1.ContentLength];
                    image1.InputStream.Read(jogo.ImageByte, 0, image1.ContentLength);

                }
                db.Entry(jogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PcConfigID = new SelectList(db.Configs, "Id", "Nome", jogo.PcConfigID);
            return View(jogo);
        }

        // GET: Jogo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Jogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogo jogo = db.Jogos.Find(id);
            db.Jogos.Remove(jogo);
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
