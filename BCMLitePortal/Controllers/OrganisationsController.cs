﻿using System;
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
    public class OrganisationsController : Controller
    {
        private BCMLitePortalContext db = new BCMLitePortalContext();

        // GET: Organisations
        public async Task<ActionResult> Index()
        {
            return View(await db.Organisations.ToListAsync());
        }

        // GET: Organisations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = await db.Organisations.FindAsync(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            return View(organisation);
        }

        // GET: Organisations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OrganisationID,Name,Type,Industry")] Organisation organisation)
        {
            if (ModelState.IsValid)
            {
                db.Organisations.Add(organisation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(organisation);
        }

        // GET: Organisations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = await db.Organisations.FindAsync(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            return View(organisation);
        }

        // POST: Organisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OrganisationID,Name,Type,Industry")] Organisation organisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organisation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(organisation);
        }

        // GET: Organisations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organisation organisation = await db.Organisations.FindAsync(id);
            if (organisation == null)
            {
                return HttpNotFound();
            }
            return View(organisation);
        }

        // POST: Organisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Organisation organisation = await db.Organisations.FindAsync(id);
            db.Organisations.Remove(organisation);
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
