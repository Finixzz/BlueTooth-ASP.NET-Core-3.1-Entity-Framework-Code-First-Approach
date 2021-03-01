using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTooth.Migrations
{
    public partial class AddedOrderHeaderDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    FirmaId = table.Column<int>(nullable: false),
                    VlasnikOrdinacijeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_Firme_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_VlasnikOrdinacijeId",
                        column: x => x.VlasnikOrdinacijeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_FirmaId",
                table: "OrderHeaders",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_VlasnikOrdinacijeId",
                table: "OrderHeaders",
                column: "VlasnikOrdinacijeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderHeaders");
        }
    }
}
