using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b3c24a8-fd98-4dd7-8e8e-13b70a7ccc9c", null, "Administrator", "ADMINISTRATOR" },
                    { "1ff8b9a5-91cd-478d-942d-baaca93a4bf9", null, "Appraiser", "APPRAISER" },
                    { "abcf3529-e04c-4fc6-b654-da3f444b3c0c", null, "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "Email", "EmailConfirmed", "FirstName", "Gender", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NationalInsuranceScheme", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxRegistrationNumber", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4cb8218a-f54a-472f-84db-275ff92a659f", 0, "", "e0adf843-f378-4313-8f08-dc63b0950c52", new DateTime(2024, 6, 24, 14, 14, 26, 220, DateTimeKind.Local).AddTicks(6230), new DateTime(2024, 6, 24, 14, 14, 26, 220, DateTimeKind.Local).AddTicks(6217), new DateTime(2024, 6, 24, 14, 14, 26, 220, DateTimeKind.Local).AddTicks(6229), "appraiser@localhost.com", true, "Appraiser", "", "", "Appraiser", false, null, "", "APPRAISER@LOCALHOST.COM", "APPRAISER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEBwE3JNR3t/52kuAPtLSD0cv6QgbXXOA6QxWDgl8m6vzBo0hGcYKLtFXACvfH1IC4g==", null, false, "000fc14d-9ad6-424b-b41c-1b3b21336c04", "", false, "appraiser@localhost.com" },
                    { "588cc79d-bfba-4063-a577-a08a19ff3fba", 0, "", "ebd87459-f10d-4b35-bded-68af6222d440", new DateTime(2024, 6, 24, 14, 14, 26, 161, DateTimeKind.Local).AddTicks(2110), new DateTime(2024, 6, 24, 14, 14, 26, 161, DateTimeKind.Local).AddTicks(2090), new DateTime(2024, 6, 24, 14, 14, 26, 161, DateTimeKind.Local).AddTicks(2110), "admin@localhost.com", true, "Admin", "", "", "Admin", false, null, "", "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEFgr5Z7aHtVyhtmP6EJVRR2GKqAEPiH27Pip4vzxn7Un/pTBHeuXIVMWC6A9pzC0hg==", null, false, "acfad931-c96e-45a9-b59d-754c6b15f41d", "", false, "admin@localhost.com" },
                    { "89d67a78-bd8e-4e72-93dc-602de068282a", 0, "", "40cdb034-5e59-4c50-a3f4-69dcf09b5928", new DateTime(2024, 6, 24, 14, 14, 26, 276, DateTimeKind.Local).AddTicks(9635), new DateTime(2024, 6, 24, 14, 14, 26, 276, DateTimeKind.Local).AddTicks(9632), new DateTime(2024, 6, 24, 14, 14, 26, 276, DateTimeKind.Local).AddTicks(9634), "client@localhost.com", true, "Client", "", "", "Client", false, null, "", "CLIENT@LOCALHOST.COM", "CLIENT@LOCALHOST.COM", "AQAAAAIAAYagAAAAEMf2gbrPeYxElvrElXJw10iz1x8I/Gm3pZr8yOZ3FyLcI+AykrmzGRBGJ9b+WeoHvw==", null, false, "f779fc5e-fa5f-4ffc-a9f9-650913475d22", "", false, "client@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1ff8b9a5-91cd-478d-942d-baaca93a4bf9", "4cb8218a-f54a-472f-84db-275ff92a659f" },
                    { "0b3c24a8-fd98-4dd7-8e8e-13b70a7ccc9c", "588cc79d-bfba-4063-a577-a08a19ff3fba" },
                    { "abcf3529-e04c-4fc6-b654-da3f444b3c0c", "89d67a78-bd8e-4e72-93dc-602de068282a" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1ff8b9a5-91cd-478d-942d-baaca93a4bf9", "4cb8218a-f54a-472f-84db-275ff92a659f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0b3c24a8-fd98-4dd7-8e8e-13b70a7ccc9c", "588cc79d-bfba-4063-a577-a08a19ff3fba" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "abcf3529-e04c-4fc6-b654-da3f444b3c0c", "89d67a78-bd8e-4e72-93dc-602de068282a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b3c24a8-fd98-4dd7-8e8e-13b70a7ccc9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ff8b9a5-91cd-478d-942d-baaca93a4bf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abcf3529-e04c-4fc6-b654-da3f444b3c0c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a");
        }
    }
}
