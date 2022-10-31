namespace HotalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMiddleName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Admin_ID = c.Int(nullable: false, identity: true),
                        AdminEmail = c.String(nullable: false, maxLength: 100),
                        AdminPassward = c.String(nullable: false),
                        emb_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Admin_ID)
                .ForeignKey("dbo.Employees", t => t.emb_ID, cascadeDelete: true)
                .Index(t => t.emb_ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Employee_ID = c.Int(nullable: false, identity: true),
                        EmployeeNationalID = c.String(nullable: false),
                        EmployeeName = c.String(nullable: false),
                        EmployeePhone = c.String(nullable: false),
                        EmployeeSalary = c.Double(nullable: false),
                        EmployeeBarthDate = c.DateTime(nullable: false, storeType: "date"),
                        EmployeeImage = c.String(),
                    })
                .PrimaryKey(t => t.Employee_ID);
            
            CreateTable(
                "dbo.RoomAndEmployees",
                c => new
                    {
                        RoomAndEmployeeId = c.Int(nullable: false, identity: true),
                        dateOfDay = c.DateTime(nullable: false, storeType: "date"),
                        FK_EmployeeId = c.Int(nullable: false),
                        FK_RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomAndEmployeeId)
                .ForeignKey("dbo.Employees", t => t.FK_EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.FK_RoomId, cascadeDelete: true)
                .Index(t => t.FK_EmployeeId)
                .Index(t => t.FK_RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        IsReseved = c.Boolean(nullable: false),
                        FK_CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomID)
                .ForeignKey("dbo.RoomCategories", t => t.FK_CategoryID, cascadeDelete: true)
                .Index(t => t.FK_CategoryID);
            
            CreateTable(
                "dbo.RoomAndUsers",
                c => new
                    {
                        RoomAndUserId = c.Int(nullable: false, identity: true),
                        reservationDate = c.DateTime(nullable: false, storeType: "date"),
                        NumberOfDays = c.Int(nullable: false),
                        FK_roomId = c.Int(nullable: false),
                        FK_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomAndUserId)
                .ForeignKey("dbo.Rooms", t => t.FK_roomId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.FK_UserID, cascadeDelete: true)
                .Index(t => t.FK_roomId)
                .Index(t => t.FK_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserNationalID = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 30),
                        UserPhone = c.String(nullable: false, maxLength: 30),
                        UserBarthDate = c.DateTime(nullable: false, storeType: "date"),
                        UserPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.RoomCategories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryNumberOfPerson = c.String(nullable: false),
                        CategoryDescription = c.String(nullable: false),
                        CategoryPrice = c.Double(nullable: false),
                        RoomTypeCount = c.Int(nullable: false),
                        UnreservedRoomCount = c.Int(nullable: false),
                        CategoryImage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "emb_ID", "dbo.Employees");
            DropForeignKey("dbo.RoomAndEmployees", "FK_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "FK_CategoryID", "dbo.RoomCategories");
            DropForeignKey("dbo.RoomAndUsers", "FK_UserID", "dbo.Users");
            DropForeignKey("dbo.RoomAndUsers", "FK_roomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomAndEmployees", "FK_EmployeeId", "dbo.Employees");
            DropIndex("dbo.RoomAndUsers", new[] { "FK_UserID" });
            DropIndex("dbo.RoomAndUsers", new[] { "FK_roomId" });
            DropIndex("dbo.Rooms", new[] { "FK_CategoryID" });
            DropIndex("dbo.RoomAndEmployees", new[] { "FK_RoomId" });
            DropIndex("dbo.RoomAndEmployees", new[] { "FK_EmployeeId" });
            DropIndex("dbo.Admins", new[] { "emb_ID" });
            DropTable("dbo.RoomCategories");
            DropTable("dbo.Users");
            DropTable("dbo.RoomAndUsers");
            DropTable("dbo.Rooms");
            DropTable("dbo.RoomAndEmployees");
            DropTable("dbo.Employees");
            DropTable("dbo.Admins");
        }
    }
}
