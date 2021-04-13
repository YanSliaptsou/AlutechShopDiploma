namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Weight_for_rollers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RollerAndRings", "Weight", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RollerAndRings", "Weight");
        }
    }
}
