using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using BCMLitePortal.Models;

namespace BCMLitePortal.DAL
{

    public partial class BCMLitePortalContext : DbContext
    {
        public BCMLitePortalContext()
            : base("name=BCMLitePortalContext")
        {

        }

        public virtual DbSet<DefaultCategory> DefaultCategories { get; set; }
        public virtual DbSet<DefaultPlan> DefaultPlans { get; set; }
        public virtual DbSet<DefaultStep> DefaultSteps { get; set; }
        public virtual DbSet<DepartmentPlan> DepartmentPlans { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<Step> Steps { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<ThirdParty> ThirdParties { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Organisation> Organisations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PlanOwner> PlanOwners { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
