namespace CategoryOperation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedValidationinCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "NAME", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "NAME", c => c.String(nullable: false));
        }
    }
}
