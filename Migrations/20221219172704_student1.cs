using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tahfezKhalid.Migrations
{
    public partial class student1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                column: "ConcurrencyStamp",
                value: "0d6404d3-504d-4b07-bcff-a16db58ef24b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e",
                column: "ConcurrencyStamp",
                value: "d7a50f04-09cb-4cf7-ad69-fa029d3d66e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bg4282d-ca7e-4873-99c0-4b0fe4f12f6e",
                column: "ConcurrencyStamp",
                value: "490ce85e-8667-494f-930a-af8b37341337");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e",
                column: "ConcurrencyStamp",
                value: "08d153ef-409f-4544-9e6f-3e881410fe1a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d603d516-aa22-49f4-ad98-6e71750d8e69", "AQAAAAEAACcQAAAAEPN/9FoR/U0XDNT/GDsbPmEGg0h7BJqUNndkQfpNlB6euqEDKAf3pnfVUbnG4AcXzw==", "c4da8698-1eef-4dca-888b-385d0c758181" });
        }
    }
}
