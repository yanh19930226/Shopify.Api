using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopify.Api.Migrations
{
    public partial class updatetypeorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "PlatformOrderId",
                table: "Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlatformOrderId",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "PlatformId",
                table: "Order",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
