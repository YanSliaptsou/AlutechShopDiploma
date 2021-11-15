namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_fields_of_user_message : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMessages", "ContactName", c => c.String(nullable: false));
            AddColumn("dbo.UserMessages", "ContactPhone", c => c.String(nullable: false));
            AddColumn("dbo.UserMessages", "ContactMail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserMessages", "ContactMail");
            DropColumn("dbo.UserMessages", "ContactPhone");
            DropColumn("dbo.UserMessages", "ContactName");
        }
    }
}
