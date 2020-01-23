namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMembershipDescription : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Description = 'Pay As You Go' where Id = 1");
            Sql("update MembershipTypes set Description = 'Monthly' where Id = 2");
            Sql("update MembershipTypes set Description = 'Quarterly' where Id = 3");
            Sql("update MembershipTypes set Description = 'Yearly' where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
