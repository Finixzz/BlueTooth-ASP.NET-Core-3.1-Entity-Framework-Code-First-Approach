using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTooth.Migrations
{
    public partial class AddedDentalCheckServiceM2M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DentalCheckServices",
                columns: table => new
                {
                    DentalCheckID = table.Column<int>(nullable: false),
                    ServiceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DentalCheckServices", x => new { x.DentalCheckID, x.ServiceID });
                    table.ForeignKey(
                        name: "FK_DentalCheckServices_DentalChecks_DentalCheckID",
                        column: x => x.DentalCheckID,
                        principalTable: "DentalChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DentalCheckServices_Services_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DentalCheckServices_ServiceID",
                table: "DentalCheckServices",
                column: "ServiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DentalCheckServices");
        }
    }
}
