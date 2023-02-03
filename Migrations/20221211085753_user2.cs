using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tahfezKhalid.Migrations
{
    public partial class user2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "327e205c-4ac8-4498-b4b6-7dbf7dc69a9a", "AQAAAAEAACcQAAAAEMZIe47uVwYV287e46VjKMG+7C8g69RMeUwSZllaFJmBN0J0lT90S5DLJ+FDksrh3A==", "e7b16ec1-a7c0-4490-bd36-37bcf33718d6", "407069541" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "8fe64816-c515-4f9d-8a22-f8960b8a658a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "50e5705e-cb60-4ff2-946b-d9b9dc5c42a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "9114b511-9b62-463e-afb4-dee4a56b1bd8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "da994e83-f8ba-4e1e-aec4-fcda4b6d9267", "AQAAAAEAACcQAAAAEGx+dtLRFwXiT8Xu1uLc3rcMjXmdksEW6mnRNHB5gV87NLeXOOYsjbB1Ba6E2+uR0Q==", "57211cab-47b9-4c36-8f48-3608be07938e", null });
        }
    }
}
