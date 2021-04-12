namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_migration_7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageContainers",
                c => new
                    {
                        ImageContainerID = c.Int(nullable: false, identity: true),
                        GoodID = c.Int(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.ImageContainerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageContainers");
        }
    }
}
