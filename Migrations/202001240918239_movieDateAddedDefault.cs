namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class movieDateAddedDefault : DbMigration
    {
        public override void Up()
        {
            Sql(@"declare @tableName varchar(128)
        declare @columnName varchar(128)
        declare @constraintName varchar(128)
        
        set @tableName = ''Movies''
        set @columnName = ''DateAdded''

        set @constraintName = (select top 1 constraint_name
                               from information_schema.constraint_column_usage
                               where table_name = @tableName and column_name = @columnName)
        
        exec (''alter table '' + @tableName + '' drop constraint '' + @constraintName + '''') 
        alter table Movies add constraint DateAddedDefault default getdate() for DateAdded ");
        }

        public override void Down()
        {
        }
    }
}
