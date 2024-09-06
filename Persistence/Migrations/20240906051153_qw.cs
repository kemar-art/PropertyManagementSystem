using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class qw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8831b33e-4d3c-4f79-92d9-902e0b323034", new DateTime(2024, 9, 6, 0, 11, 52, 817, DateTimeKind.Local).AddTicks(6081), new DateTime(2024, 9, 6, 0, 11, 52, 817, DateTimeKind.Local).AddTicks(6072), new DateTime(2024, 9, 6, 0, 11, 52, 817, DateTimeKind.Local).AddTicks(6081), "AQAAAAIAAYagAAAAEHD9UG7QVdJ64huzZ3a4WW5tO9ccWpv+jUJId1E98fiI7XxlxSuFcQuyg+/Vr8CDVw==", "b8d92894-637a-4d01-a423-29c23b7af17e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec217ffa-9a80-4c2a-ab97-b620edc6b2e3", new DateTime(2024, 9, 6, 0, 11, 52, 777, DateTimeKind.Local).AddTicks(8229), new DateTime(2024, 9, 6, 0, 11, 52, 777, DateTimeKind.Local).AddTicks(8218), new DateTime(2024, 9, 6, 0, 11, 52, 777, DateTimeKind.Local).AddTicks(8229), "AQAAAAIAAYagAAAAELkPh9/96CJaZRAo23Oq1MoUBjYSs94RPpBOs+rWA81d/slaL7hQOGbP8tFX3chMKw==", "8c973a9c-7f17-46b4-ab50-4c862b24fb12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fac54c2-38e0-4507-8c12-5008e6462eef", new DateTime(2024, 9, 6, 0, 11, 52, 856, DateTimeKind.Local).AddTicks(2267), new DateTime(2024, 9, 6, 0, 11, 52, 856, DateTimeKind.Local).AddTicks(2254), new DateTime(2024, 9, 6, 0, 11, 52, 856, DateTimeKind.Local).AddTicks(2266), "AQAAAAIAAYagAAAAEAwBoJ30x0gE/M1zfX4L6s10/zyV+851C8Mw6EtJqTozXS9u4g0l5l4g2Bphh66IPQ==", "9c966189-3116-4e36-a599-24fd03b84692" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8448b74c-1ba8-4ea3-8392-d09121754d43", new DateTime(2024, 9, 6, 0, 8, 44, 117, DateTimeKind.Local).AddTicks(3823), new DateTime(2024, 9, 6, 0, 8, 44, 117, DateTimeKind.Local).AddTicks(3816), new DateTime(2024, 9, 6, 0, 8, 44, 117, DateTimeKind.Local).AddTicks(3823), "AQAAAAIAAYagAAAAEMl22W6TELTpAImSGH4gAa6DlER3GMvd3gKQjIBKXWhCRmQkJM8WGWhpk/ibfGXrTA==", "1fb29f3e-d6f8-4fd5-b01c-73d66156f0c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e574641-aad3-4d51-802e-3629097d64f3", new DateTime(2024, 9, 6, 0, 8, 44, 78, DateTimeKind.Local).AddTicks(7870), new DateTime(2024, 9, 6, 0, 8, 44, 78, DateTimeKind.Local).AddTicks(7860), new DateTime(2024, 9, 6, 0, 8, 44, 78, DateTimeKind.Local).AddTicks(7869), "AQAAAAIAAYagAAAAEGRdY7VVHqZy6R54MCUxnsrMOeUknYveXskNWrMZscjz/38WxkOSDQJd51t6gIbflw==", "c47222b8-e5d6-4947-b426-b4965044b445" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c383ce7-2fe4-484d-a5e6-16ff521b5b09", new DateTime(2024, 9, 6, 0, 8, 44, 156, DateTimeKind.Local).AddTicks(8067), new DateTime(2024, 9, 6, 0, 8, 44, 156, DateTimeKind.Local).AddTicks(8053), new DateTime(2024, 9, 6, 0, 8, 44, 156, DateTimeKind.Local).AddTicks(8067), "AQAAAAIAAYagAAAAEHmW2JT/vanLJTNVtffMZBwM5dZuCipeCk5V3wbw+uT+iBA/HPEwGwHdd1Gcvpvt6Q==", "21f555e5-fca2-475e-a77a-00a5c818f793" });
        }
    }
}
