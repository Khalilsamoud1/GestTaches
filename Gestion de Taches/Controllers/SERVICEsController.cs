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
    public class SERVICEsController : Controller
    {
        private taches_dbEntities db = new taches_dbEntities();

        // GET: SERVICEs
        public async Task<ActionResult> Index()
        {
            return View(await db.SERVICEs.ToListAsync());
        }

        // GET: SERVICEs/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICE sERVICE = await db.SERVICEs.FindAsync(id);
            if (sERVICE == null)
            {
                return HttpNotFound();
            }
            return View(sERVICE);
        }

        // GET: SERVICEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SERVICEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_SERV,NOM_SERVICE")] SERVICE sERVICE)
        {
            if (ModelState.IsValid)
            {
                db.SERVICEs.Add(sERVICE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sERVICE);
        }

        // GET: SERVICEs/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICE sERVICE = await db.SERVICEs.FindAsync(id);
            if (sERVICE == null)
            {
                return HttpNotFound();
            }
            return View(sERVICE);
        }

        // POST: SERVICEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_SERV,NOM_SERVICE")] SERVICE sERVICE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sERVICE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sERVICE);
        }

        // GET: SERVICEs/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICE sERVICE = await db.SERVICEs.FindAsync(id);
            if (sERVICE == null)
            {
                return HttpNotFound();
            }
            return View(sERVICE);
        }

        // POST: SERVICEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            SERVICE sERVICE = await db.SERVICEs.FindAsync(id);
            db.SERVICEs.Remove(sERVICE);
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
