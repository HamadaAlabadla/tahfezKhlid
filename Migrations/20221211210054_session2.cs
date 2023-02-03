using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tahfezKhalid.Migrations
{
    public partial class session2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "eb206b89-4f63-4f84-902d-6f1c4d66b687");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "a0c1371c-f386-4db0-811a-2c1b66d8f5be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e",
                column: "ConcurrencyStamp",
                value: "7f1c45f2-2df0-49c3-b0bd-3d7d03ae9642");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "5becd11a-323b-4e38-b194-d31f4a2b1163");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b118dbdd-6c96-495d-b321-67e97d32b686", "AQAAAAEAACcQAAAAEOL7lpRocrbW8yBa+SN/X9ixcldd1lycLDjn87u+csP4hqim38KXR0L76VDgUMNCXw==", "849da4bf-d945-4ba2-9fed-f1c774b95151" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
