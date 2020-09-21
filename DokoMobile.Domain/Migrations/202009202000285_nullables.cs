namespace DokoMobile.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Batery", c => c.Int());
            AlterColumn("dbo.Products", "Memory", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Memory", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Batery", c => c.Int(nullable: false));
        }
    }
}
