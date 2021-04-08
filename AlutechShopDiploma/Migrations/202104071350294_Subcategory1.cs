namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subcategory1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        SubcategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.SubcategoryID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .Index(t => t.Category_CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.Subcategories", new[] { "Category_CategoryID" });
            DropTable("dbo.Subcategories");
        }
    }
}
