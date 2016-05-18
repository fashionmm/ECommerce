namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerGuid = c.Guid(nullable: false),
                        UserName = c.String(maxLength: 200),
                        Email = c.String(maxLength: 200),
                        Password = c.String(),
                        PasswordFormatId = c.Int(nullable: false),
                        PasswordSalt = c.String(),
                        AdminComment = c.String(),
                        IsTaxExempt = c.Boolean(nullable: false),
                        AffiliateId = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                        HasShoppingCartItems = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        IsSystemAccount = c.Boolean(nullable: false),
                        SystemName = c.String(maxLength: 100),
                        LastIpAddress = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        LastLoginDateUtc = c.DateTime(),
                        LastActivityDateUtc = c.DateTime(nullable: false),
                        BillingAddress_Id = c.Int(),
                        ShippingAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.BillingAddress_Id)
                .ForeignKey("dbo.Address", t => t.ShippingAddress_Id)
                .Index(t => t.BillingAddress_Id)
                .Index(t => t.ShippingAddress_Id);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Company = c.String(),
                        CountryId = c.Int(),
                        StateProvinceId = c.Int(),
                        City = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        ZipPostalCode = c.String(),
                        PhoneNumber = c.String(),
                        FaxNumber = c.String(),
                        CustomAttributes = c.String(),
                        CreatedOnUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer_Addresses",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        Address_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.Address_Id })
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Address", t => t.Address_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Address_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "ShippingAddress_Id", "dbo.Address");
            DropForeignKey("dbo.Customer", "BillingAddress_Id", "dbo.Address");
            DropForeignKey("dbo.Customer_Addresses", "Address_Id", "dbo.Address");
            DropForeignKey("dbo.Customer_Addresses", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.Customer_Addresses", new[] { "Address_Id" });
            DropIndex("dbo.Customer_Addresses", new[] { "Customer_Id" });
            DropIndex("dbo.Customer", new[] { "ShippingAddress_Id" });
            DropIndex("dbo.Customer", new[] { "BillingAddress_Id" });
            DropTable("dbo.Customer_Addresses");
            DropTable("dbo.Address");
            DropTable("dbo.Customer");
        }
    }
}
