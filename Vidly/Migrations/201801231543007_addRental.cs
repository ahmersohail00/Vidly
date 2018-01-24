namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        CustomerId = c.Int(nullable: false),
                        NaatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Naats", t => t.NaatId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.NaatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "NaatId", "dbo.Naats");
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "NaatId" });
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            DropTable("dbo.Rentals");
        }
    }
}
