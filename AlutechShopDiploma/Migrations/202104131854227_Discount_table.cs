namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Discount_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountID = c.Int(nullable: false, identity: true),
                        GoodID = c.Int(nullable: false),
                        DiscountAmmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Discounts");
        }
    }
}
