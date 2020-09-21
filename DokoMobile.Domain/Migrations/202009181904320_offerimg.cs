namespace DokoMobile.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class offerimg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OfferImgs",
                c => new
                    {
                        OfferImgID = c.Int(nullable: false, identity: true),
                        ImgPath = c.String(),
                        Price = c.Double(nullable: false),
                        BrandAndName = c.String(),
                    })
                .PrimaryKey(t => t.OfferImgID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OfferImgs");
        }
    }
}
