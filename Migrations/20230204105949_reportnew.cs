using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tahfezKhalid.Migrations
{
    public partial class reportnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemorizerNew",
                table: "DailyReport");

            migrationBuilder.AddColumn<bool>(
                name: "View",
                table: "DailyReport",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "View",
                table: "DailyReport");

            migrationBuilder.AddColumn<string>(
                name: "MemorizerNew",
                table: "DailyReport",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5eba112f-f334-4d3a-b82c-eeda032c1068", "AQAAAAEAACcQAAAAEFZVLJwTx/O2Y3k8JLqFIGGJGz7kYm0o3JmdSPPbWwvmX3hTiw6uNLQESyq7mcwu6g==", "200dfeb3-b485-48f7-9181-ca4a6ddd5a70" });
        }
    }
}
