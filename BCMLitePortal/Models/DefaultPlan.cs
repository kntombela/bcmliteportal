namespace BCMLitePortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bcp.DefaultPlans")]
    public partial class DefaultPlan
    {
        [Key]
        public int PlanID { get; set; }

        [StringLength(6)]
        public string Abbreviation { get; set; }

        [Required]
        [StringLength(53)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(11)]
        public string Type { get; set; }

        public virtual ICollection<DefaultStep> DefaultSteps { get; set; }
    }
}
