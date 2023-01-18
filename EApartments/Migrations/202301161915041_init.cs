namespace EApartments.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuildingId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Code = c.String(),
                        Floor = c.Int(nullable: false),
                        RentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deposit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApartmentCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Address = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApartmentId = c.Int(nullable: false),
                        OccupantId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ExtensionRequestedTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeasePayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaseId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Occupants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApartmentId = c.Int(nullable: false),
                        UserId = c.Int(),
                        ChiefOccupantId = c.Int(),
                        RelationshipToChiefOccupant = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Nic = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        EmergencyContact = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParkingSpaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuildingId = c.Int(nullable: false),
                        SpaceNumber = c.String(),
                        Rent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WaitingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuildingId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Nic = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        DateOfOccupancy = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            // Add master data.
            // User roles
            Sql("INSERT INTO Roles (Name) VALUES ('ADMIN')");
            Sql("INSERT INTO Roles (Name) VALUES ('MANAGER')");
            Sql("INSERT INTO Roles (Name) VALUES ('OCCUPANT')");

            // Buildings
            Sql("INSERT INTO Buildings (Title,Address) VALUES ('Building K', 'Kottawa')");
            Sql("INSERT INTO Buildings (Title,Address) VALUES ('Building N', 'Nugegoda')");
            Sql("INSERT INTO Buildings (Title,Address) VALUES ('Building R', 'Rajagiriya')");

            // Apartment classes
            Sql("INSERT INTO ApartmentCategories (Title,Description) VALUES ('Class 1', 'One bedroomed apartment, One common bathroom')");
            Sql("INSERT INTO ApartmentCategories (Title,Description) VALUES ('Class 2', 'Two bedroomed apartment, One attached bathroom, Common bathroom')");
            Sql("INSERT INTO ApartmentCategories (Title,Description) VALUES ('Class 3', 'Three bedroomed apartment, Two attached bathrooms, Common bathroom')");
            Sql("INSERT INTO ApartmentCategories (Title,Description) VALUES ('Suite', 'Apartment with 4 bedrooms and a servants’ room, 3 attached bathrooms, One common bathroom and a servants’ toilet')");

        }
        
        public override void Down()
        {
            DropTable("dbo.WaitingLists");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.ParkingSpaces");
            DropTable("dbo.Occupants");
            DropTable("dbo.LeasePayments");
            DropTable("dbo.Leases");
            DropTable("dbo.Buildings");
            DropTable("dbo.ApartmentCategories");
            DropTable("dbo.Apartments");
        }
    }
}
