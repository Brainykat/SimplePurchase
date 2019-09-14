using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Maintenance.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Maintenance");

            migrationBuilder.CreateTable(
                name: "Banks",
                schema: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 6, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                schema: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 6, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    BankId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_Banks_BankId",
                        column: x => x.BankId,
                        principalSchema: "Maintenance",
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_BankId",
                schema: "Maintenance",
                table: "Branch",
                column: "BankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branch",
                schema: "Maintenance");

            migrationBuilder.DropTable(
                name: "Banks",
                schema: "Maintenance");
        }
    }
}
