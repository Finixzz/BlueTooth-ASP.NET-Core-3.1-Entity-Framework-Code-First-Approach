using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTooth.Migrations
{
    public partial class AddedTPTWorkerHierarchy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Workers_AspNetUsers_Id",
                table: "Workers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_AspNetUsers_Id",
                table: "Workers");
        }
    }
}
