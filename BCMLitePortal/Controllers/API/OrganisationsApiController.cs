﻿using System;
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
using BCMLitePortal.ViewModels;
using System.Threading.Tasks;

namespace BCMLitePortal.Controllers.API
{
    [RoutePrefix("api/organisations")]
    public class OrganisationsApiController : ApiController
    {
        private BCMLitePortalContext db = new BCMLitePortalContext();

        [Route("")]
        [ResponseType(typeof(OrganisationViewModel))]
        public IHttpActionResult GetAllOrganisations()
        {
            var organisationViewModel = from o in db.Organisations
                                        select new OrganisationViewModel
                                        {
                                            Name = o.Name,
                                            Industry = o.Industry,
                                            Type = o.Type,
                                            NumberOfPlans = 0
                                        };

            if (organisationViewModel == null)
            {
                return NotFound();
            }

            return Ok(organisationViewModel);
        }


        [Route("{organisationId:int}")]
        [ResponseType(typeof(OrganisationViewModel))]
        public IHttpActionResult GetOrganisationById(int organisationId)
        {
            //Return organisation json with the number of plans created
            var organisationViewModel = (from o in db.Organisations
                                         join d in db.Departments on o.OrganisationID equals d.OrganisationID
                                         join dp in db.DepartmentPlans on d.DepartmentID equals dp.DepartmentID                                        
                                         where o.OrganisationID == organisationId
                                         group d by new
                                         {

                                             d.Organisation.Name,
                                             d.Organisation.Type,
                                             d.Organisation.Industry

                                         } into g
                                         select new OrganisationViewModel
                                         {

                                             Name = g.Key.Name,
                                             Industry = g.Key.Industry,
                                             Type = g.Key.Type,
                                             NumberOfPlans = g.Count()

                                         });

            if (organisationViewModel == null)
            {
                return NotFound();
            }

            return Ok(organisationViewModel);
        }

        // GET: api/Organisation?userID=45391346-cdf4-49e0-8d7d-5014381a6516
        //[ResponseType(typeof(OrganisationViewModel))]
        //public IHttpActionResult GetOrganisationByUserId(string userId)
        //{

        //    //Return the organisation user belongs to and the number of plans allocated to user
        //    var organisationViewModel = (from o in db.Organisations
        //                                 join d in db.Departments on o.OrganisationID equals d.OrganisationID
        //                                 join dp in db.DepartmentPlans on d.DepartmentID equals dp.DepartmentID
        //                                 join po in db.PlanOwners on dp.DepartmentPlanID equals po.DepartmentPlanID
        //                                 where po.UserID == userId
        //                                 group d by new
        //                                 {

        //                                     d.Organisation.Name,
        //                                     d.Organisation.Type,
        //                                     d.Organisation.Industry

        //                                 } into g
        //                                 select new OrganisationViewModel
        //                                 {

        //                                     Name = g.Key.Name,
        //                                     Industry = g.Key.Industry,
        //                                     Type = g.Key.Type,
        //                                     NumberOfPlans = g.Count()

        //                                 });

        //    if (organisationViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(organisationViewModel);

        //}

           
        // PUT: api/OrganisationsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrganisation(int id, Organisation organisation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organisation.OrganisationID)
            {
                return BadRequest();
            }

            db.Entry(organisation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganisationExists(id))
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

        // POST: api/organisation
        [ResponseType(typeof(Organisation))]
        public IHttpActionResult PostOrganisation(Organisation organisation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Organisations.Add(organisation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = organisation.OrganisationID }, organisation);
        }

        // DELETE: api/OrganisationsApi/5
        [ResponseType(typeof(Organisation))]
        public IHttpActionResult DeleteOrganisation(int id)
        {
            Organisation organisation = db.Organisations.Find(id);
            if (organisation == null)
            {
                return NotFound();
            }

            db.Organisations.Remove(organisation);
            db.SaveChanges();

            return Ok(organisation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganisationExists(int id)
        {
            return db.Organisations.Count(e => e.OrganisationID == id) > 0;
        }
    }
}