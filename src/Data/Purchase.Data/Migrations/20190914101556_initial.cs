using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Purchase.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Purchase");

            migrationBuilder.CreateTable(
                name: "Branch",
                schema: "Purchase",
                columns: table => new
                {
                    BranchId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Purchase",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "Purchase",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: false),
                    BranchId = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 25, nullable: false),
                    AddedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Purchase",
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                schema: "Purchase",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    SupplierId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    PurchaseStage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Purchase",
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Purchase",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "Purchase",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    PurchaseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "Purchase",
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                schema: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<Guid>(nullable: false),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "Purchase",
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "Purchase",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PurchaseId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    BarCode = table.Column<string>(maxLength: 120, nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    PricePerItem_Currency = table.Column<string>(maxLength: 6, nullable: true),
                    PricePerItem_Amount = table.Column<decimal>(nullable: true),
                    PricePerItem_Time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "Purchase",
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseProcess",
                schema: "Purchase",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PurchaseId = table.Column<Guid>(nullable: false),
                    PurchaseStage = table.Column<int>(nullable: false),
                    Maker = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseProcess_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "Purchase",
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_PurchaseId",
                schema: "Purchase",
                table: "Account",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_PurchaseId",
                schema: "Purchase",
                table: "Document",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_PurchaseId",
                schema: "Purchase",
                table: "Item",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProcess_PurchaseId",
                schema: "Purchase",
                table: "PurchaseProcess",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupplierId",
                schema: "Purchase",
                table: "Purchases",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                schema: "Purchase",
                table: "Purchases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_BranchId",
                schema: "Purchase",
                table: "Suppliers",
                column: "BranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account",
                schema: "Purchase");

            migrationBuilder.DropTable(
                name: "Document",
                schema: "Purchase");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "Purchase");

            migrationBuilder.DropTable(
                name: "PurchaseProcess",
                schema: "Purchase");

            migrationBuilder.DropTable(
                name: "Purchases",
                schema: "Purchase");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "Purchase");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Purchase");

            migrationBuilder.DropTable(
                name: "Branch",
                schema: "Purchase");
        }
    }
}
