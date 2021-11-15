namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shipping_details : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        ShippingDetailID = c.Int(nullable: false, identity: true),
                        ContactName = c.String(nullable: false),
                        ContactPhone = c.String(nullable: false),
                        ContactMail = c.String(nullable: false),
                        DeliveryAdress = c.String(),
                        UserMessage = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        OrderId = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.ShippingDetailID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShippingDetails");
        }
    }
}
