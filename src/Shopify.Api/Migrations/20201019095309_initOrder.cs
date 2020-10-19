using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopify.Api.Migrations
{
    public partial class initOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifyTime = table.Column<DateTime>(nullable: false),
                    IsDel = table.Column<bool>(nullable: false),
                    PlatformType = table.Column<int>(nullable: false),
                    PlatformId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    OrderCloseTime = table.Column<string>(nullable: true),
                    OrderCreateTime = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    OrderUpdateTime = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    FinancialStatus = table.Column<string>(nullable: true),
                    FulfillmentStatus = table.Column<string>(nullable: true),
                    LandingSite = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TotalPriceUsd = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
