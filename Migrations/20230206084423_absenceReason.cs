using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tahfezKhalid.Migrations
{
    public partial class absenceReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Students_studentId1",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_studentId1",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "studentId1",
                table: "Absences");

            migrationBuilder.AlterColumn<string>(
                name: "studentId",
                table: "Absences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "reason",
                table: "Absences",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "d13137b2-4615-4f46-9ed1-a38234405958");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "f789aa0c-8a61-46f0-822d-3cade4348e38");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e",
                column: "ConcurrencyStamp",
                value: "47f27b77-9079-4a37-a473-ad2a2f62b92c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "bb635821-cde9-4196-87fa-80e253cdb455");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5745235a-5b74-4d94-a788-7a86e9603140", "AQAAAAEAACcQAAAAEBiKfJuUDJAGC4Kff0QC5q1JVeRFk6mYj8n3RnkqzNtVedmuQImoC+3Ta/x6dI4Cpw==", "68bf82c2-e4c5-4a53-a23c-2e60b6bb2415" });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_studentId",
                table: "Absences",
                column: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Students_studentId",
                table: "Absences",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Students_studentId",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_studentId",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "reason",
                table: "Absences");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "Absences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "studentId1",
                table: "Absences",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "8b1fd7d2-056b-43c9-b0a3-6fd87ed59019");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "58045918-c527-43eb-a5bf-91183069df94");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e",
                column: "ConcurrencyStamp",
                value: "8b9b8201-e19d-43b3-9dfd-f7a03dcb380a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "bef3a48d-1e44-404b-b692-d14ea41a6a4a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a146ad63-ae49-4dee-a8ca-ee669a29ba90", "AQAAAAEAACcQAAAAEEDNZdiiAIaeZ5emC7bDF9pulS5u1NNFWXhlPScG34/qe54vD1/Xv2WV4VT9Eji2kw==", "0cd7e184-cdc3-421d-8792-757a8eaef62c" });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_studentId1",
                table: "Absences",
                column: "studentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Students_studentId1",
                table: "Absences",
                column: "studentId1",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
