namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_name_marks : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.GoodMarks");
            CreateTable(
                "dbo.GoodMarks",
                c => new
                    {
                        GoodMarkID = c.Int(nullable: false, identity: true),
                        GoodID = c.Int(nullable: false),
                        UserID = c.String(),
                        Mark = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.GoodMarkID);
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GoodMarks",
                c => new
                    {
                        GoodMarksID = c.Int(nullable: false, identity: true),
                        GoodID = c.Int(nullable: false),
                        UserID = c.String(),
                        Mark = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.GoodMarksID);
            
            DropTable("dbo.GoodMarks");
        }
    }
}
