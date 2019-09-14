using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventories.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Inventory");

            migrationBuilder.CreateTable(
                name: "Inventories",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    PurchaseId = table.Column<Guid>(nullable: false),
                    AddedOn = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    InventoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    BarCode = table.Column<string>(maxLength: 120, nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Expirery = table.Column<DateTime>(nullable: false),
                    IsPOSItem = table.Column<bool>(nullable: false),
                    ItemType = table.Column<int>(nullable: false),
                    SellingPrice_Currency = table.Column<string>(maxLength: 6, nullable: true),
                    SellingPrice_Amount = table.Column<decimal>(nullable: true),
                    SellingPrice_Time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "Inventory",
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_InventoryId",
                schema: "Inventory",
                table: "Item",
                column: "InventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Inventories",
                schema: "Inventory");
        }
    }
}
