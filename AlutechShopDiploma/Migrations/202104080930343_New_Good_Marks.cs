namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_Good_Marks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GoodMarks",
                c => new
                    {
                        GoodMarksID = c.Int(nullable: false, identity: true),
                        AmountOfMarks = c.Int(nullable: false),
                        TotalMark = c.Int(nullable: false),
                        Good_GoodID = c.Int(),
                    })
                .PrimaryKey(t => t.GoodMarksID)
                .ForeignKey("dbo.Goods", t => t.Good_GoodID)
                .Index(t => t.Good_GoodID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoodMarks", "Good_GoodID", "dbo.Goods");
            DropIndex("dbo.GoodMarks", new[] { "Good_GoodID" });
            DropTable("dbo.GoodMarks");
        }
    }
}
