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
using BCMLitePortal.Extentions;

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
            db.Configuration.ValidateOnSaveEnabled = false;
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> OrganisationDetails([Bind(Include = "OrganisationID,Name,Type,Industry")] Organisation organisation, string prevBtn, string nextBtn)
        {

            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    //Create new organisation
                    db.Organisations.Add(organisation);
                    await db.SaveChangesAsync();
                    //TODO: Add validation for user role, (access to all organisation vs single organisation)
                    ////Get the currently logged on user 
                    ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    user.Organisations.Add(organisation);
                    await UserManager.UpdateAsync(user);
                    return View("Organogram");
                }
            }

            return View();

        }

        // GET: Organogram/Create
        public ActionResult Organogram()
        {
            //Populate OrganisationID property with recently added organisation
            //ViewBag.OrganisationID = User.Identity.GetOrganisationID();
            return View();
        }

        // POST: Organogram/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Organogram([Bind(Include = "DepartmentID,Name,Description,RevenueGenerating,Revenue,OrganisationID")] Department department, string prevBtn, string nextBtn)
        {
            var organisation = getLastAddedOrganisation();
            if (prevBtn != null)
            {
                //Open previous view loaded with the recently added organisation              
                return View("PlanDetails", organisation);
            }
            if (nextBtn != null)
            {
                //Set OrganisationID of newly created department to last added user organisation
                department.OrganisationID = organisation.OrganisationID;
                if (ModelState.IsValid)
                {
                    db.Departments.Add(department);
                    await db.SaveChangesAsync();
                    return View("PlanDetails");
                }
            }
            //The model is invalid retry adding department
            return View();
        }

        public ActionResult PlanDetails()
        {
            populateDepartmentListDropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlanDetails([Bind(Include = "PlanID,Abbreviation,Name,Description,Type")] DefaultPlan plan, string prevBtn, string nextBtn)
        {
            if (prevBtn != null)
            {
                //Return to organogram
                //Populate fields with last added department
                var department = db.Departments.Where(d => d.OrganisationID == getLastAddedOrganisation().OrganisationID).Last();
                return View("Organogram", department);
            }

            if (ModelState.IsValid)
            {
                db.DefaultPlans.Add(plan);
                db.SaveChanges();
                return View("Index");
            }
            //The model is invalid retry adding plan
            //Populate drop down list with departments of current user's organisation
            populateDepartmentListDropDown();
            return View();
        }

        public ActionResult Resources()
        {
            return View();
        }

        #region Private Methods
        private Organisation getLastAddedOrganisation()
        {
            //return db.Organisations.Include(o => o.Users.Where(u => u.Id == User.Identity.GetUserId())).Last();
            return db.Organisations.Last();
        }

        private void populateDepartmentListDropDown()
        {
            //Populate drop down list with departments of current user's organisation
            ViewBag.DepartmentID = new SelectList(db.Departments
                .Where(d => d.OrganisationID == getLastAddedOrganisation()
                .OrganisationID), "DepartmentID", "Name");
        }
        #endregion
    }
}