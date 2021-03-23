using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerShop.Migrations
{
    public partial class AddedRecommendationStatsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecommendationStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecommendedCount = table.Column<int>(type: "int", nullable: false),
                    BoughtCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationStats", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RecommendationStats",
                columns: new[] { "Id", "BoughtCount", "RecommendedCount" },
                values: new object[] { 1, 0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecommendationStats");
        }
    }
}
