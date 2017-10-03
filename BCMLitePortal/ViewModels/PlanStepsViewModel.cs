using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BCMLitePortal.Models;

namespace BCMLitePortal.ViewModels
{
    public class PlanStepsViewModel
    {
        public int DepartmentPlanID { get; set; }
        public int? Number { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Detail { get; set; }

    }
}