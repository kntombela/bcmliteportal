using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BCMLitePortal.DAL;
using BCMLitePortal.Models;

namespace BCMLitePortal.Controllers.API
{
    [RoutePrefix("api/incidents")]
    public class IncidentsApiController : ApiController
    {
        private BCMLitePortalContext db = new BCMLitePortalContext();

        //Handle "Self referencing loop detected for property" error
        public IncidentsApiController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/organisations/1/incidents
        [Route("~/api/organisations/{organisationId:int}/incidents")]
        public IQueryable<Incident> GetIncidents(int organisationId)
        {
            return db.Incidents.Where(i => i.OrganisationID == organisationId);
        }

        // GET: api/incidents/1/details
        [Route("{id:int}/details")]
        [ResponseType(typeof(Incident))]
        public async Task<IHttpActionResult> GetIncident(int id)
        {

            //Get the details of an incident from a particular organisation
            var incident = await (from i in db.Incidents
                                  join o in db.Organisations
                                  on i.OrganisationID equals o.OrganisationID
                                  where i.IncidentID == id
                                  select i).FirstOrDefaultAsync();

            //Incident incident = await db.Incidents.FindAsync(id);

            if (incident == null)
            {
                return NotFound();
            }

            return Ok(incident);
        }

        // PUT: api/incidents/1
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIncident(int id, Incident incident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != incident.IncidentID)
            {
                return BadRequest();
            }

            db.Entry(incident).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentExists(id))
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

        // POST:api/organisations/1/incidents
        [Route("~/api/organisations/{organisationId:int}/incidents")]
        [HttpPost]
        //[ResponseType(typeof(Incident))]
        public async Task<IHttpActionResult> PostIncident(Incident incident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Incidents.Add(incident);
            await db.SaveChangesAsync();

            return Ok();

            //return CreatedAtRoute("DefaultApi", new { id = incident.IncidentID }, incident);
        }

        // DELETE: api/incidents/1
        [Route("{id:int}")]
        [ResponseType(typeof(Incident))]
        public async Task<IHttpActionResult> DeleteIncident(int id)
        {
            Incident incident = await db.Incidents.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }

            db.Incidents.Remove(incident);
            await db.SaveChangesAsync();

            return Ok(incident);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IncidentExists(int id)
        {
            return db.Incidents.Count(e => e.IncidentID == id) > 0;
        }

    }
}