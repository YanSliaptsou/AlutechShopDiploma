namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Finalversion : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Subcategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        SubcategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubcategoryID);
            
            AlterColumn("dbo.UserMessages", "MessageText", c => c.String());
        }
    }
}
