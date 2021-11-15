namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subcategories", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.Subcategories", new[] { "Category_CategoryID" });
            AddColumn("dbo.Subcategories", "CategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Subcategories", "Category_CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subcategories", "Category_CategoryID", c => c.Int());
            DropColumn("dbo.Subcategories", "CategoryId");
            CreateIndex("dbo.Subcategories", "Category_CategoryID");
            AddForeignKey("dbo.Subcategories", "Category_CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
