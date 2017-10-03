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
    [RoutePrefix("api/thirdParties")]
    public class ThirdPartiesApiController : ApiController
    {
        //Get database context
        private BCMLitePortalContext db = new BCMLitePortalContext();

        //Handle "Self referencing loop detected for property" error
        public ThirdPartiesApiController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/thirdParties?processID=1
        [ResponseType(typeof(ThirdParty))]
        [Route("")]
        public async Task<IHttpActionResult> getThirdPartiesByProcessID(int processID)
        {

            var thirdParties = await (from t in db.ThirdParties
                                where t.ProcessID == processID
                                select t).ToListAsync();

            if (thirdParties == null)
            {
                return NotFound();
            }

            return Ok(thirdParties);
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