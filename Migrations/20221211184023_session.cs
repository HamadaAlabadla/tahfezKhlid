using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tahfezKhalid.Migrations
{
    public partial class session : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    StudentsNumber = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberPages = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    NumberExams = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    StayNumberExams = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_Session", x => x.Id));

            migrationBuilder.CreateTable(
                name: "UserSession",
                columns: table => new
                {
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSession", x => new { x.userId, x.sessionId });

                    table.ForeignKey(
                        name: "FK_UserSession_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_UserSession_Session_sessionId",
                        column: x => x.sessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "fd9de375-bcb2-4c3d-8e7f-2184fa18f649");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "3c24f995-8f43-49f5-8b6d-a6d1b064d0bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "ab130e08-bc83-4b39-b994-6c6c28f1c048");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e", "9212283a-d437-446e-8d83-79d8cfb0a6bc", "supervisor", "SUPERVISOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae6461a8-f019-4811-9af1-5876f99358be", "AQAAAAEAACcQAAAAEMuyoLWSLKDRGetWjBJuCyJQPsOZfy3i2bz5mHIQDqeCXI/r7iMf8Dv+ZIykev8mwg==", "31afceca-63fa-4904-aa76-7d8e1cec5959" });

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_sessionId",
                table: "UserSession",
                column: "sessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSession");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "be02f20d-e354-4220-aa32-9fbfe450f366");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "aa67a740-bf6d-49e8-8767-7df3e97340e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "09dd2379-5dbd-4e81-a705-b0287fd726fc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98cf17c1-5027-4b26-b790-521af56dc48c", "AQAAAAEAACcQAAAAEMK3QgnV/CxGoAMfwTlSHnVZDBVCEa0LMKVF3YZa+kEm2HTD9voN2gxnvycc9iLRsA==", "e30d1410-cb73-4008-9a6b-7bd73b1e1d17" });
        }
    }
}