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
    public class PcConfigController : Controller
    {
        private Contexto db = new Contexto();

        // GET: PcConfig
        public ActionResult Index()
        {
            var configs = db.Configs.Include(p => p.CpuCooler).Include(p => p.DiscoRigido).Include(p => p.Fonte).Include(p => p.Gabinete).Include(p => p.Memoria).Include(p => p.PlacaMae).Include(p => p.PlacaVideo).Include(p => p.Processador).Include(p => p.SistemaOperacional).Include(p => p.SSD);
            return View(configs.ToList());
        }

        public JsonResult GetPlacaMaeList(int ProcessadorId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<ProcessadorPlacaMae> PlacaMaeList = db.ProcessadorPlacaMaes.Include("PlacaMae").Where(x => x.ProcessadorID == ProcessadorId).ToList();
            return Json(PlacaMaeList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFonteList(int ProcessadorId, int PlacaVideoId, int PlacaMaeId)
        {
            List<Processador> processador = db.Processadors.Where(x => x.Id == ProcessadorId).ToList();
            double ProcessadorWatts = processador.FirstOrDefault().ConsumoWatts;

            List<PlacaVideo> placaVideo = db.PlacaVideos.Where(x => x.Id == PlacaVideoId).ToList();
            double PlacaVideoWatts = placaVideo.FirstOrDefault().ConsumoWatts;

            List<PlacaMae> placaMae = db.PlacaMaes.Where(x => x.Id == PlacaMaeId).ToList();
            double PlacaMaeWatts = placaMae.FirstOrDefault().ConsumoWatts;

            db.Configuration.ProxyCreationEnabled = false;
            List<Fonte> FonteList = db.Fontes.Where(x => x.Watts >= (ProcessadorWatts + PlacaVideoWatts + PlacaMaeWatts + 150)).ToList();
            return Json(FonteList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPerformanceLol()
        {
            List<Jogo> jogoLeague = db.Jogos.Where(x => x.Nome == "League of Legends").ToList();
          //  double notaProcessadorLol = Double.Parse(jogoLeague.FirstOrDefault().ProcessadorNota);
          //  double notaPlacaVideoLol = Double.Parse(jogoLeague.FirstOrDefault().PlacaVideoNota);

            db.Configuration.ProxyCreationEnabled = false;
           // List<Fonte> FonteList = db.Fontes.Where(x => x.Watts >= (150)).ToList();
            return Json(jogoLeague, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPerformanceCs(int ProcessadorId, int PlacaVideoId)
        {
            List<Jogo> jogoCs = db.Jogos.Where(x => x.Nome == "Counter Strike").ToList();
        //    double notaProcessadorCs = Double.Parse(jogoCs.FirstOrDefault().ProcessadorNota);
        //    double notaPlacaVideoCs = Double.Parse(jogoCs.FirstOrDefault().PlacaVideoNota);

            db.Configuration.ProxyCreationEnabled = false;
        //    List<Fonte> FonteList = db.Fontes.Where(x => x.Watts >= (150)).ToList();
            return Json(jogoCs, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPerformanceBf(int ProcessadorId, int PlacaVideoId)
        {
            List<Jogo> jogoBf = db.Jogos.Where(x => x.Nome == "Battlefield 5").ToList();
        //    double notaProcessadorBf = Double.Parse(jogoBf.FirstOrDefault().ProcessadorNota);
        //    double notaPlacaVideoBf = Double.Parse(jogoBf.FirstOrDefault().PlacaVideoNota);

            db.Configuration.ProxyCreationEnabled = false;
        //    List<Fonte> FonteList = db.Fontes.Where(x => x.Watts >= (150)).ToList();
            return Json(jogoBf, JsonRequestBehavior.AllowGet);
        }

        // GET: PcConfig/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PcConfig pcConfig = db.Configs.Find(id);
            if (pcConfig == null)
            {
                return HttpNotFound();
            }
            return View(pcConfig);
        }

        // GET: PcConfig/Create
        public ActionResult Create()
        {
            ViewBag.CpuCoolerID = new SelectList(db.CpuCoolers, "Id", "Nome");
            ViewBag.DiscoRigidoID = new SelectList(db.DiscoRigidoes, "Id", "Nome");
            ViewBag.FonteID = new SelectList(db.Fontes, "Id", "Nome");
            ViewBag.GabineteID = new SelectList(db.Gabinetes, "Id", "Nome");
            ViewBag.MemoriaID = new SelectList(db.Memorias, "Id", "Nome");
            ViewBag.PlacaMaeID = new SelectList(db.PlacaMaes, "Id", "Nome");
            ViewBag.PlacaVideoID = new SelectList(db.PlacaVideos, "Id", "Nome");
            ViewBag.ProcessadorID = new SelectList(db.Processadors, "Id", "Nome");
            ViewBag.SistemaOperacionalID = new SelectList(db.SistemaOperacionals, "Id", "Nome");
            ViewBag.SSDID = new SelectList(db.SSDs, "Id", "Nome");
            return View();
        }

        // POST: PcConfig/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,ProcessadorID,PlacaMaeID,PlacaVideoID,MemoriaID,SSDID,DiscoRigidoID,GabineteID,CpuCoolerID,SistemaOperacionalID,FonteID")] PcConfig pcConfig)
        {
            if (ModelState.IsValid)
            {
                db.Configs.Add(pcConfig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CpuCoolerID = new SelectList(db.CpuCoolers, "Id", "Nome", pcConfig.CpuCoolerID);
            ViewBag.DiscoRigidoID = new SelectList(db.DiscoRigidoes, "Id", "Nome", pcConfig.DiscoRigidoID);
            ViewBag.FonteID = new SelectList(db.Fontes, "Id", "Nome", pcConfig.FonteID);
            ViewBag.GabineteID = new SelectList(db.Gabinetes, "Id", "Nome", pcConfig.GabineteID);
            ViewBag.MemoriaID = new SelectList(db.Memorias, "Id", "Nome", pcConfig.MemoriaID);
            ViewBag.PlacaMaeID = new SelectList(db.PlacaMaes, "Id", "Nome", pcConfig.PlacaMaeID);
            ViewBag.PlacaVideoID = new SelectList(db.PlacaVideos, "Id", "Nome", pcConfig.PlacaVideoID);
            ViewBag.ProcessadorID = new SelectList(db.Processadors, "Id", "Nome", pcConfig.ProcessadorID);
            ViewBag.SistemaOperacionalID = new SelectList(db.SistemaOperacionals, "Id", "Nome", pcConfig.SistemaOperacionalID);
            ViewBag.SSDID = new SelectList(db.SSDs, "Id", "Nome", pcConfig.SSDID);
            return View(pcConfig);
        }

        // GET: PcConfig/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PcConfig pcConfig = db.Configs.Find(id);
            if (pcConfig == null)
            {
                return HttpNotFound();
            }
            ViewBag.CpuCoolerID = new SelectList(db.CpuCoolers, "Id", "Nome", pcConfig.CpuCoolerID);
            ViewBag.DiscoRigidoID = new SelectList(db.DiscoRigidoes, "Id", "Nome", pcConfig.DiscoRigidoID);
            ViewBag.FonteID = new SelectList(db.Fontes, "Id", "Nome", pcConfig.FonteID);
            ViewBag.GabineteID = new SelectList(db.Gabinetes, "Id", "Nome", pcConfig.GabineteID);
            ViewBag.MemoriaID = new SelectList(db.Memorias, "Id", "Nome", pcConfig.MemoriaID);
            ViewBag.PlacaMaeID = new SelectList(db.PlacaMaes, "Id", "Nome", pcConfig.PlacaMaeID);
            ViewBag.PlacaVideoID = new SelectList(db.PlacaVideos, "Id", "Nome", pcConfig.PlacaVideoID);
            ViewBag.ProcessadorID = new SelectList(db.Processadors, "Id", "Nome", pcConfig.ProcessadorID);
            ViewBag.SistemaOperacionalID = new SelectList(db.SistemaOperacionals, "Id", "Nome", pcConfig.SistemaOperacionalID);
            ViewBag.SSDID = new SelectList(db.SSDs, "Id", "Nome", pcConfig.SSDID);
            return View(pcConfig);
        }

        // POST: PcConfig/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,ProcessadorID,PlacaMaeID,PlacaVideoID,MemoriaID,SSDID,DiscoRigidoID,GabineteID,CpuCoolerID,SistemaOperacionalID,FonteID")] PcConfig pcConfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pcConfig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CpuCoolerID = new SelectList(db.CpuCoolers, "Id", "Nome", pcConfig.CpuCoolerID);
            ViewBag.DiscoRigidoID = new SelectList(db.DiscoRigidoes, "Id", "Nome", pcConfig.DiscoRigidoID);
            ViewBag.FonteID = new SelectList(db.Fontes, "Id", "Nome", pcConfig.FonteID);
            ViewBag.GabineteID = new SelectList(db.Gabinetes, "Id", "Nome", pcConfig.GabineteID);
            ViewBag.MemoriaID = new SelectList(db.Memorias, "Id", "Nome", pcConfig.MemoriaID);
            ViewBag.PlacaMaeID = new SelectList(db.PlacaMaes, "Id", "Nome", pcConfig.PlacaMaeID);
            ViewBag.PlacaVideoID = new SelectList(db.PlacaVideos, "Id", "Nome", pcConfig.PlacaVideoID);
            ViewBag.ProcessadorID = new SelectList(db.Processadors, "Id", "Nome", pcConfig.ProcessadorID);
            ViewBag.SistemaOperacionalID = new SelectList(db.SistemaOperacionals, "Id", "Nome", pcConfig.SistemaOperacionalID);
            ViewBag.SSDID = new SelectList(db.SSDs, "Id", "Nome", pcConfig.SSDID);
            return View(pcConfig);
        }

        // GET: PcConfig/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PcConfig pcConfig = db.Configs.Find(id);
            if (pcConfig == null)
            {
                return HttpNotFound();
            }
            return View(pcConfig);
        }

        // POST: PcConfig/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PcConfig pcConfig = db.Configs.Find(id);
            db.Configs.Remove(pcConfig);
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
