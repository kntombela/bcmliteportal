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
    [RoutePrefix("api/skills")]
    public class SkillsApiController : ApiController
    {
        //Get database context
        private BCMLitePortalContext db = new BCMLitePortalContext();

        //Handle "Self referencing loop detected for property" error
        public SkillsApiController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/skills?processID=1
        [ResponseType(typeof(Skill))]
        [Route("")]
        public async Task<IHttpActionResult> getEquipmentByProcessID(int processID)
        {

            var skills = await (from s in db.Skills
                                   where s.ProcessID == processID
                                   select s).ToListAsync();

            if (skills == null)
            {
                return NotFound();
            }

            return Ok(skills);
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