namespace BCMLitePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncidentTypeEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incident", "Type", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incident", "Type", c => c.Int(nullable: false));
        }
    }
}
