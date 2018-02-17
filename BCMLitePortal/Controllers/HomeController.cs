using BCMLitePortal.DAL;
using BCMLitePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCMLitePortal.Controllers
{
    public class HomeController : Controller
    {
        BCMLitePortalContext db = new BCMLitePortalContext();
            
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.NumberOfPlans = db.DepartmentPlans.Count();
            ViewBag.NumberOfDepartments = db.Departments.Count();

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult OrganisationDetails()
        {
            //return PartialView("_OrganisationDetails", new Organisation());
            return View();
        }

        public ActionResult PlanDetails()
        {
            return View();
        }

        public ActionResult PlanResources()
        {
            return View();
        }
    }
}