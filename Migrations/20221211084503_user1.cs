using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tahfezKhalid.Migrations
{
    public partial class user1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1512fd48-56b8-407a-8547-271fea42ca72", "8fe64816-c515-4f9d-8a22-f8960b8a658a", "admin", "ADMIN" },
                    { "1b50282d-c47e-4873-99c0-4b0124f1c26e", "50e5705e-cb60-4ff2-946b-d9b9dc5c42a1", "parent", "PARENT" },
                    { "db614589-c68b-4633-a0a6-5d3518eda78e", "9114b511-9b62-463e-afb4-dee4a56b1bd8", "memorizer", "MEMORIZER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IdentificationNumber", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "TypeUser", "UserName" },
                values: new object[] { "1512fd48-56b8-407a-8547-271fea42ca72", 0, "da994e83-f8ba-4e1e-aec4-fcda4b6d9267", null, false, "407069541", false, null, "حماده حسام العبادلة", null, null, "AQAAAAEAACcQAAAAEGx+dtLRFwXiT8Xu1uLc3rcMjXmdksEW6mnRNHB5gV87NLeXOOYsjbB1Ba6E2+uR0Q==", "0595195186", false, "57211cab-47b9-4c36-8f48-3608be07938e", false, 0, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1512fd48-56b8-407a-8547-271fea42ca72", "1512fd48-56b8-407a-8547-271fea42ca72" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b50282d-c47e-4873-99c0-4b0124f1c26e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db614589-c68b-4633-a0a6-5d3518eda78e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1512fd48-56b8-407a-8547-271fea42ca72", "1512fd48-56b8-407a-8547-271fea42ca72" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1512fd48-56b8-407a-8547-271fea42ca72");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");
        }
    }
}
