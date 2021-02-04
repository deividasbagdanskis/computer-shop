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

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "15.6\" FullHD IPS 60Hz ekranas | AMD Ryzen™ 5 4600H | 8GB 3200 Mhz RAM | 256GB SSD PCIe | NVIDIA GeForce GTX 1650 Ti 4GB | Juodas | Klaviatūra su apšvietimu | 82EY004BLT", "lenovo.jpg", "Lenovo IdeaPad Gaming 3 15ARH05", 839.0 },
                    { 2, 1, "15.6\" IPS Full HD ekranas | AMD Ryzen 3 4300U | 4 GB DDR4 RAM | 256 GB SSD | AMD Radeon | Windows 10 Home", "acer.jpg", "Acer Aspire 5 A515-44-R415", 499.99000000000001 },
                    { 3, 1, "14.0\" colių Full HD ekranas | AMD Ryzen™ 3 4300U | 8 GB RAM | 256 GB SSD | DOS", "lenovo_2.jpg", "Lenovo ThinkPadT E14 GEN 2", 499.99000000000001 },
                    { 4, 1, "Intel® Core™ i5-10300H | 15.6\" colių Full HD ekranas | 8GB RAM | 256GB SSD PCIe | Geforce GTX 1650 4GB | 81Y400M7LT", "lenovo_3.jpg", "LENOVO Gaming 3", 688.0 },
                    { 5, 1, "CPU N4000|1100 MHz|15.6\"|1366x768|RAM 4GB|DDR4|2400 MHz|SSD 128GB|Intel UHD Graphics 600|Integrated|ENG|DOS|Dark Grey|1.78 kg|6MP93EA", "hp.jpg", "HP 250 G7", 394.0 },
                    { 6, 1, "AMD Ryzen™ 5 4500U | 14\" IPS Full HD ekranas | 8GB RAM | 512GB SSD | Windows 10 | Pilkas | 82A2008GLT", "lenovo_4.jpg", "Lenovo Yoga Slim 7", 749.0 },
                    { 7, 2, "Intel® Core™ i7-9700K ~4.9Ghz ( Naujiena, 8-ių branduolių ) / 8GB DDR4 3000MHz / 480 GB SSD / GeForce™ GTX 1660 Ti 6GB / USB3.1 / HDMI / 171220_n_z390", "EVOLIUCINIS.jpg", "EVOLIUCINIS i7 X8", 999.99000000000001 },
                    { 8, 2, "Intel® Core™ i9-9900K 3.6~5.0Ghz („CoffeeLake“) | MSI MAG Z390 TOMAHAWK | 16GB DDR4 | 500GB NVMe M.2 SSD (Skaitymo greitis ~3400 MB/s) | MSI GEFORCE® RTX 2080 SUPER 8 GB| “Powered by MSI” | 180628_s", "MSI_EXTREME.jpg", "MSI EXTREME", 1799.99 },
                    { 9, 2, "AMD Ryzen™ 5 2600 | A320 | 8GB DDR4 | 480GB SSD (Skaitymo greitis ~560 MB/s) | GeForce™ GTX 1650 4GB | 180991_d2_1650", "RYZEN_5_GT2.jpg", "RYZEN 5 GT2", 499.99000000000001 },
                    { 10, 2, "AMD Ryzen™ 5 2600 | 8GB DDR4 | 480GB SSD (Skaitymo greitis ~560 MB/s) | GeForce™ GTX 1660 6GB | 180994_L2 ", "RYZEN_5_GT2.jpg", "RYZEN 5 GTX", 599.99000000000001 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4da10ed4-c64f-45c0-8647-be2ecd37e517");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

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
