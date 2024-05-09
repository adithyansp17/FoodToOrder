using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToOrder_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class cartOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cartid",
                table: "Dish",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Orderid",
                table: "Dish",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    orderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    orderAmount = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_Cartid",
                table: "Dish",
                column: "Cartid");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_Orderid",
                table: "Dish",
                column: "Orderid");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Carts_Cartid",
                table: "Dish",
                column: "Cartid",
                principalTable: "Carts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Order_Orderid",
                table: "Dish",
                column: "Orderid",
                principalTable: "Order",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Carts_Cartid",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Order_Orderid",
                table: "Dish");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Dish_Cartid",
                table: "Dish");

            migrationBuilder.DropIndex(
                name: "IX_Dish_Orderid",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "Cartid",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "Orderid",
                table: "Dish");
        }
    }
}
