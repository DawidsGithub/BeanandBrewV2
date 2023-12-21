using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanandBrewV2.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CoffeeOrder",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffPermision",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeOrder_UserId",
                table: "CoffeeOrder",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeOrder_AspNetUsers_UserId",
                table: "CoffeeOrder",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeOrder_AspNetUsers_UserId",
                table: "CoffeeOrder");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeOrder_UserId",
                table: "CoffeeOrder");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CoffeeOrder");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffPermision",
                table: "AspNetUsers");
        }
    }
}
