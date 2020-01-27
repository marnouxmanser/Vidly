namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMovieImgUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "imageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "imageURL");
        }
    }
}
