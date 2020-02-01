namespace PetGrooming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "PetNotes", c => c.String());
            DropColumn("dbo.Pets", "Notes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "Notes", c => c.String());
            DropColumn("dbo.Pets", "PetNotes");
        }
    }
}
