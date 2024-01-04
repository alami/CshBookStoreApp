using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserNRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "008cc011-8a21-4b78-a067-9b7aaf42f007", null, "User", "USER" },
                    { "7cf0e504-3ed4-4637-b5be-5d6a8bb88250", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3d23071b-a9de-429d-8004-0f339f7d8592", 0, "bec70659-b233-4264-924a-d53a8d2d0c4a", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEHqN5yI1CBqZ/j5wYSIr8bhKrFlHT/o5w32sgIOHY2ouGIZ2QD+12qs2wnKkGsV5Ww==", null, false, "8679ba5c-60a8-45d4-9c6c-825ce40957c0", false, "admin@bookstore.com" },
                    { "5e85ffcf-ac47-4b33-bb1a-4311b62815de", 0, "bb050afd-3809-4d9f-aa83-7def678de433", "user@bookstore.com", false, "Simple", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEByArrhGAb80km+jvUU6PJkfj+gF7vNdxf2zCxZozxu/vujFc05DrAhuEBj/kOmNrA==", null, false, "5f6d72bc-200d-4e81-ae90-dc386fb0d009", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7cf0e504-3ed4-4637-b5be-5d6a8bb88250", "3d23071b-a9de-429d-8004-0f339f7d8592" },
                    { "008cc011-8a21-4b78-a067-9b7aaf42f007", "5e85ffcf-ac47-4b33-bb1a-4311b62815de" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7cf0e504-3ed4-4637-b5be-5d6a8bb88250", "3d23071b-a9de-429d-8004-0f339f7d8592" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "008cc011-8a21-4b78-a067-9b7aaf42f007", "5e85ffcf-ac47-4b33-bb1a-4311b62815de" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "008cc011-8a21-4b78-a067-9b7aaf42f007");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cf0e504-3ed4-4637-b5be-5d6a8bb88250");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d23071b-a9de-429d-8004-0f339f7d8592");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e85ffcf-ac47-4b33-bb1a-4311b62815de");
        }
    }
}
