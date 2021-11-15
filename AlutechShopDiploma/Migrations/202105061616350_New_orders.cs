namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_orders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "OrderID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "IsFinished", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "IsOrdered", c => c.Boolean(nullable: false));
            DropColumn("dbo.OrderItems", "UserID");
            DropColumn("dbo.OrderItems", "DateTime");
            DropColumn("dbo.OrderItems", "ShopCardSessionID");
            DropColumn("dbo.Orders", "CartLines");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CartLines", c => c.String());
            AddColumn("dbo.OrderItems", "ShopCardSessionID", c => c.String());
            AddColumn("dbo.OrderItems", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.OrderItems", "UserID", c => c.String());
            DropColumn("dbo.Orders", "IsOrdered");
            DropColumn("dbo.Orders", "IsFinished");
            DropColumn("dbo.OrderItems", "OrderID");
        }
    }
}
