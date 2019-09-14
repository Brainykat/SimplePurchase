using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileMoney.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MobileMoney");

            migrationBuilder.CreateTable(
                name: "Inventories",
                schema: "MobileMoney",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(maxLength: 16, nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    Reference = table.Column<string>(maxLength: 25, nullable: false),
                    TxnTime = table.Column<DateTime>(nullable: false),
                    Amount_Currency = table.Column<string>(maxLength: 6, nullable: true),
                    Amount_Amount = table.Column<decimal>(nullable: true),
                    Amount_Time = table.Column<DateTime>(nullable: true),
                    InternalRefId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories",
                schema: "MobileMoney");
        }
    }
}
