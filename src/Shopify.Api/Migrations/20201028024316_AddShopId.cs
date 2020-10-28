using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopify.Api.Migrations
{
    public partial class AddShopId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ShopId",
                table: "Order",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Order");
        }
    }
}
