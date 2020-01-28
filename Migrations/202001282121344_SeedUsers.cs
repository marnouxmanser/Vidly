namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'74dd5333-ebc3-4b7b-816e-6aa6e3137929', N'guest@vidly.com', 0, N'AApk0hc9oxtxWx2XBn9LqzlkfCfmAyb4Sl2Fj2pVUR/qsNt32aP8Sa5F+NHlTRIDnA==', N'01c5e8d2-83a4-4909-8f78-9aeb5d2d5ffa', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'97c4d6de-e92c-4ce3-a496-a8c0aec3db7a', N'admin@vidly.com', 0, N'APsqSMVX/jbWOTdfMcrmogS3KlUv4scVRmtEj+Z4AwV7ppOKiqDuWmEgcUaiMYGxtw==', N'6cd9ac9b-0e88-4783-8c00-2a26493a3e65', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6c5a2dd9-0284-4ac9-ad3e-818fbd0e8240', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'97c4d6de-e92c-4ce3-a496-a8c0aec3db7a', N'6c5a2dd9-0284-4ac9-ad3e-818fbd0e8240')                
                ");
        }
        
        public override void Down()
        {
        }
    }
}
