using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Web.Migrations
{
    public partial class CreateProductScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    ImageFile = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    UnitsInStock = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
