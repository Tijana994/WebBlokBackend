namespace RentACarApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Surname = c.String(nullable: false, maxLength: 40),
                        BirthDate = c.DateTime(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        LoggedIn = c.Boolean(nullable: false),
                        CreateService = c.Boolean(nullable: false),
                        Path = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Point = c.Int(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 400),
                        AppUserId = c.Int(nullable: false),
                        ServisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .ForeignKey("dbo.Servis", t => t.ServisId, cascadeDelete: true)
                .Index(t => t.AppUserId)
                .Index(t => t.ServisId);
            
            CreateTable(
                "dbo.Servis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 40),
                        Description = c.String(nullable: false, maxLength: 200),
                        Contact = c.String(nullable: false, maxLength: 40),
                        Path = c.String(nullable: false, maxLength: 200),
                        Approved = c.Boolean(nullable: false),
                        AverageMark = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Name = c.String(nullable: false, maxLength: 40),
                        Address = c.String(nullable: false, maxLength: 60),
                        ServisId = c.Int(nullable: false),
                        Reservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id)
                .ForeignKey("dbo.Servis", t => t.ServisId, cascadeDelete: true)
                .Index(t => t.ServisId)
                .Index(t => t.Reservation_Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Expired = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        AppUserId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        Branch_Id = c.Int(),
                        Branch_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.Branch_Id)
                .ForeignKey("dbo.Branches", t => t.Branch_Id1)
                .Index(t => t.AppUserId)
                .Index(t => t.VehicleId)
                .Index(t => t.Branch_Id)
                .Index(t => t.Branch_Id1);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.String(nullable: false, maxLength: 40),
                        Model = c.String(nullable: false, maxLength: 40),
                        Year = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 40),
                        TypeOfVehicleId = c.Int(nullable: false),
                        ServisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Servis", t => t.ServisId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfVehicles", t => t.TypeOfVehicleId, cascadeDelete: true)
                .Index(t => t.TypeOfVehicleId)
                .Index(t => t.ServisId);
            
            CreateTable(
                "dbo.Pics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false, maxLength: 200),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.PriceLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.Vehicle_Id);
            
            CreateTable(
                "dbo.TypeOfVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AppUserId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .Index(t => t.AppUserId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Rates", "ServisId", "dbo.Servis");
            DropForeignKey("dbo.Branches", "ServisId", "dbo.Servis");
            DropForeignKey("dbo.Reservations", "Branch_Id1", "dbo.Branches");
            DropForeignKey("dbo.Reservations", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.Reservations", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "TypeOfVehicleId", "dbo.TypeOfVehicles");
            DropForeignKey("dbo.Vehicles", "ServisId", "dbo.Servis");
            DropForeignKey("dbo.PriceLists", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Pics", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Branches", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.Rates", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "AppUserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PriceLists", new[] { "Vehicle_Id" });
            DropIndex("dbo.Pics", new[] { "VehicleId" });
            DropIndex("dbo.Vehicles", new[] { "ServisId" });
            DropIndex("dbo.Vehicles", new[] { "TypeOfVehicleId" });
            DropIndex("dbo.Reservations", new[] { "Branch_Id1" });
            DropIndex("dbo.Reservations", new[] { "Branch_Id" });
            DropIndex("dbo.Reservations", new[] { "VehicleId" });
            DropIndex("dbo.Reservations", new[] { "AppUserId" });
            DropIndex("dbo.Branches", new[] { "Reservation_Id" });
            DropIndex("dbo.Branches", new[] { "ServisId" });
            DropIndex("dbo.Rates", new[] { "ServisId" });
            DropIndex("dbo.Rates", new[] { "AppUserId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TypeOfVehicles");
            DropTable("dbo.PriceLists");
            DropTable("dbo.Pics");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Reservations");
            DropTable("dbo.Branches");
            DropTable("dbo.Servis");
            DropTable("dbo.Rates");
            DropTable("dbo.AppUsers");
        }
    }
}
