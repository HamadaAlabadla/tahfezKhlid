using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tahfezKhalid.Migrations
{
    public partial class user3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98cf17c1-5027-4b26-b790-521af56dc48c", "407069541", "AQAAAAEAACcQAAAAEMK3QgnV/CxGoAMfwTlSHnVZDBVCEa0LMKVF3YZa+kEm2HTD9voN2gxnvycc9iLRsA==", "e30d1410-cb73-4008-9a6b-7bd73b1e1d17" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "785009e5-c04c-4efa-bd7d-5a8670328f71");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "c448dcc4-f39f-44d2-89af-c2fd15b5df0d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "7d6af6e0-f7c2-4f92-8eae-56c3aeef8088");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "327e205c-4ac8-4498-b4b6-7dbf7dc69a9a", null, "AQAAAAEAACcQAAAAEMZIe47uVwYV287e46VjKMG+7C8g69RMeUwSZllaFJmBN0J0lT90S5DLJ+FDksrh3A==", "e7b16ec1-a7c0-4490-bd36-37bcf33718d6" });
        }
    }
}
