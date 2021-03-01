using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTooth.Migrations
{
    public partial class SeedVlasnikInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string vlasnikSQL = @"INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [BirthDate], [Gender]) VALUES (N'46c777ce-7768-4b93-9326-741988443d10', N'vlasnik@gmail.com', N'VLASNIK@GMAIL.COM', N'vlasnik@gmail.com', N'VLASNIK@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPJH6fx1ySn5uERCvaIQpag+Fnp7sEm4CkmtuDovuthc6xA4yuCpvSAizwW1K+u/VA==', N'JGDSZLVBVMPFXPEOMSAIYDKY24XOQSRC', N'cdab6130-705b-4cd2-bbc2-8ff1f89f5df3', NULL, 0, 0, NULL, 1, 0, N'Vlasnik', N'Ordinacije', N'1970-11-05 00:00:00', N'M')";
            string vlasnikSQL2 = @"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'46c777ce-7768-4b93-9326-741988443d10', N'2')";
            migrationBuilder.Sql(vlasnikSQL);
            migrationBuilder.Sql(vlasnikSQL2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
