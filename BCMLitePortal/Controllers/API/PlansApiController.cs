using BCMLitePortal.DAL;
using BCMLitePortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCMLitePortal.Controllers.API
{
    public class PlansApiController : ApiController
    {
        private BCMLitePortalContext db = new BCMLitePortalContext();
        public PlansApiController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/PlansApi
        public IQueryable<PlansViewModel> GetPlans()
        {
            return from u in db.Users
                   join po in db.PlanOwners on u.UserID equals po.UserID
                   join dp in db.DepartmentPlans on po.DepartmentPlanID equals dp.DepartmentPlanID
                   join s in db.Steps on dp.DepartmentPlanID equals s.DepartmentPlanID
                   join p in db.Plans on dp.PlanID equals p.PlanID
                   join d in db.Departments on dp.DepartmentID equals d.DepartmentID
                   join o in db.Organisations on d.OrganisationID equals o.OrganisationID
                   join p2 in db.Processes on d.DepartmentID equals p2.DepartmentID
                   select new PlansViewModel
                   {
                       Users = u,
                       PlanOwners = po,
                       DepartmentPlans = dp,
                       Steps = s,
                       Plans = p,
                       Departments = d,
                       Organisations = o,
                       Processes = p2
                   };







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