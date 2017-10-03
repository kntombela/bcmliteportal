using BCMLitePortal.DAL;
using BCMLitePortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace BCMLitePortal.Controllers.API
{
    [RoutePrefix("api/processes")]
    public class ProcessesApiController : ApiController
    {
        //Get database context
        private BCMLitePortalContext db = new BCMLitePortalContext();

        //Handle "Self referencing loop detected for property" error
        public ProcessesApiController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/processes?planID=1
        [ResponseType(typeof(ProcessViewModel))]
        [Route("")]
        public async Task<IHttpActionResult> getProcessesByPlanID(int planID)
        {

            var processes = await (from p in db.Processes
                                   where  p.DepartmentID == planID
                                   select new ProcessViewModel
                                   {
                                       ProcessID = p.ProcessID,
                                       Name = p.Name,
                                       Description = p.Description,
                                       CriticalTime = p.CriticalTime,
                                       SOP = p.SOP,
                                       SLA = p.SLA,
                                       DepartmentID = p.DepartmentID,
                                       RTO = p.RTO,
                                       MBCO = p.MBCO,
                                       OperationalImpact = p.OperationalImpact,
                                       FinancialImpact = p.FinancialImpact,
                                       StaffCompliment = p.StaffCompliment,
                                       StaffCompDesc = p.StaffCompDesc,
                                       RevisedOpsLevel = p.RevisedOpsLevel,
                                       RevisedOpsLevelDesc = p.RevisedOpsLevelDesc,
                                       RemoteWorking = p.RemoteWorking,
                                       SiteDependent = p.SiteDependent
                                   }).ToListAsync();

            if (processes == null)
            {
                return NotFound();
            }

            return Ok(processes);
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