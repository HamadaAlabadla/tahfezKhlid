using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tahfezKhalid.Migrations
{
    public partial class studentnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Students_studentIdentificationNumber_studentId1",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyReport_Students_IdentificationNumber_studentId",
                table: "DailyReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_DailyReport_IdentificationNumber_studentId",
                table: "DailyReport");

            migrationBuilder.DropIndex(
                name: "IX_Absences_studentIdentificationNumber_studentId1",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                table: "DailyReport");

            migrationBuilder.DropColumn(
                name: "studentIdentificationNumber",
                table: "Absences");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "studentId",
                table: "DailyReport",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "studentId1",
                table: "Absences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "65314982-5f00-4544-b36e-fff035d84f8c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "0bed43a7-ac39-4cf8-b805-219e02796f89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e",
                column: "ConcurrencyStamp",
                value: "3785f1f8-d388-4c0f-8190-3a6472a7cb9f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "5438c0d7-3a8a-4bda-b441-f041c7433b9a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5eba112f-f334-4d3a-b82c-eeda032c1068", "4070695410", "AQAAAAEAACcQAAAAEFZVLJwTx/O2Y3k8JLqFIGGJGz7kYm0o3JmdSPPbWwvmX3hTiw6uNLQESyq7mcwu6g==", "200dfeb3-b485-48f7-9181-ca4a6ddd5a70" });

            migrationBuilder.CreateIndex(
                name: "IX_DailyReport_studentId",
                table: "DailyReport",
                column: "studentId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReport_Students_studentId",
                table: "DailyReport",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Students_studentId1",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyReport_Students_studentId",
                table: "DailyReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_DailyReport_studentId",
                table: "DailyReport");

            migrationBuilder.DropIndex(
                name: "IX_Absences_studentId1",
                table: "Absences");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "studentId",
                table: "DailyReport",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IdentificationNumber",
                table: "DailyReport",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "studentId1",
                table: "Absences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "studentIdentificationNumber",
                table: "Absences",
                type: "nvarchar(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                columns: new[] { "IdentificationNumber", "Id" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "65fe761a-7d67-4753-a891-0795fd29a102");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "d19168a5-c443-4a16-8220-fd771d02a77a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e",
                column: "ConcurrencyStamp",
                value: "bba4921b-024a-4ecd-a922-0699c37ce98d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "d8130867-1cdd-4e3d-b2d5-903e35ea5644");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e39a4860-2c86-4a17-b996-74f2e4d6137a", "407069541", "AQAAAAEAACcQAAAAEPGuydkuxpLRYJUjILTfcrIeZqhlGnYvzyr02vrUrHtltNLt242i2iC4+SuZCtJG9A==", "4180d4b7-70b6-43d1-ad74-27e776e79e1d" });

            migrationBuilder.CreateIndex(
                name: "IX_DailyReport_IdentificationNumber_studentId",
                table: "DailyReport",
                columns: new[] { "IdentificationNumber", "studentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_studentIdentificationNumber_studentId1",
                table: "Absences",
                columns: new[] { "studentIdentificationNumber", "studentId1" });

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Students_studentIdentificationNumber_studentId1",
                table: "Absences",
                columns: new[] { "studentIdentificationNumber", "studentId1" },
                principalTable: "Students",
                principalColumns: new[] { "IdentificationNumber", "Id" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReport_Students_IdentificationNumber_studentId",
                table: "DailyReport",
                columns: new[] { "IdentificationNumber", "studentId" },
                principalTable: "Students",
                principalColumns: new[] { "IdentificationNumber", "Id" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
