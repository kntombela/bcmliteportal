﻿using BCMLitePortal.DAL;
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

        
    }
}