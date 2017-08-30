namespace BCMLitePortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bcp.Step")]
    public partial class Step
    {
        public int StepID { get; set; }

        public int DepartmentPlanID { get; set; }

        public int Category { get; set; }

        public int? Number { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Summary { get; set; }

        public string Detail { get; set; }

        public virtual DepartmentPlan DepartmentPlan { get; set; }
    }
}
