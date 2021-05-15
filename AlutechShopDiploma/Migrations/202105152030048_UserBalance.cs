namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserBalance : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "bonusAmmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "bonusAmmount", c => c.Int(nullable: false));
        }
    }
}
