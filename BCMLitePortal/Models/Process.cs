namespace BCMLitePortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bia.Process")]
    public partial class Process
    {

        public int ProcessID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(255)]
        public string CriticalTime { get; set; }

        public bool? SOP { get; set; }

        public bool? SLA { get; set; }

        public int? DepartmentID { get; set; }

        [StringLength(255)]
        public string RTO { get; set; }

        public double? MBCO { get; set; }

        [StringLength(255)]
        public string OperationalImpact { get; set; }

        [StringLength(255)]
        public string FinancialImpact { get; set; }

        public double? StaffCompliment { get; set; }

        [StringLength(500)]
        public string StaffCompDesc { get; set; }

        public double? RevisedOpsLevel { get; set; }

        [StringLength(500)]
        public string RevisedOpsLevelDesc { get; set; }

        public bool? RemoteWorking { get; set; }

        public bool? SiteDependent { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }

        public virtual Department Department { get; set; }
      
        public virtual ICollection<Skill> Skills { get; set; }
     
        public virtual ICollection<Application> Applications { get; set; }
       
        public virtual ICollection<ThirdParty> ThirdParties { get; set; }
    }
}
