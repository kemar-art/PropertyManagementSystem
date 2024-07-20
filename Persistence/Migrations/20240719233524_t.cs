using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class t : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Volume",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Folio",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd3cb8a9-d0d0-4474-9c42-568cd601e9cd", new DateTime(2024, 7, 19, 18, 35, 23, 982, DateTimeKind.Local).AddTicks(2933), new DateTime(2024, 7, 19, 18, 35, 23, 982, DateTimeKind.Local).AddTicks(2930), new DateTime(2024, 7, 19, 18, 35, 23, 982, DateTimeKind.Local).AddTicks(2933), "AQAAAAIAAYagAAAAEM4IldmTDIn6MxEZR2cDLSeuRiPQYS/uz0uYXCW54rb8Kj7f4pNevOJC0mta6vA35Q==", "bfd25550-1373-4f33-bc4f-8617d3b2b547" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4be8a499-aa59-4d6a-b9df-d7f3c3cd96a0", new DateTime(2024, 7, 19, 18, 35, 23, 943, DateTimeKind.Local).AddTicks(9720), new DateTime(2024, 7, 19, 18, 35, 23, 943, DateTimeKind.Local).AddTicks(9713), new DateTime(2024, 7, 19, 18, 35, 23, 943, DateTimeKind.Local).AddTicks(9720), "AQAAAAIAAYagAAAAEOflBnIQzO1q1tN918oiTVnHw6AeYz3z35AbFCPfnJ63laAep7HTmzIvsG8/k/omJQ==", "052ad39c-4a72-4dbf-bdb5-caf80afb7e27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bde8e322-514a-4f35-977c-22ac4e644bcf", new DateTime(2024, 7, 19, 18, 35, 24, 21, DateTimeKind.Local).AddTicks(6046), new DateTime(2024, 7, 19, 18, 35, 24, 21, DateTimeKind.Local).AddTicks(6042), new DateTime(2024, 7, 19, 18, 35, 24, 21, DateTimeKind.Local).AddTicks(6046), "AQAAAAIAAYagAAAAEFINRQKEcC9fLTDFkH5kpf6Ig0Z4KSPjqzz9GM6S4w0IhCzTSteS2qxkz+/r+cvtSQ==", "73833167-daaa-46e9-be1c-73a7f5c10d4a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Volume",
                table: "Forms",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Folio",
                table: "Forms",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aea7c575-1fb8-4ada-91af-cf7ad83c1e46", new DateTime(2024, 7, 18, 19, 6, 5, 397, DateTimeKind.Local).AddTicks(7838), new DateTime(2024, 7, 18, 19, 6, 5, 397, DateTimeKind.Local).AddTicks(7833), new DateTime(2024, 7, 18, 19, 6, 5, 397, DateTimeKind.Local).AddTicks(7838), "AQAAAAIAAYagAAAAEP786BwfrwbQWPgFpFqsIUcDTtmSBUD538LurdACZkKqnFL62rM7Xd+Bg6K/47ky6A==", "95f1ed38-bbed-4437-bb36-122a1c51dd26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54c9fcf2-32f1-41b1-864b-19add1412e5a", new DateTime(2024, 7, 18, 19, 6, 5, 357, DateTimeKind.Local).AddTicks(6625), new DateTime(2024, 7, 18, 19, 6, 5, 357, DateTimeKind.Local).AddTicks(6617), new DateTime(2024, 7, 18, 19, 6, 5, 357, DateTimeKind.Local).AddTicks(6625), "AQAAAAIAAYagAAAAEDVac+LiHYNw0FBxjVQFUsR/CHFgIT1GptOly/X4rETXEbG0TodCc5oGIgDlr7uSZw==", "39b1a5b7-0bdb-4693-9571-91f7e67d9a1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30d6eaf2-3abf-4ddc-92af-e96a410785d0", new DateTime(2024, 7, 18, 19, 6, 5, 438, DateTimeKind.Local).AddTicks(5541), new DateTime(2024, 7, 18, 19, 6, 5, 438, DateTimeKind.Local).AddTicks(5536), new DateTime(2024, 7, 18, 19, 6, 5, 438, DateTimeKind.Local).AddTicks(5541), "AQAAAAIAAYagAAAAEF87sLhD8tSZMx8OxCQmkX0SXqnEA5xCiwtMf9sGA7C+itFPUwTDwy5j7aU5yReTUg==", "8f8bef5f-a71f-46ad-b17f-656498ef0a58" });
        }
    }
}
