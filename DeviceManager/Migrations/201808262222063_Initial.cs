namespace DeviceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Quantity = c.Int(nullable: false),
                        IDCategory = c.Int(nullable: false),
                        IDUnit = c.Int(nullable: false),
                        IDStatus = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Info = c.String(storeType: "ntext"),
                        CreatedBy = c.String(nullable: false),
                        UpdatedBy = c.String(),
                        Note = c.String(storeType: "ntext"),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        User_Username = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.IDCategory, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Username)
                .ForeignKey("dbo.Statuses", t => t.IDStatus, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.IDUnit, cascadeDelete: true)
                .Index(t => t.IDCategory)
                .Index(t => t.IDUnit)
                .Index(t => t.IDStatus)
                .Index(t => t.User_Username);
            
            CreateTable(
                "dbo.DeliveryDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDDevice = c.Int(nullable: false),
                        IDDelivery = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        DateExpires = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Deliveries", t => t.IDDelivery, cascadeDelete: true)
                .ForeignKey("dbo.Devices", t => t.IDDevice, cascadeDelete: true)
                .Index(t => t.IDDevice)
                .Index(t => t.IDDelivery);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DeliveryToUser = c.String(maxLength: 100),
                        DeliveryFromUser = c.String(maxLength: 100),
                        CreatedBy = c.String(nullable: false),
                        UpdatedBy = c.String(),
                        Note = c.String(storeType: "ntext"),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        User_Username = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_Username)
                .ForeignKey("dbo.Users", t => t.DeliveryFromUser)
                .ForeignKey("dbo.Users", t => t.DeliveryToUser)
                .Index(t => t.DeliveryToUser)
                .Index(t => t.DeliveryFromUser)
                .Index(t => t.User_Username);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 256),
                        Email = c.String(maxLength: 256),
                        FullName = c.String(nullable: false, maxLength: 256),
                        Address = c.String(nullable: false, maxLength: 256),
                        BirthDay = c.DateTime(nullable: false, storeType: "date"),
                        IDDepartment = c.Int(nullable: false),
                        IDRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.Departments", t => t.IDDepartment, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.IDRole, cascadeDelete: true)
                .Index(t => t.Email, unique: true, name: "EmailIndex")
                .Index(t => t.IDDepartment)
                .Index(t => t.IDRole);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDProvider = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedBy = c.String(),
                        Note = c.String(storeType: "ntext"),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        User_Username = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Providers", t => t.IDProvider, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Username)
                .Index(t => t.IDProvider)
                .Index(t => t.User_Username);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReceiptDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDReceipt = c.Int(nullable: false),
                        IDDevice = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Devices", t => t.IDDevice, cascadeDelete: true)
                .ForeignKey("dbo.Receipts", t => t.IDReceipt, cascadeDelete: true)
                .Index(t => t.IDReceipt)
                .Index(t => t.IDDevice);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Statuses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "IDUnit", "dbo.Units");
            DropForeignKey("dbo.Devices", "IDStatus", "dbo.Statuses");
            DropForeignKey("dbo.DeliveryDetails", "IDDevice", "dbo.Devices");
            DropForeignKey("dbo.Deliveries", "DeliveryToUser", "dbo.Users");
            DropForeignKey("dbo.Deliveries", "DeliveryFromUser", "dbo.Users");
            DropForeignKey("dbo.Users", "IDRole", "dbo.Roles");
            DropForeignKey("dbo.Receipts", "User_Username", "dbo.Users");
            DropForeignKey("dbo.ReceiptDetails", "IDReceipt", "dbo.Receipts");
            DropForeignKey("dbo.ReceiptDetails", "IDDevice", "dbo.Devices");
            DropForeignKey("dbo.Receipts", "IDProvider", "dbo.Providers");
            DropForeignKey("dbo.Devices", "User_Username", "dbo.Users");
            DropForeignKey("dbo.Users", "IDDepartment", "dbo.Departments");
            DropForeignKey("dbo.Deliveries", "User_Username", "dbo.Users");
            DropForeignKey("dbo.DeliveryDetails", "IDDelivery", "dbo.Deliveries");
            DropForeignKey("dbo.Devices", "IDCategory", "dbo.Categories");
            DropIndex("dbo.ReceiptDetails", new[] { "IDDevice" });
            DropIndex("dbo.ReceiptDetails", new[] { "IDReceipt" });
            DropIndex("dbo.Receipts", new[] { "User_Username" });
            DropIndex("dbo.Receipts", new[] { "IDProvider" });
            DropIndex("dbo.Users", new[] { "IDRole" });
            DropIndex("dbo.Users", new[] { "IDDepartment" });
            DropIndex("dbo.Users", "EmailIndex");
            DropIndex("dbo.Deliveries", new[] { "User_Username" });
            DropIndex("dbo.Deliveries", new[] { "DeliveryFromUser" });
            DropIndex("dbo.Deliveries", new[] { "DeliveryToUser" });
            DropIndex("dbo.DeliveryDetails", new[] { "IDDelivery" });
            DropIndex("dbo.DeliveryDetails", new[] { "IDDevice" });
            DropIndex("dbo.Devices", new[] { "User_Username" });
            DropIndex("dbo.Devices", new[] { "IDStatus" });
            DropIndex("dbo.Devices", new[] { "IDUnit" });
            DropIndex("dbo.Devices", new[] { "IDCategory" });
            DropTable("dbo.Units");
            DropTable("dbo.Statuses");
            DropTable("dbo.Roles");
            DropTable("dbo.ReceiptDetails");
            DropTable("dbo.Providers");
            DropTable("dbo.Receipts");
            DropTable("dbo.Departments");
            DropTable("dbo.Users");
            DropTable("dbo.Deliveries");
            DropTable("dbo.DeliveryDetails");
            DropTable("dbo.Devices");
            DropTable("dbo.Categories");
        }
    }
}
