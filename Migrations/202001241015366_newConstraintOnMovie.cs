namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newConstraintOnMovie : DbMigration
    {
        public override void Up()
        {
            Sql(@"declare @tableName varchar(128) = 'Movies'
                  declare @columnName varchar(128) = 'DateAdded'
                  declare @constraintName varchar(128)
                  
                  set @constraintName = (select top 1 constraint_name
                                         from information_schema.constraint_column_usage
                                         where table_name = @tableName and column_name = @columnName)
                  
                  exec ('alter table  ''' + @tableName + '''  drop constraint  ''' + @constraintName + '''')
                  
                  GO        
                  
                  alter table Movies 
                  add constraint DateAddedDefault default getdate() 
                  for DateAdded");
        }

        public override void Down()
        {
        }
    }
}
