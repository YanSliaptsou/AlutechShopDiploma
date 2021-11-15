namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_migration_1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Purchases", "TotalSum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "TotalSum", c => c.Double(nullable: false));
        }
    }
}
