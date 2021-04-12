namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_migration_6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserMessages", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserMessages", "UserId", c => c.Int(nullable: false));
        }
    }
}
