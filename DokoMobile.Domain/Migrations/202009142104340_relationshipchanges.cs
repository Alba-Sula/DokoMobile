namespace DokoMobile.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationshipchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Brands_BrandId", "dbo.Brands");
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "Specs_SpecsId", "dbo.Specs");
            DropIndex("dbo.Products", new[] { "Brands_BrandId" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropIndex("dbo.Products", new[] { "Specs_SpecsId" });
            DropColumn("dbo.Products", "SpecsId");
            RenameColumn(table: "dbo.Products", name: "Brands_BrandId", newName: "BrandId");
            RenameColumn(table: "dbo.Products", name: "Category_CategoryId", newName: "CategoryId");
            RenameColumn(table: "dbo.Products", name: "Specs_SpecsId", newName: "SpecsId");
            AlterColumn("dbo.Products", "SpecsId", c => c.Long(nullable: false));
            AlterColumn("dbo.Products", "BrandId", c => c.Long(nullable: false));
            AlterColumn("dbo.Products", "CategoryId", c => c.Long(nullable: false));
            AlterColumn("dbo.Products", "SpecsId", c => c.Long(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Products", "BrandId");
            CreateIndex("dbo.Products", "SpecsId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "BrandId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "SpecsId", "dbo.Specs", "SpecsId", cascadeDelete: true);
            DropColumn("dbo.Products", "CategoriesId");
            DropColumn("dbo.Products", "BrandsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "BrandsId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "CategoriesId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "SpecsId", "dbo.Specs");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "SpecsId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Products", "SpecsId", c => c.Long());
            AlterColumn("dbo.Products", "CategoryId", c => c.Long());
            AlterColumn("dbo.Products", "BrandId", c => c.Long());
            AlterColumn("dbo.Products", "SpecsId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Products", name: "SpecsId", newName: "Specs_SpecsId");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_CategoryId");
            RenameColumn(table: "dbo.Products", name: "BrandId", newName: "Brands_BrandId");
            AddColumn("dbo.Products", "SpecsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Specs_SpecsId");
            CreateIndex("dbo.Products", "Category_CategoryId");
            CreateIndex("dbo.Products", "Brands_BrandId");
            AddForeignKey("dbo.Products", "Specs_SpecsId", "dbo.Specs", "SpecsId");
            AddForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories", "CategoryId");
            AddForeignKey("dbo.Products", "Brands_BrandId", "dbo.Brands", "BrandId");
        }
    }
}
