using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tahfezKhalid.Migrations
{
    public partial class reportAbsence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemorizerNew",
                table: "DailyReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    dateAbsence = table.Column<DateTime>(type: "datetime2", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    studentIdentificationNumber = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    studentId1 = table.Column<int>(type: "int", nullable: false),
                    TypeAbsence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => new { x.dateAbsence, x.Id });
                    table.ForeignKey(
                        name: "FK_Absences_Students_studentIdentificationNumber_studentId1",
                        columns: x => new { x.studentIdentificationNumber, x.studentId1 },
                        principalTable: "Students",
                        principalColumns: new[] { "IdentificationNumber", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "0e1149d5-8f69-4353-baaa-f7e0824d3fd4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "28f73714-5a1d-4f5f-b461-bdd1420c912c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e",
                column: "ConcurrencyStamp",
                value: "6520efbe-65cd-4b7c-a657-0766114c6cf6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "fec052b6-fdc8-4eb4-aca7-e0e0eb0c3f8c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fb9cdd7-d312-475e-87cd-3a7ad490edcc", "AQAAAAEAACcQAAAAEFzs1qG3ZZmASQjTQNPTmdmFbZHNTOJ2NJAy2tC9hMQ/Xw4jcJH4C8OrMjUdj5VM+Q==", "88260d52-815a-4a63-ad85-5b20f0fa5cf3" });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_studentIdentificationNumber_studentId1",
                table: "Absences",
                columns: new[] { "studentIdentificationNumber", "studentId1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropColumn(
                name: "MemorizerNew",
                table: "DailyReport");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "b4ef6176-e4bb-48d3-b354-94e8e03db712");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "ab307a0a-75bb-4ad4-ab90-7362713ff8ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e",
                column: "ConcurrencyStamp",
                value: "020f5953-addd-466f-8f4f-7cdb92a00ad6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "1927131d-e9c6-419f-9e4c-a074afd06ca3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91087b00-7c0c-42a6-9db7-04794e2df878", "AQAAAAEAACcQAAAAEJnewApjKILQ8hyp6yHm3TftO98qgyN2z9zSYNneMONraDad7rtmWEDJUAXVHVPhzQ==", "e0c0e826-dfa3-477c-a995-83476e156242" });
        }
    }
}
