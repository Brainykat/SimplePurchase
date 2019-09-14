using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.CreateTable(
                name: "JobTitles",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suffixes",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suffixes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "HR",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    JobTypeId = table.Column<Guid>(nullable: false),
                    JobTitleId = table.Column<Guid>(nullable: false),
                    SuffixId = table.Column<Guid>(nullable: false),
                    JobNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Name_Sur = table.Column<string>(maxLength: 50, nullable: true),
                    Name_First = table.Column<string>(maxLength: 50, nullable: true),
                    Name_Middle = table.Column<string>(maxLength: 50, nullable: true, defaultValue: ""),
                    Phone = table.Column<long>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    GenderId = table.Column<Guid>(nullable: false),
                    MaritalStatusId = table.Column<Guid>(nullable: false),
                    DOB = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    IdTypeId = table.Column<Guid>(nullable: false),
                    IdNumber = table.Column<string>(maxLength: 20, nullable: false),
                    NationalityId = table.Column<Guid>(nullable: false),
                    CountyId = table.Column<Guid>(nullable: false),
                    SecondaryPhone = table.Column<string>(maxLength: 15, nullable: true),
                    PaymentMode = table.Column<int>(nullable: false),
                    BranchId = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 25, nullable: true),
                    BasicSalary_Currency = table.Column<string>(maxLength: 6, nullable: true),
                    BasicSalary_Amount = table.Column<decimal>(nullable: true),
                    BasicSalary_Time = table.Column<DateTime>(nullable: true),
                    HireDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    KraPin = table.Column<string>(nullable: false),
                    NHIF = table.Column<long>(nullable: false),
                    NSSF = table.Column<long>(nullable: false),
                    ReportTo = table.Column<Guid>(nullable: false),
                    IsSystemUser = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalSchema: "HR",
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalSchema: "HR",
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Suffixes_SuffixId",
                        column: x => x.SuffixId,
                        principalSchema: "HR",
                        principalTable: "Suffixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTitleId",
                schema: "HR",
                table: "Employees",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTypeId",
                schema: "HR",
                table: "Employees",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SuffixId",
                schema: "HR",
                table: "Employees",
                column: "SuffixId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "JobTitles",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "JobTypes",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Suffixes",
                schema: "HR");
        }
    }
}
