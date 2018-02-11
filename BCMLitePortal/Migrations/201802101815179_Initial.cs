namespace BCMLitePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("bcp.DefaultSteps", "PlanID", "bcp.DefaultPlans");
            DropForeignKey("bcp.DefaultSteps", "CategoryID", "bcp.DefaultCategories");
            DropForeignKey("bia.ThirdParty", "ProcessID", "bia.Process");
            DropForeignKey("bia.Skill", "ProcessID", "bia.Process");
            DropForeignKey("bia.Equipment", "ProcessID", "bia.Process");
            DropForeignKey("bia.Document", "ProcessID", "bia.Process");
            DropForeignKey("bia.Process", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Incident", "OrganisationID", "dbo.Organisation");
            DropForeignKey("dbo.Department", "OrganisationID", "dbo.Organisation");
            DropForeignKey("bcp.Step", "DepartmentPlanID", "bcp.DepartmentPlan");
            DropForeignKey("bcp.PlanOwner", "UserID", "dbo.User");
            DropForeignKey("bcp.PlanOwner", "DepartmentPlanID", "bcp.DepartmentPlan");
            DropForeignKey("bcp.DepartmentPlan", "PlanID", "bcp.Plan");
            DropForeignKey("bcp.DepartmentPlan", "DepartmentID", "dbo.Department");
            DropForeignKey("bia.Application", "ProcessID", "bia.Process");
            DropIndex("bcp.DefaultSteps", new[] { "CategoryID" });
            DropIndex("bcp.DefaultSteps", new[] { "PlanID" });
            DropIndex("bia.ThirdParty", new[] { "ProcessID" });
            DropIndex("bia.Skill", new[] { "ProcessID" });
            DropIndex("bia.Equipment", new[] { "ProcessID" });
            DropIndex("bia.Document", new[] { "ProcessID" });
            DropIndex("dbo.Incident", new[] { "OrganisationID" });
            DropIndex("bcp.Step", new[] { "DepartmentPlanID" });
            DropIndex("bcp.PlanOwner", new[] { "DepartmentPlanID" });
            DropIndex("bcp.PlanOwner", new[] { "UserID" });
            DropIndex("bcp.DepartmentPlan", new[] { "PlanID" });
            DropIndex("bcp.DepartmentPlan", new[] { "DepartmentID" });
            DropIndex("dbo.Department", new[] { "OrganisationID" });
            DropIndex("bia.Process", new[] { "DepartmentID" });
            DropIndex("bia.Application", new[] { "ProcessID" });
            DropTable("bcp.DefaultPlans");
            DropTable("bcp.DefaultSteps");
            DropTable("bcp.DefaultCategories");
            DropTable("bia.ThirdParty");
            DropTable("bia.Skill");
            DropTable("bia.Equipment");
            DropTable("bia.Document");
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
