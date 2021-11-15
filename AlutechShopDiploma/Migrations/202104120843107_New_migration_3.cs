namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_migration_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "GoodID", c => c.Int(nullable: false));
            AddColumn("dbo.GoodMarks", "GoodID", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "User");
            DropColumn("dbo.Comments", "Good");
            DropColumn("dbo.GoodMarks", "Good");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GoodMarks", "Good", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "Good", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "User", c => c.Int(nullable: false));
            DropColumn("dbo.GoodMarks", "GoodID");
            DropColumn("dbo.Comments", "GoodID");
            DropColumn("dbo.Comments", "UserID");
        }
    }
}
