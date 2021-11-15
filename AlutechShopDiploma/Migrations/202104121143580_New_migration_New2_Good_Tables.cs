namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_migration_New2_Good_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusProfiles",
                c => new
                    {
                        BusProfileID = c.Int(nullable: false, identity: true),
                        Weight = c.Double(nullable: false),
                        Material = c.String(),
                    })
                .PrimaryKey(t => t.BusProfileID);
            
            CreateTable(
                "dbo.RollerAndSteelComplects",
                c => new
                    {
                        RollerAndSteelComplectID = c.Int(nullable: false, identity: true),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RollerAndSteelComplectID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RollerAndSteelComplects");
            DropTable("dbo.BusProfiles");
        }
    }
}
