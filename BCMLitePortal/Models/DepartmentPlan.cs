namespace BCMLitePortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bcp.DepartmentPlan")]
    public partial class DepartmentPlan
    {

        public DepartmentPlan()
        {
            Users = new HashSet<ApplicationUser>();
        }

        public int DepartmentPlanID { get; set; }

        public int DepartmentID { get; set; }

        public int PlanID { get; set; }

        public bool? DepartmentPlanInvoked { get; set; }

        public virtual Department Department { get; set; }

        public virtual Plan Plan { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public virtual ICollection<Step> Steps { get; set; }
    }
}
