using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTooth.Migrations
{
    public partial class AddedServiceMaterialsDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceMaterials",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false),
                    MatherialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceMaterials", x => new { x.ServiceId, x.MatherialId });
                    table.ForeignKey(
                        name: "FK_ServiceMaterials_Matherials_MatherialId",
                        column: x => x.MatherialId,
                        principalTable: "Matherials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceMaterials_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceMaterials_MatherialId",
                table: "ServiceMaterials",
                column: "MatherialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceMaterials");
        }
    }
}
