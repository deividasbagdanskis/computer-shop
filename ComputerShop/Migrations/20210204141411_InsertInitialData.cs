using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerShop.Migrations
{
    public partial class InsertInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4da10ed4-c64f-45c0-8647-be2ecd37e517", "c23631f5-6916-4ec9-a9c9-dc5eb22e8713", "Administrator", null });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Desktops" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Laptops" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4da10ed4-c64f-45c0-8647-be2ecd37e517");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
