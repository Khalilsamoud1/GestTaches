using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestion_de_Taches.Models;

namespace Gestion_de_Taches.Controllers
{
    public class PERSONNEsController : Controller
    {
        private taches_dbEntities db = new taches_dbEntities();

        // GET: PERSONNEs
        public async Task<ActionResult> Index()
        {
            var pERSONNEs = db.PERSONNEs.Include(p => p.DEPARTEMENT).Include(p => p.SERVICE);
            return View(await pERSONNEs.ToListAsync());
        }

        // GET: PERSONNEs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONNE pERSONNE = await db.PERSONNEs.FindAsync(id);
            if (pERSONNE == null)
            {
                return HttpNotFound();
            }
            return View(pERSONNE);
        }

        // GET: PERSONNEs/Create
        public ActionResult Create()
        {
            ViewBag.ID_DEPARTEMENT = new SelectList(db.DEPARTEMENTs, "ID_DEPARTEMENT", "NOM_DEPARTEMENT");
            ViewBag.ID_SERV = new SelectList(db.SERVICEs, "ID_SERV", "NOM_SERVICE");
            return View();
        }

        // POST: PERSONNEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CIN,ID_DEPARTEMENT,ID_SERV,NOM,PRENOM,AGE,ADRESSE,TEL,MAIL,DATE_NAIS")] PERSONNE pERSONNE)
        {
            if (ModelState.IsValid)
            {
                db.PERSONNEs.Add(pERSONNE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DEPARTEMENT = new SelectList(db.DEPARTEMENTs, "ID_DEPARTEMENT", "NOM_DEPARTEMENT", pERSONNE.ID_DEPARTEMENT);
            ViewBag.ID_SERV = new SelectList(db.SERVICEs, "ID_SERV", "NOM_SERVICE", pERSONNE.ID_SERV);
            return View(pERSONNE);
        }

        // GET: PERSONNEs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONNE pERSONNE = await db.PERSONNEs.FindAsync(id);
            if (pERSONNE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DEPARTEMENT = new SelectList(db.DEPARTEMENTs, "ID_DEPARTEMENT", "NOM_DEPARTEMENT", pERSONNE.ID_DEPARTEMENT);
            ViewBag.ID_SERV = new SelectList(db.SERVICEs, "ID_SERV", "NOM_SERVICE", pERSONNE.ID_SERV);
            return View(pERSONNE);
        }

        // POST: PERSONNEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CIN,ID_DEPARTEMENT,ID_SERV,NOM,PRENOM,AGE,ADRESSE,TEL,MAIL,DATE_NAIS")] PERSONNE pERSONNE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERSONNE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DEPARTEMENT = new SelectList(db.DEPARTEMENTs, "ID_DEPARTEMENT", "NOM_DEPARTEMENT", pERSONNE.ID_DEPARTEMENT);
            ViewBag.ID_SERV = new SelectList(db.SERVICEs, "ID_SERV", "NOM_SERVICE", pERSONNE.ID_SERV);
            return View(pERSONNE);
        }

        // GET: PERSONNEs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONNE pERSONNE = await db.PERSONNEs.FindAsync(id);
            if (pERSONNE == null)
            {
                return HttpNotFound();
            }
            return View(pERSONNE);
        }

        // POST: PERSONNEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PERSONNE pERSONNE = await db.PERSONNEs.FindAsync(id);
            db.PERSONNEs.Remove(pERSONNE);
            await db.SaveChangesAsync();
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
