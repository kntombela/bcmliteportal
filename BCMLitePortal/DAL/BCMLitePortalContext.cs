using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using BCMLitePortal.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BCMLitePortal.DAL
{

    public partial class BCMLitePortalContext : IdentityDbContext<ApplicationUser>
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
        public virtual DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Organisations)
                .WithMany(o => o.Users)
                .Map(uc => uc.ToTable("OrganisationApplicationUsers"));

            //modelBuilder.Entity<ApplicationUser>()
            //    .HasMany(u => u.Organisations)
            //    .WithMany(o => o.Users)
            //    .Map(uc =>
            //    {
            //        uc.ToTable("ApplicationUserOrganisation");
            //        uc.MapLeftKey("Id");
            //        uc.MapRightKey("OrganisationID");
            //    });

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityUserClaim>().HasKey<int>(l => l.Id).Map(c => c.ToTable("AspNetUserClaims"));
            //modelBuilder.Entity<IdentityUser>().HasKey<string>(l => l.Id).Map(c => c.ToTable("AspNetUsers"));
            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId).Map(c => c.ToTable("AspNetUserLogins"));
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id).Map(c => c.ToTable("AspNetRoles"));
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId }).Map(c => c.ToTable("AspNetUserRoles"));

            //modelBuilder.Entity<IdentityUser>().HasKey<string>(l => l.Id);
            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

        }
    }
}
