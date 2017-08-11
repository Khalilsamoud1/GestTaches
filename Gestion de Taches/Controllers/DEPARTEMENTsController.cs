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
    public class DEPARTEMENTsController : Controller
    {
        private taches_dbEntities db = new taches_dbEntities();

        // GET: DEPARTEMENTs
        public async Task<ActionResult> Index()
        {
            return View(await db.DEPARTEMENTs.ToListAsync());
        }

        // GET: DEPARTEMENTs/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTEMENT dEPARTEMENT = await db.DEPARTEMENTs.FindAsync(id);
            if (dEPARTEMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTEMENT);
        }

        // GET: DEPARTEMENTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DEPARTEMENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_DEPARTEMENT,NOM_DEPARTEMENT")] DEPARTEMENT dEPARTEMENT)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTEMENTs.Add(dEPARTEMENT);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dEPARTEMENT);
        }

        // GET: DEPARTEMENTs/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTEMENT dEPARTEMENT = await db.DEPARTEMENTs.FindAsync(id);
            if (dEPARTEMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTEMENT);
        }

        // POST: DEPARTEMENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_DEPARTEMENT,NOM_DEPARTEMENT")] DEPARTEMENT dEPARTEMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPARTEMENT).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dEPARTEMENT);
        }

        // GET: DEPARTEMENTs/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTEMENT dEPARTEMENT = await db.DEPARTEMENTs.FindAsync(id);
            if (dEPARTEMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTEMENT);
        }

        // POST: DEPARTEMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            DEPARTEMENT dEPARTEMENT = await db.DEPARTEMENTs.FindAsync(id);
            db.DEPARTEMENTs.Remove(dEPARTEMENT);
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
