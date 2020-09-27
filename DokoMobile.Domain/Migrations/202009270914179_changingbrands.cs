namespace DokoMobile.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class changingbrands : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "CategoryId", c => c.Long(nullable: false));
            CreateIndex("dbo.Brands", "CategoryId");
            AddForeignKey("dbo.Brands", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Brands", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Brands", new[] { "CategoryId" });
            DropColumn("dbo.Brands", "CategoryId");
        }
    }
}
