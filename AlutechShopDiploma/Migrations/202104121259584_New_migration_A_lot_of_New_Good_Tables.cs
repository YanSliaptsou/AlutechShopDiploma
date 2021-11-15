namespace AlutechShopDiploma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_migration_A_lot_of_New_Good_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brackets",
                c => new
                    {
                        BracketID = c.Int(nullable: false, identity: true),
                        Weight = c.Double(nullable: false),
                        DeliveryRate = c.Int(nullable: false),
                        RollerAxis = c.String(),
                        Usage = c.String(),
                    })
                .PrimaryKey(t => t.BracketID);
            
            CreateTable(
                "dbo.Clutches",
                c => new
                    {
                        ClutchID = c.Int(nullable: false, identity: true),
                        Weight = c.Double(nullable: false),
                        ShaftDiameter = c.Double(nullable: false),
                        Material = c.String(),
                        DeliveryRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClutchID);
            
            CreateTable(
                "dbo.DeadboltAndLockingDevices",
                c => new
                    {
                        DeadboltAndLockingDeviceID = c.Int(nullable: false, identity: true),
                        Weight = c.Double(nullable: false),
                        DeliveryRate = c.String(),
                    })
                .PrimaryKey(t => t.DeadboltAndLockingDeviceID);
            
            CreateTable(
                "dbo.GarageGateOperatorAnMotors",
                c => new
                    {
                        GarageGateOperatorAnMotorsID = c.Int(nullable: false, identity: true),
                        UsageIntensity = c.Int(nullable: false),
                        MaxGatesHeight = c.Double(nullable: false),
                        MaxGatesSquare = c.Double(nullable: false),
                        TractiveEffort = c.Int(nullable: false),
                        ElectricalMotor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GarageGateOperatorAnMotorsID);
            
            CreateTable(
                "dbo.InsertAndSeals",
                c => new
                    {
                        InsertAndSealID = c.Int(nullable: false, identity: true),
                        Weight = c.Double(nullable: false),
                        Material = c.String(),
                        DeliveryRate = c.String(),
                    })
                .PrimaryKey(t => t.InsertAndSealID);
            
            CreateTable(
                "dbo.Loops",
                c => new
                    {
                        LoopID = c.Int(nullable: false, identity: true),
                        Weight = c.Double(nullable: false),
                        Material = c.String(),
                        DeliveryRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoopID);
            
            CreateTable(
                "dbo.RecoilingGateOperatorAnMotors",
                c => new
                    {
                        RecoilingGateOperatorAnMotorsID = c.Int(nullable: false, identity: true),
                        ApproprTemperature = c.Int(nullable: false),
                        UsangeIntensity = c.Double(nullable: false),
                        MaxTorque = c.Int(nullable: false),
                        Voltage = c.Int(nullable: false),
                        Powerty = c.Int(nullable: false),
                        SashWeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecoilingGateOperatorAnMotorsID);
            
            CreateTable(
                "dbo.RollerAndRings",
                c => new
                    {
                        RollerAndRingID = c.Int(nullable: false, identity: true),
                        AxisDiameter = c.Double(nullable: false),
                        AxisLength = c.Double(nullable: false),
                        DeliveryRate = c.Int(nullable: false),
                        RollerAx = c.String(),
                    })
                .PrimaryKey(t => t.RollerAndRingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RollerAndRings");
            DropTable("dbo.RecoilingGateOperatorAnMotors");
            DropTable("dbo.Loops");
            DropTable("dbo.InsertAndSeals");
            DropTable("dbo.GarageGateOperatorAnMotors");
            DropTable("dbo.DeadboltAndLockingDevices");
            DropTable("dbo.Clutches");
            DropTable("dbo.Brackets");
        }
    }
}
