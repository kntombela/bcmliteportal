using BCMLitePortal.DAL;
using BCMLitePortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BCMLitePortal.Controllers.API
{
    public class UsersApiController : ApiController
    {
        private BCMLitePortalContext db = new BCMLitePortalContext();
        private UserManager<ApplicationUser> UserManager;
        public UsersApiController()
        {
            db.Configuration.ProxyCreationEnabled = false;
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }



        // GET api/UsersApi
        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();
            foreach (ApplicationUser user in UserManager.Users)
            {
                users.Add(new User
                {
                    UserID = user.Id,
                    Name = user.UserName

                });
            }

            return users;
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