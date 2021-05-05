namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_fields_marks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GoodMarks", "UserID", c => c.String());
            AddColumn("dbo.GoodMarks", "Mark", c => c.Double(nullable: false));
            DropColumn("dbo.GoodMarks", "AmountOfMarks");
            DropColumn("dbo.GoodMarks", "TotalMark");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GoodMarks", "TotalMark", c => c.Int(nullable: false));
            AddColumn("dbo.GoodMarks", "AmountOfMarks", c => c.Int(nullable: false));
            DropColumn("dbo.GoodMarks", "Mark");
            DropColumn("dbo.GoodMarks", "UserID");
        }
    }
}
