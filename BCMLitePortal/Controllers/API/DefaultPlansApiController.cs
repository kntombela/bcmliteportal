using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BCMLitePortal.DAL;
using BCMLitePortal.Models;

namespace BCMLitePortal.Controllers.API
{
    public class DefaultPlansApiController : ApiController
    {
        private BCMLitePortalContext db = new BCMLitePortalContext();
        public DefaultPlansApiController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/DefaultPlansApi
        public IQueryable<DefaultPlan> GetDefaultPlans()
        {
            return db.DefaultPlans;
        }

        // GET: api/DefaultPlansApi/5
        [ResponseType(typeof(DefaultPlan))]
        public IHttpActionResult GetDefaultPlan(int id)
        {
            DefaultPlan defaultPlan = db.DefaultPlans.Find(id);
            if (defaultPlan == null)
            {
                return NotFound();
            }

            return Ok(defaultPlan);
        }

        // PUT: api/DefaultPlansApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDefaultPlan(int id, DefaultPlan defaultPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != defaultPlan.PlanID)
            {
                return BadRequest();
            }

            db.Entry(defaultPlan).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefaultPlanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DefaultPlansApi
        [ResponseType(typeof(DefaultPlan))]
        public IHttpActionResult PostDefaultPlan(DefaultPlan defaultPlan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DefaultPlans.Add(defaultPlan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = defaultPlan.PlanID }, defaultPlan);
        }

        // DELETE: api/DefaultPlansApi/5
        [ResponseType(typeof(DefaultPlan))]
        public IHttpActionResult DeleteDefaultPlan(int id)
        {
            DefaultPlan defaultPlan = db.DefaultPlans.Find(id);
            if (defaultPlan == null)
            {
                return NotFound();
            }

            db.DefaultPlans.Remove(defaultPlan);
            db.SaveChanges();

            return Ok(defaultPlan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DefaultPlanExists(int id)
        {
            return db.DefaultPlans.Count(e => e.PlanID == id) > 0;
        }
    }
}