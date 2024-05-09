using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodToOrderApi.Migrations
{
    /// <inheritdoc />
    public partial class DBSETAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDishes_Dishes_d_id",
                table: "OrderDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDishes_Orders_o_id",
                table: "OrderDishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDishes",
                table: "OrderDishes");

            migrationBuilder.RenameTable(
                name: "OrderDishes",
                newName: "OrderDish");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDishes_d_id",
                table: "OrderDish",
                newName: "IX_OrderDish_d_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDish",
                table: "OrderDish",
                columns: new[] { "o_id", "d_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Dishes_d_id",
                table: "OrderDish",
                column: "d_id",
                principalTable: "Dishes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Orders_o_id",
                table: "OrderDish",
                column: "o_id",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDish_Dishes_d_id",
                table: "OrderDish");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDish_Orders_o_id",
                table: "OrderDish");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDish",
                table: "OrderDish");

            migrationBuilder.RenameTable(
                name: "OrderDish",
                newName: "OrderDishes");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDish_d_id",
                table: "OrderDishes",
                newName: "IX_OrderDishes_d_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDishes",
                table: "OrderDishes",
                columns: new[] { "o_id", "d_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDishes_Dishes_d_id",
                table: "OrderDishes",
                column: "d_id",
                principalTable: "Dishes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDishes_Orders_o_id",
                table: "OrderDishes",
                column: "o_id",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
