namespace BCMLitePortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bcp.PlanOwner")]
    public partial class PlanOwner
    {
        [Key]
        [Column(Order = 0)]
        public string UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentPlanID { get; set; }

        [Column("PlanOwner")]
        public bool? PlanOwner1 { get; set; }

        public virtual DepartmentPlan DepartmentPlan { get; set; }

        public virtual User User { get; set; }
    }
}
