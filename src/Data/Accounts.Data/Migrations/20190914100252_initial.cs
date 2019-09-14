using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounts.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Accounts");

            migrationBuilder.CreateTable(
                name: "ChartOfAccounts",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    AccountType = table.Column<int>(nullable: false),
                    Statement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    WholeSalerId = table.Column<Guid>(nullable: true),
                    OMCId = table.Column<Guid>(nullable: true),
                    RetailerId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    AccountNumber_COACODE = table.Column<int>(nullable: true),
                    AccountNumber_Number = table.Column<long>(nullable: true),
                    AccountNumber_BearerCode = table.Column<string>(maxLength: 3, nullable: true),
                    AccountBearerType = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ChartOfAccountId = table.Column<Guid>(nullable: false),
                    AccountTransactionLimit_Currency = table.Column<string>(maxLength: 6, nullable: true),
                    AccountTransactionLimit_Amount = table.Column<decimal>(nullable: true),
                    AccountTransactionLimit_Time = table.Column<DateTime>(nullable: true),
                    Signatories = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_ChartOfAccounts_ChartOfAccountId",
                        column: x => x.ChartOfAccountId,
                        principalSchema: "Accounts",
                        principalTable: "ChartOfAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    TxnTime = table.Column<DateTime>(nullable: false),
                    Credit_Currency = table.Column<string>(maxLength: 6, nullable: true),
                    Credit_Amount = table.Column<decimal>(nullable: true),
                    Credit_Time = table.Column<DateTime>(nullable: true),
                    Debit_Currency = table.Column<string>(maxLength: 6, nullable: true),
                    Debit_Amount = table.Column<decimal>(nullable: true),
                    Debit_Time = table.Column<DateTime>(nullable: true),
                    TxnRefrence = table.Column<Guid>(nullable: false),
                    ExternalReference = table.Column<Guid>(nullable: false),
                    Narration = table.Column<string>(maxLength: 100, nullable: false),
                    TransactingUser = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Accounts",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ChartOfAccountId",
                schema: "Accounts",
                table: "Accounts",
                column: "ChartOfAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_AccountId",
                schema: "Accounts",
                table: "Wallets",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wallets",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "ChartOfAccounts",
                schema: "Accounts");
        }
    }
}
