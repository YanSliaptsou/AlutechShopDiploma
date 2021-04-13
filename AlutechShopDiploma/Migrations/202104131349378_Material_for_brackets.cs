namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Material_for_brackets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brackets", "Material", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brackets", "Material");
        }
    }
}
