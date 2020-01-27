namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idkwtf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Description", c => c.String());
        }
    }
}
