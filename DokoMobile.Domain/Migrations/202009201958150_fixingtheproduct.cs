namespace DokoMobile.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingtheproduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "SpecsId", "dbo.Specs");
            DropIndex("dbo.Products", new[] { "SpecsId" });
            AddColumn("dbo.Products", "ProductAddedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "HasDiscount", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "Display", c => c.String());
            AddColumn("dbo.Products", "RAM", c => c.String());
            AddColumn("dbo.Products", "Processor", c => c.String());
            AddColumn("dbo.Products", "Batery", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "OS", c => c.String());
            AddColumn("dbo.Products", "Memory", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "SpecsId");
            DropTable("dbo.Specs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Specs",
                c => new
                    {
                        SpecsId = c.Long(nullable: false, identity: true),
                        Display = c.String(),
                        RAM = c.String(),
                        Processor = c.String(),
                        Batery = c.Int(nullable: false),
                        OS = c.String(),
                    })
                .PrimaryKey(t => t.SpecsId);
            
            AddColumn("dbo.Products", "SpecsId", c => c.Long(nullable: false));
            DropColumn("dbo.Products", "Memory");
            DropColumn("dbo.Products", "OS");
            DropColumn("dbo.Products", "Batery");
            DropColumn("dbo.Products", "Processor");
            DropColumn("dbo.Products", "RAM");
            DropColumn("dbo.Products", "Display");
            DropColumn("dbo.Products", "HasDiscount");
            DropColumn("dbo.Products", "ProductAddedTime");
            CreateIndex("dbo.Products", "SpecsId");
            AddForeignKey("dbo.Products", "SpecsId", "dbo.Specs", "SpecsId", cascadeDelete: true);
        }
    }
}
