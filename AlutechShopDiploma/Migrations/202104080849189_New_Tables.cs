namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        Good_GoodID = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Goods", t => t.Good_GoodID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Good_GoodID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        GoodID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        TableID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GoodID);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        WarehouseID = c.Int(nullable: false, identity: true),
                        GoodAmmount = c.Int(nullable: false),
                        Good_GoodID = c.Int(),
                    })
                .PrimaryKey(t => t.WarehouseID)
                .ForeignKey("dbo.Goods", t => t.Good_GoodID)
                .Index(t => t.Good_GoodID);
            
            AddColumn("dbo.AspNetUsers", "bonusAmmount", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "isBanned", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "purchasesAmmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Warehouses", "Good_GoodID", "dbo.Goods");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Good_GoodID", "dbo.Goods");
            DropIndex("dbo.Warehouses", new[] { "Good_GoodID" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Good_GoodID" });
            DropColumn("dbo.AspNetUsers", "purchasesAmmount");
            DropColumn("dbo.AspNetUsers", "isBanned");
            DropColumn("dbo.AspNetUsers", "bonusAmmount");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Goods");
            DropTable("dbo.Comments");
        }
    }
}
