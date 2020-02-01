namespace PetGrooming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class species_updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "Notes", c => c.String());
            AlterColumn("dbo.Pets", "PetAge", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pets", "PetAge", c => c.String());
            DropColumn("dbo.Pets", "Notes");
        }
    }
}
