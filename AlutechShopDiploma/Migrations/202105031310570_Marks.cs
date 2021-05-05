namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Marks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        MarkID = c.Int(nullable: false, identity: true),
                        UserMark = c.Int(nullable: false),
                        GoodID = c.Int(nullable: false),
                        UserID = c.String(),
                    })
                .PrimaryKey(t => t.MarkID);
            
            //DropTable("dbo.GoodMarks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GoodMarks",
                c => new
                    {
                        GoodMarkID = c.Int(nullable: false, identity: true),
                        GoodID = c.Int(nullable: false),
                        UserID = c.String(),
                        Mark = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GoodMarkID);
            
            DropTable("dbo.Marks");
        }
    }
}
