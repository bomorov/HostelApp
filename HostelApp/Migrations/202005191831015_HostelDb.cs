namespace HostelApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HostelDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        ResidencePlace = c.String(nullable: false),
                        FillinDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Pay = c.Int(nullable: false),
                        LivingRoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LivingRooms", t => t.LivingRoomId, cascadeDelete: true)
                .Index(t => t.LivingRoomId);
            
            CreateTable(
                "dbo.LivingRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Num = c.String(nullable: false),
                        HostelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hostels", t => t.HostelId, cascadeDelete: true)
                .Index(t => t.HostelId);
            
            CreateTable(
                "dbo.Hostels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Num = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UniversityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Universities", t => t.UniversityId, cascadeDelete: true)
                .Index(t => t.UniversityId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        GroupId = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        ResidencePlace = c.String(nullable: false),
                        RegionId = c.Int(nullable: false),
                        FillinDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Pay = c.Int(nullable: false),
                        LivingRoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.LivingRooms", t => t.LivingRoomId, cascadeDelete: true)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.RegionId)
                .Index(t => t.LivingRoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Students", "LivingRoomId", "dbo.LivingRooms");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Faculties", "UniversityId", "dbo.Universities");
            DropForeignKey("dbo.Groups", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Employees", "LivingRoomId", "dbo.LivingRooms");
            DropForeignKey("dbo.LivingRooms", "HostelId", "dbo.Hostels");
            DropIndex("dbo.Students", new[] { "LivingRoomId" });
            DropIndex("dbo.Students", new[] { "RegionId" });
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropIndex("dbo.Groups", new[] { "FacultyId" });
            DropIndex("dbo.Faculties", new[] { "UniversityId" });
            DropIndex("dbo.LivingRooms", new[] { "HostelId" });
            DropIndex("dbo.Employees", new[] { "LivingRoomId" });
            DropTable("dbo.Students");
            DropTable("dbo.Regions");
            DropTable("dbo.Universities");
            DropTable("dbo.Groups");
            DropTable("dbo.Faculties");
            DropTable("dbo.Hostels");
            DropTable("dbo.LivingRooms");
            DropTable("dbo.Employees");
        }
    }
}
