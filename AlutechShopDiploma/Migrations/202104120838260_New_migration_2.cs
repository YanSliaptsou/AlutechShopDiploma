namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_migration_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Good_GoodID", "dbo.Goods");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.GoodMarks", "Good_GoodID", "dbo.Goods");
            DropForeignKey("dbo.Warehouses", "Good_GoodID", "dbo.Goods");
            DropIndex("dbo.Comments", new[] { "Good_GoodID" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.GoodMarks", new[] { "Good_GoodID" });
            DropIndex("dbo.Warehouses", new[] { "Good_GoodID" });
            AddColumn("dbo.Comments", "User", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "Good", c => c.Int(nullable: false));
            AddColumn("dbo.GoodMarks", "Good", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "PuchaseID", c => c.Int(nullable: false));
            AddColumn("dbo.Warehouses", "GoodID", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "Good_GoodID");
            DropColumn("dbo.Comments", "User_Id");
            DropColumn("dbo.GoodMarks", "Good_GoodID");
            DropColumn("dbo.Warehouses", "Good_GoodID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Warehouses", "Good_GoodID", c => c.Int());
            AddColumn("dbo.GoodMarks", "Good_GoodID", c => c.Int());
            AddColumn("dbo.Comments", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Comments", "Good_GoodID", c => c.Int());
            DropColumn("dbo.Warehouses", "GoodID");
            DropColumn("dbo.Orders", "PuchaseID");
            DropColumn("dbo.GoodMarks", "Good");
            DropColumn("dbo.Comments", "Good");
            DropColumn("dbo.Comments", "User");
            CreateIndex("dbo.Warehouses", "Good_GoodID");
            CreateIndex("dbo.GoodMarks", "Good_GoodID");
            CreateIndex("dbo.Comments", "User_Id");
            CreateIndex("dbo.Comments", "Good_GoodID");
            AddForeignKey("dbo.Warehouses", "Good_GoodID", "dbo.Goods", "GoodID");
            AddForeignKey("dbo.GoodMarks", "Good_GoodID", "dbo.Goods", "GoodID");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "Good_GoodID", "dbo.Goods", "GoodID");
        }
    }
}
