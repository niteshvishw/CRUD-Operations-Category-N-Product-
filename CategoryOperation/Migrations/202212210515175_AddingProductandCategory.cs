namespace CategoryOperation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProductandCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.ID, cascadeDelete: true)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "ID" });
            DropTable("dbo.Products");
        }
    }
}
