namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneAndDrivingLicence : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicence", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "PhoneNo", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PhoneNo");
            DropColumn("dbo.AspNetUsers", "DrivingLicence");
        }
    }
}
