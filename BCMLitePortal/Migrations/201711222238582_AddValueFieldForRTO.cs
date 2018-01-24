namespace BCMLitePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValueFieldForRTO : DbMigration
    {
        public override void Up()
        {
            AddColumn("bia.Application", "RTOValue", c => c.Int(nullable: false));
            AddColumn("bia.Application", "RPOValue", c => c.Int(nullable: false));
            AddColumn("bia.Process", "RTOValue", c => c.Int(nullable: false));
            AddColumn("bia.Process", "OperationalImpactValue", c => c.Int(nullable: false));
            AddColumn("bia.Process", "FinancialImpactValue", c => c.Int(nullable: false));
            AddColumn("bia.Process", "Location", c => c.String());
            AddColumn("bia.Document", "RTOValue", c => c.Int(nullable: false));
            AddColumn("bia.Equipment", "RTOValue", c => c.Int(nullable: false));
            AddColumn("bia.Skill", "RTOValue", c => c.Int(nullable: false));
            AddColumn("bia.ThirdParty", "RTOValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("bia.ThirdParty", "RTOValue");
            DropColumn("bia.Skill", "RTOValue");
            DropColumn("bia.Equipment", "RTOValue");
            DropColumn("bia.Document", "RTOValue");
            DropColumn("bia.Process", "Location");
            DropColumn("bia.Process", "FinancialImpactValue");
            DropColumn("bia.Process", "OperationalImpactValue");
            DropColumn("bia.Process", "RTOValue");
            DropColumn("bia.Application", "RPOValue");
            DropColumn("bia.Application", "RTOValue");
        }
    }
}
