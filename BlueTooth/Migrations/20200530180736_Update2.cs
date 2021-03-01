using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTooth.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Jednopovršinska plomba", 30f },
                    { 25, "Ortodontski mobilni aparat", 350f },
                    { 24, "Incizija", 70f },
                    { 23, "Apikotomija (uklanjanje vrha korjena zuba)", 160f },
                    { 22, "Hirurško vađenje zuba", 100f },
                    { 21, "Hirurško vađenje umnjaka", 160f },
                    { 20, "Ugradnja implanta (direct)", 1000f },
                    { 19, "Ugradnja implanta (mis)", 1200f },
                    { 18, "Ugradnja implanta (straumann)", 1500f },
                    { 17, "Parcijalna (wisil) proteza", 650f },
                    { 16, "Parcijalna proteza", 300f },
                    { 15, "Totalna proteza", 300f },
                    { 26, "Ortodontski fiksni aparat (metalne bravice)", 1200f },
                    { 14, "Bezmetalna (cirkonij) kruna", 400f },
                    { 12, "Bijeljenje liječenog zuba", 80f },
                    { 11, "Bijeljenje zuba", 350f },
                    { 10, "Čišćenje zubnog kamenca", 40f },
                    { 9, "Zalivanje fisura", 20f },
                    { 8, "Extrakcija mliječnog zuba", 20f },
                    { 7, "Extrakcija zuba sa šivanjem", 50f },
                    { 6, "Extrakcija (vađenje zuba)", 30f },
                    { 5, "Liječenje višekorjenog zuba", 120f },
                    { 4, "Liječenje jednokorjenog zuba", 70f },
                    { 3, "Višepovršinska plomba", 50f },
                    { 2, "Dvopovršinska plomba", 40f },
                    { 13, "Metalokeramička kruna", 160f },
                    { 27, "Ortodontski fiksni aparat (estetske bravice)", 1200f }
                });
        }
    }
}
