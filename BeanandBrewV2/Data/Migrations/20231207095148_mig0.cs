using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanandBrewV2.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coffee",
                columns: table => new
                {
                    CoffeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoffeePrice = table.Column<float>(type: "real", nullable: false),
                    CoffeeSize = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffee", x => x.CoffeeId);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeOrder",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeeId = table.Column<int>(type: "int", nullable: false),
                    CoffeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoffeeAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeOrder", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_CoffeeOrder_Coffee_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffee",
                        principalColumn: "CoffeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeOrder_CoffeeId",
                table: "CoffeeOrder",
                column: "CoffeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeOrder");

            migrationBuilder.DropTable(
                name: "Coffee");
        }
    }
}
