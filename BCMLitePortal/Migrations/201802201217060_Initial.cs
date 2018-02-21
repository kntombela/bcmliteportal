namespace BCMLitePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
                        
            CreateTable(
                "dbo.OrganisationApplicationUsers",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Organisation_OrganisationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Organisation_OrganisationID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Organisation", t => t.Organisation_OrganisationID, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Organisation_OrganisationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("bcp.DefaultSteps", "PlanID", "bcp.DefaultPlans");
            DropForeignKey("bcp.DefaultSteps", "CategoryID", "bcp.DefaultCategories");
            DropForeignKey("bia.ThirdParty", "ProcessID", "bia.Process");
            DropForeignKey("bia.Skill", "ProcessID", "bia.Process");
            DropForeignKey("bia.Equipment", "ProcessID", "bia.Process");
            DropForeignKey("bia.Document", "ProcessID", "bia.Process");
            DropForeignKey("bia.Process", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrganisationApplicationUsers", "Organisation_OrganisationID", "dbo.Organisation");
            DropForeignKey("dbo.OrganisationApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Incident", "OrganisationID", "dbo.Organisation");
            DropForeignKey("dbo.Department", "OrganisationID", "dbo.Organisation");
            DropForeignKey("bcp.Step", "DepartmentPlanID", "bcp.DepartmentPlan");
            DropForeignKey("bcp.PlanOwner", "UserID", "dbo.User");
            DropForeignKey("bcp.PlanOwner", "DepartmentPlanID", "bcp.DepartmentPlan");
            DropForeignKey("bcp.DepartmentPlan", "PlanID", "bcp.Plan");
            DropForeignKey("bcp.DepartmentPlan", "DepartmentID", "dbo.Department");
            DropForeignKey("bia.Application", "ProcessID", "bia.Process");
            DropIndex("dbo.OrganisationApplicationUsers", new[] { "Organisation_OrganisationID" });
            DropIndex("dbo.OrganisationApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("bcp.DefaultSteps", new[] { "CategoryID" });
            DropIndex("bcp.DefaultSteps", new[] { "PlanID" });
            DropIndex("bia.ThirdParty", new[] { "ProcessID" });
            DropIndex("bia.Skill", new[] { "ProcessID" });
            DropIndex("bia.Equipment", new[] { "ProcessID" });
            DropIndex("bia.Document", new[] { "ProcessID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Incident", new[] { "OrganisationID" });
            DropIndex("bcp.Step", new[] { "DepartmentPlanID" });
            DropIndex("bcp.PlanOwner", new[] { "DepartmentPlanID" });
            DropIndex("bcp.PlanOwner", new[] { "UserID" });
            DropIndex("bcp.DepartmentPlan", new[] { "PlanID" });
            DropIndex("bcp.DepartmentPlan", new[] { "DepartmentID" });
            DropIndex("dbo.Department", new[] { "OrganisationID" });
            DropIndex("bia.Process", new[] { "DepartmentID" });
            DropIndex("bia.Application", new[] { "ProcessID" });
            DropTable("dbo.OrganisationApplicationUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("bcp.DefaultPlans");
            DropTable("bcp.DefaultSteps");
            DropTable("bcp.DefaultCategories");
            DropTable("bia.ThirdParty");
            DropTable("bia.Skill");
            DropTable("bia.Equipment");
            DropTable("bia.Document");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Incident");
            DropTable("dbo.Organisation");
            DropTable("bcp.Step");
            DropTable("dbo.User");
            DropTable("bcp.PlanOwner");
            DropTable("bcp.Plan");
            DropTable("bcp.DepartmentPlan");
            DropTable("dbo.Department");
            DropTable("bia.Process");
            DropTable("bia.Application");
        }
    }
}
