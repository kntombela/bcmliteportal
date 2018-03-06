namespace BCMLitePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserDepartmentPlanRel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("bcp.PlanOwner", "DepartmentPlanID", "bcp.DepartmentPlan");
            DropForeignKey("bcp.PlanOwner", "UserID", "dbo.User");
            DropIndex("bcp.PlanOwner", new[] { "UserID" });
            DropIndex("bcp.PlanOwner", new[] { "DepartmentPlanID" });
            CreateTable(
                "dbo.ApplicationUserDepartmentPlan",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        DepartmentPlan_DepartmentPlanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.DepartmentPlan_DepartmentPlanID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("bcp.DepartmentPlan", t => t.DepartmentPlan_DepartmentPlanID, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.DepartmentPlan_DepartmentPlanID);
            
            DropTable("bcp.PlanOwner");
            DropTable("dbo.User");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        PasswordHash = c.String(),
                        Designation = c.String(maxLength: 100),
                        Role = c.String(maxLength: 49),
                        Mobile = c.String(maxLength: 10),
                        Landline = c.String(maxLength: 10),
                        MediaSpokesPerson = c.Boolean(nullable: false),
                        AuthorityToInvoke = c.Boolean(nullable: false),
                        OrganisationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "bcp.PlanOwner",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        DepartmentPlanID = c.Int(nullable: false),
                        PlanOwner = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.UserID, t.DepartmentPlanID });
            
            DropForeignKey("dbo.ApplicationUserDepartmentPlan", "DepartmentPlan_DepartmentPlanID", "bcp.DepartmentPlan");
            DropForeignKey("dbo.ApplicationUserDepartmentPlan", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserDepartmentPlan", new[] { "DepartmentPlan_DepartmentPlanID" });
            DropIndex("dbo.ApplicationUserDepartmentPlan", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserDepartmentPlan");
            CreateIndex("bcp.PlanOwner", "DepartmentPlanID");
            CreateIndex("bcp.PlanOwner", "UserID");
            AddForeignKey("bcp.PlanOwner", "UserID", "dbo.User", "UserID", cascadeDelete: true);
            AddForeignKey("bcp.PlanOwner", "DepartmentPlanID", "bcp.DepartmentPlan", "DepartmentPlanID", cascadeDelete: true);
        }
    }
}
