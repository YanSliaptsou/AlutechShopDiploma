namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_migration_New4_Good_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalComplectations",
                c => new
                    {
                        AdditionalComplectationID = c.Int(nullable: false, identity: true),
                        NetWeight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AdditionalComplectationID);
            
            CreateTable(
                "dbo.AlutechBarriers",
                c => new
                    {
                        AlutechBarrierID = c.Int(nullable: false, identity: true),
                        WorkIntensity = c.String(),
                        Torque = c.Int(nullable: false),
                        MaxTimeOpenClose = c.Double(nullable: false),
                        Voltage = c.Int(nullable: false),
                        CorpProtectionDegree = c.Int(nullable: false),
                        OverlappingWidth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlutechBarrierID);
            
            CreateTable(
                "dbo.ComunelloAccessories",
                c => new
                    {
                        ComunelloAccessoryID = c.Int(nullable: false, identity: true),
                        GabariteSizes = c.String(),
                        IndoorLightLength = c.Int(nullable: false),
                        OutdoorLightLength = c.Int(nullable: false),
                        TemperatureRange = c.String(),
                        Voltage = c.Int(nullable: false),
                        OutputContactsType = c.String(),
                    })
                .PrimaryKey(t => t.ComunelloAccessoryID);
            
            CreateTable(
                "dbo.ComunelloDriveUnits",
                c => new
                    {
                        ComunelloDriveUnitID = c.Int(nullable: false, identity: true),
                        UsageIntensity = c.String(),
                        MaxGatesHeight = c.Double(nullable: false),
                        MaxGatesSquare = c.Double(nullable: false),
                        MaxGatesSpeed = c.Double(nullable: false),
                        TrativeEffort = c.Int(nullable: false),
                        ElectricMotor = c.String(),
                    })
                .PrimaryKey(t => t.ComunelloDriveUnitID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ComunelloDriveUnits");
            DropTable("dbo.ComunelloAccessories");
            DropTable("dbo.AlutechBarriers");
            DropTable("dbo.AdditionalComplectations");
        }
    }
}
