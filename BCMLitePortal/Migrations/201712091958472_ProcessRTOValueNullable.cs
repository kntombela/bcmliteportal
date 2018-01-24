namespace BCMLitePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProcessRTOValueNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("bia.Process", "RTOValue", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("bia.Process", "RTOValue", c => c.Int(nullable: false));
        }
    }
}
