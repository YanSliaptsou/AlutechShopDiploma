namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemID = c.Int(nullable: false, identity: true),
                        GoodID = c.Int(nullable: false),
                        Ammount = c.Int(nullable: false),
                        UserID = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        RestGoods = c.Int(nullable: false),
                        IsCompletedItem = c.Boolean(nullable: false),
                        ShopCardSessionID = c.String(),
                    })
                .PrimaryKey(t => t.OrderItemID);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        GoodId = c.Int(nullable: false),
                        Ammount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        TotalSum = c.Double(nullable: false),
                        OrderTime = c.DateTime(nullable: false),
                        PuchaseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            DropTable("dbo.OrderItems");
        }
    }
}
