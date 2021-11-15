namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_migration_Good_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GoodsTables",
                c => new
                    {
                        GoodsTableID = c.Int(nullable: false, identity: true),
                        TableName = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GoodsTableID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GoodsTables");
        }
    }
}
