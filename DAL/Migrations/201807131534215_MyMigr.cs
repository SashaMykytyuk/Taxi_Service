namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassOfCar = c.Int(nullable: false),
                        Marka = c.String(),
                        Volume = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Money = c.Double(nullable: false),
                        KM = c.Double(nullable: false),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Car_Id = c.Int(),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Car_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                        Place = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassOfCar = c.Int(nullable: false),
                        Comment = c.String(),
                        Done = c.Boolean(nullable: false),
                        KM = c.Double(nullable: false),
                        Money = c.Double(nullable: false),
                        Client_Id = c.Int(),
                        Driver_Id = c.Int(),
                        LocationFrom_Id = c.Int(),
                        LocationTo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Drivers", t => t.Driver_Id)
                .ForeignKey("dbo.Locations", t => t.LocationFrom_Id)
                .ForeignKey("dbo.Locations", t => t.LocationTo_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Driver_Id)
                .Index(t => t.LocationFrom_Id)
                .Index(t => t.LocationTo_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Money = c.Double(nullable: false),
                        KM = c.Double(nullable: false),
                        Driver_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.Driver_Id)
                .Index(t => t.Driver_Id);
            
            CreateTable(
                "dbo.Dispatchers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassOfCar = c.Int(nullable: false),
                        Money = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.Orders", "LocationTo_Id", "dbo.Locations");
            DropForeignKey("dbo.Orders", "LocationFrom_Id", "dbo.Locations");
            DropForeignKey("dbo.Orders", "Driver_Id", "dbo.Drivers");
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Drivers", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Drivers", "Car_Id", "dbo.Cars");
            DropIndex("dbo.Reports", new[] { "Driver_Id" });
            DropIndex("dbo.Orders", new[] { "LocationTo_Id" });
            DropIndex("dbo.Orders", new[] { "LocationFrom_Id" });
            DropIndex("dbo.Orders", new[] { "Driver_Id" });
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropIndex("dbo.Drivers", new[] { "Location_Id" });
            DropIndex("dbo.Drivers", new[] { "Car_Id" });
            DropTable("dbo.Prices");
            DropTable("dbo.Dispatchers");
            DropTable("dbo.Reports");
            DropTable("dbo.Clients");
            DropTable("dbo.Orders");
            DropTable("dbo.Locations");
            DropTable("dbo.Drivers");
            DropTable("dbo.Cars");
        }
    }
}
