using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTooth.Migrations
{
    public partial class UpdatedServiceModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_UserId1",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_UserId1",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Services",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ApplicationUserId",
                table: "Services",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_AspNetUsers_ApplicationUserId",
                table: "Services",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_AspNetUsers_ApplicationUserId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ApplicationUserId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Services",
                type: "nvarchar(450)",
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
    }
}
