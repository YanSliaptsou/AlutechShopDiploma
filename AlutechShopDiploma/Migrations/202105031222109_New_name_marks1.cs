namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_name_marks1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GoodMarks", "Mark", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GoodMarks", "Mark", c => c.Double(nullable: false));
        }
    }
}
