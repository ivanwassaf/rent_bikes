namespace RentBikes.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                {
                    clientID = c.Int(nullable: false, identity: true),
                    name = c.String(),
                    identification = c.String(),
                    address = c.String(),
                    stateID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.clientID)
                .ForeignKey("dbo.States", t => t.stateID, cascadeDelete: true)
                .Index(t => t.stateID);

            CreateTable(
                "dbo.Rentals",
                c => new
                {
                    rentalID = c.Int(nullable: false, identity: true),
                    from = c.DateTime(nullable: false),
                    to = c.DateTime(nullable: false),
                    stateID = c.Int(nullable: false),
                    stationID = c.Int(nullable: false),
                    rentalTypeID = c.Int(nullable: false),
                    subtotal = c.Decimal(precision: 18, scale: 2),
                    total = c.Decimal(precision: 18, scale: 2),
                    clientID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.rentalID)
                .ForeignKey("dbo.Clients", t => t.clientID, cascadeDelete: false)
                .ForeignKey("dbo.Stations", t => t.stationID, cascadeDelete: false)
                .ForeignKey("dbo.RentalTypes", t => t.rentalTypeID, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.stateID, cascadeDelete: false)
                .Index(t => t.stateID)
                .Index(t => t.stationID)
                .Index(t => t.rentalTypeID)
                .Index(t => t.clientID);

            CreateTable(
                "dbo.RentalDetails",
                c => new
                {
                    rentalDetailID = c.Int(nullable: false, identity: true),
                    rentalID = c.Int(nullable: false),
                    vehicleID = c.Int(nullable: false),
                    hours = c.Int(nullable: false),
                    rentalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    priceID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.rentalDetailID)
                .ForeignKey("dbo.Prices", t => t.priceID, cascadeDelete: false)
                .ForeignKey("dbo.Rentals", t => t.rentalID, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.vehicleID, cascadeDelete: false)
                .Index(t => t.rentalID)
                .Index(t => t.vehicleID)
                .Index(t => t.priceID);

            CreateTable(
                "dbo.Prices",
                c => new
                {
                    priceID = c.Int(nullable: false, identity: true),
                    rentalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    description = c.String(),
                    hours = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.priceID);

            CreateTable(
                "dbo.Vehicles",
                c => new
                {
                    vehicleID = c.Int(nullable: false, identity: true),
                    description = c.String(),
                    vehicleTypeID = c.Int(nullable: false),
                    stateID = c.Int(nullable: false),
                    serie = c.String(),
                })
                .PrimaryKey(t => t.vehicleID)
                .ForeignKey("dbo.States", t => t.stateID, cascadeDelete: false)
                .ForeignKey("dbo.VehicleTypes", t => t.vehicleTypeID, cascadeDelete: false)
                .Index(t => t.vehicleTypeID)
                .Index(t => t.stateID);

            CreateTable(
                "dbo.States",
                c => new
                {
                    stateID = c.Int(nullable: false, identity: true),
                    description = c.String(),
                })
                .PrimaryKey(t => t.stateID);

            CreateTable(
                "dbo.Stations",
                c => new
                {
                    stationID = c.Int(nullable: false, identity: true),
                    description = c.String(),
                    address = c.String(),
                    stateID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.stationID)
                .ForeignKey("dbo.States", t => t.stateID, cascadeDelete: false)
                .Index(t => t.stateID);

            CreateTable(
                "dbo.VehicleTypes",
                c => new
                {
                    vehicleTypeID = c.Int(nullable: false, identity: true),
                    description = c.String(),
                    stateID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.vehicleTypeID)
                .ForeignKey("dbo.States", t => t.stateID, cascadeDelete: false)
                .Index(t => t.stateID);

            CreateTable(
                "dbo.RentalTypes",
                c => new
                {
                    rentalTypeID = c.Int(nullable: false, identity: true),
                    description = c.String(),
                    discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.rentalTypeID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Clients", "stateID", "dbo.States");
            DropForeignKey("dbo.Rentals", "stateID", "dbo.States");
            DropForeignKey("dbo.Rentals", "rentalTypeID", "dbo.RentalTypes");
            DropForeignKey("dbo.RentalDetails", "vehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "vehicleTypeID", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleTypes", "stateID", "dbo.States");
            DropForeignKey("dbo.Vehicles", "stateID", "dbo.States");
            DropForeignKey("dbo.Stations", "stateID", "dbo.States");
            DropForeignKey("dbo.Rentals", "stationID", "dbo.Stations");
            DropForeignKey("dbo.RentalDetails", "rentalID", "dbo.Rentals");
            DropForeignKey("dbo.RentalDetails", "priceID", "dbo.Prices");
            DropForeignKey("dbo.Rentals", "clientID", "dbo.Clients");
            DropIndex("dbo.VehicleTypes", new[] { "stateID" });
            DropIndex("dbo.Stations", new[] { "stateID" });
            DropIndex("dbo.Vehicles", new[] { "stateID" });
            DropIndex("dbo.Vehicles", new[] { "vehicleTypeID" });
            DropIndex("dbo.RentalDetails", new[] { "priceID" });
            DropIndex("dbo.RentalDetails", new[] { "vehicleID" });
            DropIndex("dbo.RentalDetails", new[] { "rentalID" });
            DropIndex("dbo.Rentals", new[] { "clientID" });
            DropIndex("dbo.Rentals", new[] { "rentalTypeID" });
            DropIndex("dbo.Rentals", new[] { "stationID" });
            DropIndex("dbo.Rentals", new[] { "stateID" });
            DropIndex("dbo.Clients", new[] { "stateID" });
            DropTable("dbo.RentalTypes");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Stations");
            DropTable("dbo.States");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Prices");
            DropTable("dbo.RentalDetails");
            DropTable("dbo.Rentals");
            DropTable("dbo.Clients");
        }
    }
}
