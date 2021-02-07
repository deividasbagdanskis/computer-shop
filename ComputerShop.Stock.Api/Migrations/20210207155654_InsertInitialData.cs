using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerShop.Stock.Api.Migrations
{
    public partial class InsertInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StockItem",
                columns: new[] { "Id", "AmountInStock", "ProductId" },
                values: new object[,]
                {
                    { 1, 5, 1 },
                    { 2, 9, 2 },
                    { 3, 7, 3 },
                    { 4, 14, 4 },
                    { 5, 8, 5 },
                    { 6, 0, 6 },
                    { 7, 6, 7 },
                    { 8, 12, 8 },
                    { 9, 3, 9 },
                    { 10, 4, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
