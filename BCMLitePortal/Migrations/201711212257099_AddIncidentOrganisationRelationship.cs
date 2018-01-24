namespace BCMLitePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIncidentOrganisationRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incident", "OrganisationID", c => c.Int());
            CreateIndex("dbo.Incident", "OrganisationID");
            AddForeignKey("dbo.Incident", "OrganisationID", "dbo.Organisation", "OrganisationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incident", "OrganisationID", "dbo.Organisation");
            DropIndex("dbo.Incident", new[] { "OrganisationID" });
            DropColumn("dbo.Incident", "OrganisationID");
        }
    }
}
