using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BCMLitePortal.DAL;
using BCMLitePortal.Models;

namespace BCMLitePortal.Controllers
{
    public class DefaultPlansController : Controller
    {
        private BCMLitePortalContext db = new BCMLitePortalContext();

        // GET: DefaultPlans
        public async Task<ActionResult> Index()
        {
            return View(await db.DefaultPlans.ToListAsync());
        }

        // GET: DefaultPlans/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefaultPlan defaultPlan = await db.DefaultPlans.FindAsync(id);
            if (defaultPlan == null)
            {
                return HttpNotFound();
            }
            return View(defaultPlan);
        }

        // GET: DefaultPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DefaultPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PlanID,Abbreviation,Name,Description,Type")] DefaultPlan defaultPlan)
        {
            if (ModelState.IsValid)
            {
                db.DefaultPlans.Add(defaultPlan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(defaultPlan);
        }

        // GET: DefaultPlans/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefaultPlan defaultPlan = await db.DefaultPlans.FindAsync(id);
            if (defaultPlan == null)
            {
                return HttpNotFound();
            }
            return View(defaultPlan);
        }

        // POST: DefaultPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PlanID,Abbreviation,Name,Description,Type")] DefaultPlan defaultPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defaultPlan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(defaultPlan);
        }

        // GET: DefaultPlans/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefaultPlan defaultPlan = await db.DefaultPlans.FindAsync(id);
            if (defaultPlan == null)
            {
                return HttpNotFound();
            }
            return View(defaultPlan);
        }

        // POST: DefaultPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DefaultPlan defaultPlan = await db.DefaultPlans.FindAsync(id);
            db.DefaultPlans.Remove(defaultPlan);
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
