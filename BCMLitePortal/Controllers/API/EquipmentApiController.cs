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
    [RoutePrefix("api/equipment")]
    public class EquipmentApiController : ApiController
    {
        //Get database context
        private BCMLitePortalContext db = new BCMLitePortalContext();

        //Handle "Self referencing loop detected for property" error
        public EquipmentApiController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/equipment?processID=1
        [ResponseType(typeof(Equipment))]
        [Route("")]
        public async Task<IHttpActionResult> getEquipmentByProcessID(int processID)
        {

            var equipment = await (from e in db.Equipments
                                   where e.ProcessID == processID
                                   select e).ToListAsync();

            if (equipment == null)
            {
                return NotFound();
            }

            return Ok(equipment);
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