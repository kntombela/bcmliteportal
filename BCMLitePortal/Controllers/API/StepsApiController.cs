using BCMLitePortal.DAL;
using BCMLitePortal.Models;
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
    [RoutePrefix("api/steps")]
    public class StepsApiController : ApiController
    {
        //Get database context
        private BCMLitePortalContext db = new BCMLitePortalContext();

        //Handle "Self referencing loop detected for property" error
        public StepsApiController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/steps?departmentPlanID=1
        [ResponseType(typeof(Step))]
        [Route("")]
        public async Task<IHttpActionResult> getStepsByDepartmentPlanID(int departmentPlanID)
        {

            var steps = await (from s in db.Steps
                                      where s.DepartmentPlanID == departmentPlanID
                                      select s).ToListAsync();

            if (steps == null)
            {
                return NotFound();
            }

            return Ok(steps);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}