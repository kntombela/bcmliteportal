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
    [RoutePrefix("api/applications")]
    public class ApplicationsApiController : ApiController
    {
        //Get database context
        private BCMLitePortalContext db = new BCMLitePortalContext();

        //Handle "Self referencing loop detected for property" error
        public ApplicationsApiController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }


        // GET api/applications?processID=1
        [ResponseType(typeof(Application))]
        [Route("")]
        public async Task<IHttpActionResult> getApplicationsByProcessID(int processID)
        {

            var applications = await (from a in db.Applications
                                     where a.ProcessID == processID
                                     select a).ToListAsync();

            if (applications == null)
            {
                return NotFound();
            }

            return Ok(applications);
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