namespace BCMLitePortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        
        public string UserID { get; set; }

        [Required]
        [StringLength(18)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Designation { get; set; }

        [StringLength(49)]
        public string Role { get; set; }

        [StringLength(10)]
        public string Mobile { get; set; }

        [StringLength(10)]
        public string Landline { get; set; }

        public bool MediaSpokesPerson { get; set; }

        public bool AuthorityToInvoke { get; set; }

        public int OrganisationID { get; set; }

        public virtual ICollection<PlanOwner> PlanOwners { get; set; }
    }
}
