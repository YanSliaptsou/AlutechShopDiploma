namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TotalSum = c.Double(nullable: false),
                        OrderTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        GoodId = c.Int(nullable: false),
                        Ammount = c.Int(nullable: false),
                        TotalSum = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID);
            
            CreateTable(
                "dbo.UserMessages",
                c => new
                    {
                        UserMessageID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MessageTopic = c.String(),
                        MessageText = c.String(),
                    })
                .PrimaryKey(t => t.UserMessageID);
            
            AlterColumn("dbo.Goods", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Goods", "Rating", c => c.Int(nullable: false));
            DropTable("dbo.UserMessages");
            DropTable("dbo.Purchases");
            DropTable("dbo.Orders");
        }
    }
}
