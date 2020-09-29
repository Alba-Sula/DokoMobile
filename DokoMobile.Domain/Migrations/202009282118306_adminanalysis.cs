namespace DokoMobile.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminanalysis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductClicks",
                c => new
                    {
                        ClickId = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        ClickCount = c.Long(nullable: false),
                        DateClicked = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClickId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.AspNetUsers", "RegisteredDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductClicks", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductClicks", new[] { "ProductId" });
            DropColumn("dbo.AspNetUsers", "RegisteredDay");
            DropTable("dbo.ProductClicks");
        }
    }
}
