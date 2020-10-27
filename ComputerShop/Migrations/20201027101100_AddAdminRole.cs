using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ComputerShop.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id" ,"Name" },
                values: new object[] { Guid.NewGuid().ToString(), "Admin" }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM AspNetRoles", true);
        }
    }
}
