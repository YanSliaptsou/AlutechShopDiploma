namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SessionID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "ShopCardSessionID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItems", "ShopCardSessionID");
        }
    }
}
