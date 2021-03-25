using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerShop.Migrations
{
    public partial class ReplaceProductTableWithComputerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenSize = table.Column<double>(type: "float", nullable: true),
                    ScreenType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: false),
                    ClockSpeed = table.Column<double>(type: "float", nullable: false),
                    RAM = table.Column<int>(type: "int", nullable: false),
                    Storage = table.Column<int>(type: "int", nullable: false),
                    GPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computer_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computer_CategoryId",
                table: "Computer",
                column: "CategoryId");

            migrationBuilder.InsertData(
                table: "Computer",
                columns: new[] { "Id", "CPU", "CategoryId", "ClockSpeed", "Color", "Cores", "GPU", "Image", "Name", "Price", "RAM", "ScreenSize", "ScreenType", "Storage" },
                values: new object[,]
                {
                    { "0e437e87-e6ce-4eaf-ae27-d2b3eae3515c", "AMD Ryzen™ 5 4600H", 1, 3.0, "Black", 6, "NVIDIA GeForce GTX 1650 Ti 4GB", "lenovo.jpg", "Lenovo IdeaPad Gaming 3 15ARH05", 839.0, 8, 15.6, "FullHD IPS 60Hz", 256 },
                    { "3ddd1552-d313-4544-ad82-2c8e44a44fa4", "AMD Ryzen 3 4300U", 1, 2.7000000000000002, "Silver", 4, "AMD Radeon", "acer.jpg", "Acer Aspire 5 A515-44-R415", 499.99000000000001, 4, 15.6, "IPS Full HD", 256 },
                    { "3683cffb-3f2b-48b4-86e5-2727a7ad2d8f", "AMD Ryzen™ 3 4300U", 1, 2.7000000000000002, "Black", 4, "AMD Radeon", "lenovo_2.jpg", "Lenovo ThinkPadT E14 GEN 2", 499.99000000000001, 8, 14.0, "Full HD", 256 },
                    { "1c14d6b7-c165-4527-a601-d3669e1c0966", "Intel® Core™ i5-10300H", 1, 2.5, "Blue", 4, "Geforce GTX 1650 4GB", "lenovo_3.jpg", "LENOVO Gaming 3", 688.0, 8, 15.6, "Full HD", 256 },
                    { "93065899-890f-4cef-ba3a-fa32d1934155", "Intel Celeron N4000", 1, 1.1000000000000001, "Dark Grey", 2, "Intel UHD Graphics 600", "hp.jpg", "HP 250 G7", 394.0, 4, 15.6, "Full HD", 128 },
                    { "fb6d71b0-50fe-42fd-90b3-387fc63ef422", "AMD Ryzen™ 5 4500U", 1, 2.2999999999999998, "Grey", 6, "AMD Radeon", "lenovo_4.jpg", "Lenovo Yoga Slim 7", 749.0, 8, 14.0, "IPS Full HD", 512 },
                    { "f78a9382-a8f2-454d-ae8a-ef364da9186d", "Intel® Core™ i7-9700K", 2, 3.6000000000000001, "Black", 8, "GeForce™ GTX 1660 Ti 6GB", "EVOLIUCINIS.jpg", "EVOLIUCINIS i7 X8", 999.99000000000001, 8, null, null, 480 },
                    { "c85a55a3-432e-402f-b956-1ff094332e97", "Intel® Core™ i9-9900K", 2, 3.6000000000000001, "Black", 8, "MSI GEFORCE® RTX 2080 SUPER 8 GB", "MSI_EXTREME.jpg", "MSI EXTREME", 1799.99, 16, null, null, 500 },
                    { "0723df6d-e484-48b3-bd1e-efde35d8c52a", "AMD Ryzen™ 5 2600", 2, 3.3999999999999999, "Black", 6, "GeForce™ GTX 1650 4GB", "RYZEN_5_GT2.jpg", "RYZEN 5 GT2", 499.99000000000001, 8, null, null, 480 },
                    { "0fd0e843-9dd8-41e3-a104-729c4feb2dac", "AMD Ryzen™ 5 2600", 2, 3.3999999999999999, "Black", 6, "GeForce™ GTX 1660 6GB", "RYZEN_5_GTX.jpg", "RYZEN 5 GTX", 599.99000000000001, 8, null, null, 480 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computer");
        }
    }
}
