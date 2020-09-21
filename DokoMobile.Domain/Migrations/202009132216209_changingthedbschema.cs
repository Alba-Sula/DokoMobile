namespace DokoMobile.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingthedbschema : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Details_DetailsId", "dbo.Details");
            DropIndex("dbo.Products", new[] { "Details_DetailsId" });
            AddColumn("dbo.Products", "YearOfProduction", c => c.DateTime());
            AddColumn("dbo.Products", "ProductCondition", c => c.String());
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Color", c => c.String());
            AddColumn("dbo.Products", "Description", c => c.String());
            DropColumn("dbo.Products", "DetailsId");
            DropColumn("dbo.Products", "Details_DetailsId");
            DropTable("dbo.Details");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        DetailsId = c.Long(nullable: false, identity: true),
                        YearOfProduction = c.DateTime(),
                        ProductCondition = c.String(),
                        Price = c.Double(nullable: false),
                        Color = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DetailsId);
            
            AddColumn("dbo.Products", "Details_DetailsId", c => c.Long());
            AddColumn("dbo.Products", "DetailsId", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "Color");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "ProductCondition");
            DropColumn("dbo.Products", "YearOfProduction");
            CreateIndex("dbo.Products", "Details_DetailsId");
            AddForeignKey("dbo.Products", "Details_DetailsId", "dbo.Details", "DetailsId");
        }
    }
}
