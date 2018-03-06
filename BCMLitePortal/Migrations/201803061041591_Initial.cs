namespace BCMLitePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "bia.Application",
                c => new
                    {
                        ApplicationID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Description = c.String(maxLength: 500),
                        RTO = c.String(maxLength: 255),
                        RTOValue = c.Int(nullable: false),
                        RPO = c.String(maxLength: 255),
                        RPOValue = c.Int(nullable: false),
                        ProcessID = c.Int(),
                    })
                .PrimaryKey(t => t.ApplicationID)
                .ForeignKey("bia.Process", t => t.ProcessID)
                .Index(t => t.ProcessID);
            
            CreateTable(
                "bia.Process",
                c => new
                    {
                        ProcessID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Description = c.String(maxLength: 500),
                        CriticalTime = c.String(maxLength: 255),
                        SOP = c.Boolean(),
                        SLA = c.Boolean(),
                        DepartmentID = c.Int(),
                        RTO = c.String(maxLength: 255),
                        RTOValue = c.Int(),
                        MBCO = c.Double(),
                        OperationalImpact = c.String(maxLength: 255),
                        OperationalImpactValue = c.Int(nullable: false),
                        FinancialImpact = c.String(maxLength: 255),
                        FinancialImpactValue = c.Int(nullable: false),
                        StaffCompliment = c.Double(),
                        StaffCompDesc = c.String(maxLength: 500),
                        RevisedOpsLevel = c.Double(),
                        RevisedOpsLevelDesc = c.String(maxLength: 500),
                        RemoteWorking = c.Boolean(),
                        SiteDependent = c.Boolean(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.ProcessID)
                .ForeignKey("dbo.Department", t => t.DepartmentID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 28),
                        Description = c.String(maxLength: 105),
                        RevenueGenerating = c.Boolean(),
                        Revenue = c.String(maxLength: 8),
                        OrganisationID = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Organisation", t => t.OrganisationID)
                .Index(t => t.OrganisationID);
            
            CreateTable(
                "bcp.DepartmentPlan",
                c => new
                    {
                        DepartmentPlanID = c.Int(nullable: false, identity: true),
                        DepartmentID = c.Int(nullable: false),
                        PlanID = c.Int(nullable: false),
                        DepartmentPlanInvoked = c.Boolean(),
                    })
                .PrimaryKey(t => t.DepartmentPlanID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("bcp.Plan", t => t.PlanID, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.PlanID);
            
            CreateTable(
                "bcp.Plan",
                c => new
                    {
                        PlanID = c.Int(nullable: false, identity: true),
                        PlanAbbreviation = c.String(maxLength: 6),
                        Name = c.String(nullable: false, maxLength: 53),
                        Description = c.String(nullable: false, maxLength: 500),
                        Type = c.String(maxLength: 11),
                    })
                .PrimaryKey(t => t.PlanID);
            
            CreateTable(
                "bcp.PlanOwner",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        DepartmentPlanID = c.Int(nullable: false),
                        PlanOwner = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.UserID, t.DepartmentPlanID })
                .ForeignKey("bcp.DepartmentPlan", t => t.DepartmentPlanID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.DepartmentPlanID);
            
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
                "bcp.Step",
                c => new
                    {
                        StepID = c.Int(nullable: false, identity: true),
                        DepartmentPlanID = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Number = c.Int(),
                        Title = c.String(maxLength: 500),
                        Summary = c.String(maxLength: 500),
                        Detail = c.String(),
                    })
                .PrimaryKey(t => t.StepID)
                .ForeignKey("bcp.DepartmentPlan", t => t.DepartmentPlanID, cascadeDelete: true)
                .Index(t => t.DepartmentPlanID);
            
            CreateTable(
                "dbo.Organisation",
                c => new
                    {
                        OrganisationID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        Type = c.String(maxLength: 10),
                        Industry = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.OrganisationID);
            
            CreateTable(
                "dbo.Incident",
                c => new
                    {
                        IncidentID = c.Int(nullable: false, identity: true),
                        Type = c.Int(),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        Location = c.String(),
                        OrganisationID = c.Int(),
                    })
                .PrimaryKey(t => t.IncidentID)
                .ForeignKey("dbo.Organisation", t => t.OrganisationID)
                .Index(t => t.OrganisationID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Designation = c.String(),
                        MediaSpokesPerson = c.Boolean(nullable: false),
                        AuthorityToInvoke = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "bia.Document",
                c => new
                    {
                        DocumentID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 500),
                        RTO = c.String(maxLength: 255),
                        RTOValue = c.Int(nullable: false),
                        ProcessID = c.Int(),
                    })
                .PrimaryKey(t => t.DocumentID)
                .ForeignKey("bia.Process", t => t.ProcessID)
                .Index(t => t.ProcessID);
            
            CreateTable(
                "bia.Equipment",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 500),
                        RTO = c.String(maxLength: 255),
                        RTOValue = c.Int(nullable: false),
                        ProcessID = c.Int(),
                    })
                .PrimaryKey(t => t.EquipmentID)
                .ForeignKey("bia.Process", t => t.ProcessID)
                .Index(t => t.ProcessID);
            
            CreateTable(
                "bia.Skill",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 255),
                        RTO = c.String(maxLength: 255),
                        RTOValue = c.Int(nullable: false),
                        ProcessID = c.Int(),
                    })
                .PrimaryKey(t => t.SkillID)
                .ForeignKey("bia.Process", t => t.ProcessID)
                .Index(t => t.ProcessID);
            
            CreateTable(
                "bia.ThirdParty",
                c => new
                    {
                        ThirdPartyID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        RTO = c.String(maxLength: 255),
                        RTOValue = c.Int(nullable: false),
                        ProcessID = c.Int(),
                    })
                .PrimaryKey(t => t.ThirdPartyID)
                .ForeignKey("bia.Process", t => t.ProcessID)
                .Index(t => t.ProcessID);
            
            CreateTable(
                "bcp.DefaultCategories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        Description = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "bcp.DefaultSteps",
                c => new
                    {
                        StepID = c.Int(nullable: false, identity: true),
                        PlanID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Number = c.Int(),
                        Title = c.String(maxLength: 500),
                        Summary = c.String(maxLength: 500),
                        Detail = c.String(),
                    })
                .PrimaryKey(t => t.StepID)
                .ForeignKey("bcp.DefaultCategories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("bcp.DefaultPlans", t => t.PlanID, cascadeDelete: true)
                .Index(t => t.PlanID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "bcp.DefaultPlans",
                c => new
                    {
                        PlanID = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(maxLength: 6),
                        Name = c.String(nullable: false, maxLength: 53),
                        Description = c.String(nullable: false, maxLength: 500),
                        Type = c.String(maxLength: 11),
                    })
                .PrimaryKey(t => t.PlanID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
