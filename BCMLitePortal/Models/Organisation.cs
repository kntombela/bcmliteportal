namespace BCMLitePortal.Models
{
    using BCMLitePortal.DAL;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web.Mvc;

    [Table("Organisation")]
    public partial class Organisation
    {
        public Organisation()
        {
            Users = new HashSet<ApplicationUser>();
        }

        public int OrganisationID { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Type { get; set; }

        [StringLength(8)]
        public string Industry { get; set; }
 
        public virtual ICollection<Department> Departments { get; set; }

        public virtual ICollection<Incident> Incidents { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }

}
