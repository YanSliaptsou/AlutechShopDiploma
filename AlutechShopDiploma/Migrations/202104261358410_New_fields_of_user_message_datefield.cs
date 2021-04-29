namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_fields_of_user_message_datefield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMessages", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserMessages", "DateTime");
        }
    }
}
