using BCMLitePortal.DAL;
using BCMLitePortal.Models;
using BCMLitePortal.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BCMLitePortal.Controllers
{
    public class QuickStartController : Controller
    {
        //public UserManager<ApplicationUser> UserManager { get; private set; }
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        private BCMLitePortalContext db = new BCMLitePortalContext(); 

        public QuickStartController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        // GET: QuickStart
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult OrganisationDetails()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> OrganisationDetails([Bind(Include = "OrganisationID,Name,Type,Industry")] Organisation organisation, string prevBtn, string nextBtn)
        {

            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {

                    //db.Organisations.Add(organisation);           
                    //await db.SaveChangesAsync();

                    db.Organisations.Add(organisation);
                    await db.SaveChangesAsync();
                    // Get the user from the user manager        
                    ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    user.OrganisationID = organisation.OrganisationID;
                    //Update OrganisationID in identity user table     
                    await UserManager.UpdateAsync(user);
                    return View("PlanDetails");

                }
            }

            return View(organisation);

        }

        public ActionResult PlanDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlanDetails([Bind(Include = "PlanID,Abbreviation,Name,Description,Type")] DefaultPlan plan)
        {
            db.DefaultPlans.Add(plan);
            db.SaveChanges();
            return View(plan);
        }

        public ActionResult Resources()
        {
            return View();
        }
    }
}