﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenre : DbMigration
    {
        public override void Up()
        {
            //Sql("insert into Genre (description) values ('Action','Adventure','Comedy','Crime','Drama','Epic','Fantasy','Historical','Historical fiction','Horror','Magical realism','Mystery','Paranoid fiction','Philosophical','Political','Romance','Saga','Satire','Science fiction','Social','Space Epic','Speculative','Thriller','Urban','Western')");
        }
        
        public override void Down()
        {
        }
    }
}
