using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BCMLitePortal.Models;

namespace BCMLitePortal.ViewModels
{
    public class PlansViewModel
    {
        public User Users { get; set; }
        public Organisation Organisations { get; set; }
        public Department Departments { get; set; }
        public Plan Plans { get; set; }
        public DepartmentPlan DepartmentPlans { get; set; }
        public Step Steps { get; set; }
        public PlanOwner PlanOwners { get; set; }
        public Process Processes { get; set; }
        //public ThirdParty ThirdParties { get; set; }
        //public Application Applications { get; set; }
        //public Equipment Equipment { get; set; }
        //public Document Documents { get; set; }
        //public Skill Skills { get; set; }

    }
}