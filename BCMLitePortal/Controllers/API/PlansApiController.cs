using BCMLitePortal.DAL;
using BCMLitePortal.Models;
using BCMLitePortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Http.Description;
using System.Threading.Tasks;

namespace BCMLitePortal.Controllers.API
{
    [RoutePrefix("api/plans")]
    public class PlansApiController : ApiController
    {
        //Get database context
        private BCMLitePortalContext db = new BCMLitePortalContext();

        //Handle "Self referencing loop detected for property" error
        public PlansApiController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/organisations/1/plans
        [Route("~/api/organisations/{organisationId:int}/plans")]
        [ResponseType(typeof(PlansViewModel))]
        public async Task<IHttpActionResult> GetPlansByUserID(int organisationId)
        {

            var plans = await (from dp in db.DepartmentPlans
                               join d in db.Departments on dp.DepartmentID equals d.DepartmentID
                               join p in db.Plans on dp.PlanID equals p.PlanID
                               where d.Organisation.OrganisationID == organisationId
                               select new PlansViewModel
                               {
                                   ID = dp.DepartmentPlanID,
                                   Name = p.Name,
                                   Description = p.Description,
                                   Type = p.Type,
                                   DepartmentName = d.Name,
                                   DepartmentID = d.DepartmentID
                               }).ToListAsync();



            if (plans == null)
            {
                return NotFound();
    }

            return Ok(plans);

}

// GET api/Plan/Steps?planId=1
[ResponseType(typeof(PlanStepsViewModel))]
        [Route("Steps")]
        public async Task<IHttpActionResult> GetPlanSteps(int planId)
        {

            var steps = await (from dp in db.DepartmentPlans
                               join d in db.Departments on dp.DepartmentID equals d.DepartmentID
                               join s in db.Steps on dp.DepartmentPlanID equals s.DepartmentPlanID
                               join p in db.Plans on dp.PlanID equals p.PlanID
                               where dp.DepartmentPlanID == planId
                               select new PlanStepsViewModel
                               {
                                   DepartmentPlanID = dp.DepartmentPlanID,
                                   Number = s.Number,
                                   Title = s.Title,
                                   Summary = s.Summary,
                                   Detail = s.Detail,

                               }).ToListAsync();

            if (steps == null)
            {
                return NotFound();
            }

            return Ok(steps);

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