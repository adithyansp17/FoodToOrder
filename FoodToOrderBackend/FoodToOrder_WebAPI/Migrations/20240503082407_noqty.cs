using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToOrder_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class noqty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Order_Orderid",
                table: "Dish");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Carts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                table: "User",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "Orders",
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
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Orders_Orderid",
                table: "Dish",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Orders_Orderid",
                table: "Dish");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DOB",
                table: "User",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "quantity",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderAmount = table.Column<int>(type: "int", nullable: false),
                    orderDate = table.Column<DateOnly>(type: "date", nullable: false),
                    quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Order_Orderid",
                table: "Dish",
                column: "Orderid",
                principalTable: "Order",
                principalColumn: "id");
        }
    }
}
