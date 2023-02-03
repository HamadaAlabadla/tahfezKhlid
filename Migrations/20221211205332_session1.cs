using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tahfezKhalid.Migrations
{
    public partial class session1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Session",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "0c0c6220-bb16-41fc-ac37-3ecdcb982c84");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "18c7dedd-747b-482c-9d7f-84b8e0e4c196");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e",
                column: "ConcurrencyStamp",
                value: "d2e81477-afe8-4337-a258-c67afa50bb28");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "ac8d78b5-607d-4253-921a-4a6cb2cab9b4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87942ca9-74e0-48a1-9ce4-f7f7a73cdae1", "AQAAAAEAACcQAAAAECqV9vavHzgY+Jqdv6bDu+S6y0BEeMiNeyNQHRpbG5DafMYgLMJiwaFjUaJpUYwQYQ==", "87edcfea-3674-48fb-a93a-19b9ac1bbdd0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Session");

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
                keyValue: "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e",
                column: "ConcurrencyStamp",
                value: "9212283a-d437-446e-8d83-79d8cfb0a6bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "ab130e08-bc83-4b39-b994-6c6c28f1c048");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae6461a8-f019-4811-9af1-5876f99358be", "AQAAAAEAACcQAAAAEMuyoLWSLKDRGetWjBJuCyJQPsOZfy3i2bz5mHIQDqeCXI/r7iMf8Dv+ZIykev8mwg==", "31afceca-63fa-4904-aa76-7d8e1cec5959" });
        }
    }
}
