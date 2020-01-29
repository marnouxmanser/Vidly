namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNumberMoviesAvailable : DbMigration
    {
        public override void Up()
        {
            Sql("update movies set numberavailable = numberinstock");
        }
        
        public override void Down()
        {
        }
    }
}
