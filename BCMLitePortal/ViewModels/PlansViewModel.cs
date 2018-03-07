using BCMLitePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCMLitePortal.ViewModels
{

    public class OrganisationPlansViewModel
    {
        public virtual IEnumerable<Organisation> Organisations { get; set; }
        public virtual IEnumerable<DepartmentPlan> Plans { get; set; }
        //public virtual IEnumerable<PlanStepsViewModel> Plans { get; set; }
    }

    public class PlansViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool? Invoked { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentID { get; set; }

    }
}