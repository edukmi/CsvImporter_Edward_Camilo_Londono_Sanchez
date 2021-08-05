using Microsoft.EntityFrameworkCore.Migrations;

namespace CsvImporterModel.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CsvImporter",
                columns: table => new
                {
                    PointOfSale = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Product = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Date = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Stock = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CsvImporter");
        }
    }
}
