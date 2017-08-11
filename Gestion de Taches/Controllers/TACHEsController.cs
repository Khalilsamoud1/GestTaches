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
    public class TACHEsController : Controller
    {
        private taches_dbEntities db = new taches_dbEntities();

        // GET: TACHEs
        public async Task<ActionResult> Index()
        {
            var tACHEs = db.TACHEs.Include(t => t.PERSONNE);
            return View(await tACHEs.ToListAsync());
        }

        // GET: TACHEs/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TACHE tACHE = await db.TACHEs.FindAsync(id);
            if (tACHE == null)
            {
                return HttpNotFound();
            }
            return View(tACHE);
        }

        // GET: TACHEs/Create
        public ActionResult Create()
        {
            ViewBag.CIN = new SelectList(db.PERSONNEs, "CIN", "NOM");
            return View();
        }

        // POST: TACHEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_TACHE,CIN,DATE_DEBUT,DATE_FIN,DESCIPTION")] TACHE tACHE)
        {
            if (ModelState.IsValid)
            {
                db.TACHEs.Add(tACHE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CIN = new SelectList(db.PERSONNEs, "CIN", "NOM", tACHE.CIN);
            return View(tACHE);
        }

        // GET: TACHEs/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TACHE tACHE = await db.TACHEs.FindAsync(id);
            if (tACHE == null)
            {
                return HttpNotFound();
            }
            ViewBag.CIN = new SelectList(db.PERSONNEs, "CIN", "NOM", tACHE.CIN);
            return View(tACHE);
        }

        // POST: TACHEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_TACHE,CIN,DATE_DEBUT,DATE_FIN,DESCIPTION")] TACHE tACHE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tACHE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CIN = new SelectList(db.PERSONNEs, "CIN", "NOM", tACHE.CIN);
            return View(tACHE);
        }

        // GET: TACHEs/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TACHE tACHE = await db.TACHEs.FindAsync(id);
            if (tACHE == null)
            {
                return HttpNotFound();
            }
            return View(tACHE);
        }

        // POST: TACHEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            TACHE tACHE = await db.TACHEs.FindAsync(id);
            db.TACHEs.Remove(tACHE);
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
