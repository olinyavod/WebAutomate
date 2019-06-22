using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAutomate.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nominal = table.Column<decimal>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    IsBlocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coins",
                columns: new[] { "Id", "Count", "IsBlocked", "Nominal" },
                values: new object[,]
                {
                    { 1, 100, false, 1m },
                    { 2, 100, false, 2m },
                    { 3, 50, false, 5m },
                    { 4, 30, false, 10m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Count", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 10, "images\\coca-cola.svg", "Coca-Cola", 60m },
                    { 2, 20, "images\\sprite.svg", "Sprite", 50m },
                    { 3, 5, "images\\fanta.svg", "Fanta", 55m },
                    { 4, 0, "images\\7-Up.svg", "7-up", 0m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
