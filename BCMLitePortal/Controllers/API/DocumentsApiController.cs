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
    [RoutePrefix("api/documents")]
    public class DocumentsApiController : ApiController
    {
        //Get database context
        private BCMLitePortalContext db = new BCMLitePortalContext();

        //Handle "Self referencing loop detected for property" error
        public DocumentsApiController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/documents?processID=1
        [ResponseType(typeof(Document))]
        [Route("")]
        public async Task<IHttpActionResult> getDocumentsByProcessID(int processID)
        {

            var documents = await (from d in db.Documents
                                      where d.ProcessID == processID
                                      select d).ToListAsync();

            if (documents == null)
            {
                return NotFound();
            }

            return Ok(documents);
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