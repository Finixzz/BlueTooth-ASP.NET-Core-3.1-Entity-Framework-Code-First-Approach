using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTooth.Migrations
{
    public partial class AspNetRolesTableDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string seedAspNetRoles = @"Insert into dbo.AspNetRoles(Id,Name,NormalizedName) VALUES
                                                                          (1,'Admin','ADMIN'),
                                                                          (2, 'Vlasnik','VLASNIK'),
                                                                          (3, 'Radnik','RADNIK'),
                                                                          (4, 'Pacijent','PACIJENT'),
                                                                          (5, 'ARadnik','ARADNIK')";
            migrationBuilder.Sql(seedAspNetRoles);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
