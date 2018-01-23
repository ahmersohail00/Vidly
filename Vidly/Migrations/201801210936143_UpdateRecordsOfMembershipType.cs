namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRecordsOfMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name='Pay as You Go' WHERE Id=1");
            Sql("update MembershipTypes set Name='Monthly' WHERE Id=2");
            Sql("update MembershipTypes set Name='Quarterly' WHERE Id=3");
            Sql("update MembershipTypes set Name='Annually' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
