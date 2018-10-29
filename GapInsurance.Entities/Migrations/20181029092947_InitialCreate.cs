using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GapInsurance.Entities.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Policies",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    DurationMonths = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    Risk = table.Column<int>(nullable: false),
                    User = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Code = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(maxLength: 100, nullable: false),
                    Coverage = table.Column<decimal>(type: "Decimal(5,2)", nullable: false),
                    PolicyId = table.Column<Guid>(nullable: false),
                    TypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyTypes_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalSchema: "dbo",
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyTypes_Types_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "dbo",
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Policies",
                columns: new[] { "Id", "Description", "DurationMonths", "Name", "Price", "Risk", "StartDate", "User" },
                values: new object[,]
                {
                    { new Guid("f3b81d4a-435b-419b-aff8-4b14070a7e04"), "Test Policy for GAP", 12, "Test 1", 200000m, 1, new DateTime(2018, 10, 29, 9, 29, 47, 127, DateTimeKind.Utc), "TestUser1" },
                    { new Guid("48cfbd55-3803-480e-8f01-99e4c6520b0a"), "Test Policy for GAP", 24, "Test 2", 450000m, 2, new DateTime(2018, 10, 29, 9, 29, 47, 127, DateTimeKind.Utc), "TestUser1" },
                    { new Guid("317d7d79-ea4f-460b-9edc-cd451e47474f"), "Test Policy for GAP", 24, "Test 3", 500000m, 3, new DateTime(2018, 10, 29, 9, 29, 47, 127, DateTimeKind.Utc), "TestUser1" },
                    { new Guid("59a190d6-0676-4edf-9b92-d3ea7c8e92f6"), "Test Policy for GAP", 36, "Test 4", 800000m, 4, new DateTime(2018, 10, 29, 9, 29, 47, 127, DateTimeKind.Utc), "TestUser1" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Types",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("caa9ffe2-05a6-480f-94c2-fb684db53971"), "EQK", "Earthquake" },
                    { new Guid("d7e6f156-c094-4d0f-858d-344790acb60b"), "FR", "Fire" },
                    { new Guid("ff777418-6610-40c2-a6fa-df7bae60f2e2"), "LOS", "Loss" },
                    { new Guid("558f771b-5f46-4914-891b-aa4ed67fd1c9"), "STL", "Theft" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PolicyTypes",
                columns: new[] { "Id", "Comment", "Coverage", "PolicyId", "TypeId" },
                values: new object[,]
                {
                    { new Guid("c30c6a0f-0606-4b41-a552-4e8403e223fc"), "Coverage assigned based on risk", 0.9m, new Guid("f3b81d4a-435b-419b-aff8-4b14070a7e04"), new Guid("caa9ffe2-05a6-480f-94c2-fb684db53971") },
                    { new Guid("96394668-b824-49e1-8bed-3944c9afe758"), "Coverage assigned based on risk", 0.45m, new Guid("59a190d6-0676-4edf-9b92-d3ea7c8e92f6"), new Guid("d7e6f156-c094-4d0f-858d-344790acb60b") },
                    { new Guid("4f9d9fb5-8320-482b-9326-57ab884d4671"), "Coverage assigned based on risk", 0.6m, new Guid("317d7d79-ea4f-460b-9edc-cd451e47474f"), new Guid("ff777418-6610-40c2-a6fa-df7bae60f2e2") },
                    { new Guid("7b58863a-360b-47ba-a08c-e43137b9a007"), "Coverage assigned based on risk", 0.55m, new Guid("48cfbd55-3803-480e-8f01-99e4c6520b0a"), new Guid("558f771b-5f46-4914-891b-aa4ed67fd1c9") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolicyTypes_PolicyId",
                schema: "dbo",
                table: "PolicyTypes",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyTypes_TypeId",
                schema: "dbo",
                table: "PolicyTypes",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Policies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Types",
                schema: "dbo");
        }
    }
}
