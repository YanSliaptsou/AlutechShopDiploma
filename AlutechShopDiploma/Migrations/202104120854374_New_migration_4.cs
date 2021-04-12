namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_migration_4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
        }
    }
}
