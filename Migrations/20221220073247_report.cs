using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tahfezKhalid.Migrations
{
    public partial class report : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    SurahSavedFrom = table.Column<int>(type: "int", nullable: false),
                    VerseSavedFrom = table.Column<int>(type: "int", nullable: false),
                    SurahSavedTo = table.Column<int>(type: "int", nullable: false),
                    VerseSavedTo = table.Column<int>(type: "int", nullable: false),
                    NumPagesSaved = table.Column<double>(type: "float", nullable: false),
                    SurahReviewFrom = table.Column<int>(type: "int", nullable: false),
                    VerseReviewFrom = table.Column<int>(type: "int", nullable: false),
                    SurahReviewTo = table.Column<int>(type: "int", nullable: false),
                    VerseReviewTo = table.Column<int>(type: "int", nullable: false),
                    NumPagesReview = table.Column<double>(type: "float", nullable: false),
                    DateReport = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyReport_Students_IdentificationNumber_studentId",
                        columns: x => new { x.IdentificationNumber, x.studentId },
                        principalTable: "Students",
                        principalColumns: new[] { "IdentificationNumber", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "adffa6d3-09ff-4f45-a38f-37cd5fc1ce84");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "5e915770-9f76-496b-ac04-9523f3810756");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e",
                column: "ConcurrencyStamp",
                value: "ae218760-cb78-49bd-8c7a-3b6bcbbdb193");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "21141189-5676-4ca7-9aa1-36f8cbc17dcc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c5f5256-abfa-47a9-bb4d-c2a3f52fa73d", "AQAAAAEAACcQAAAAEAJ8i/M1CO5/XLtUeJeYjD4V3jdgWp9wYDmWo1PA+huDR0B0ZDamgGhxWryJ76RQcw==", "eba8d53d-595e-450f-ba7f-e178655525fd" });

            migrationBuilder.CreateIndex(
                name: "IX_DailyReport_IdentificationNumber_studentId",
                table: "DailyReport",
                columns: new[] { "IdentificationNumber", "studentId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyReport");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "d62ef38f-8b20-4f57-b8ed-dca373796e9b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "b7177f09-3218-4dd5-b8ed-17b58c7188b3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e",
                column: "ConcurrencyStamp",
                value: "1ca1e025-a857-4131-883e-c31c0a0abe63");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "d54ebedd-1239-4eb6-a2de-ce039c91659b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c694bc3-c02b-41ce-932d-39bc88fea3d3", "AQAAAAEAACcQAAAAEMJaCBRY22voLc06YX8VYX6MoRazo4b86CxFaPzSfEZFukosxT93FxBzwchaKv7MNg==", "51c102b3-e46c-415a-81de-cb852bcea8ed" });
        }
    }
}
