using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTooth.Migrations
{
    public partial class UpdatedServiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Services",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Services",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserId1",
                table: "Services",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_UserId1",
                table: "Services",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_UserId1",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_UserId1",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Services");
        }
    }
}
