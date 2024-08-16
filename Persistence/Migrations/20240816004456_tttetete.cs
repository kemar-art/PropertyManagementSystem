using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tttetete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f156436-17a7-40d8-9a6b-189ea599814d", new DateTime(2024, 8, 15, 19, 44, 55, 817, DateTimeKind.Local).AddTicks(4594), new DateTime(2024, 8, 15, 19, 44, 55, 817, DateTimeKind.Local).AddTicks(4589), new DateTime(2024, 8, 15, 19, 44, 55, 817, DateTimeKind.Local).AddTicks(4594), "AQAAAAIAAYagAAAAEC7x5XZRooQR5HY5tD8Kd/p+qDA9EPhmOmcWTl7IPmpboxhaSi3aITm3N1UoagFQog==", "65c03989-a8bb-4168-9069-5631e686de3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b854cdf7-81ec-42d9-8b7d-ec19df0a1e09", new DateTime(2024, 8, 15, 19, 44, 55, 776, DateTimeKind.Local).AddTicks(9222), new DateTime(2024, 8, 15, 19, 44, 55, 776, DateTimeKind.Local).AddTicks(9211), new DateTime(2024, 8, 15, 19, 44, 55, 776, DateTimeKind.Local).AddTicks(9222), "AQAAAAIAAYagAAAAEAHOANq1x1USzRZ5+YTkj//CiWfUENNxLWp5hsAXPsEdcVRPRiIaivW9/RuBfg7PfQ==", "fa7c6d47-b4e3-4f86-acb8-b36e99fd447f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1f2213f-876d-4ed1-85d5-fae336620a9f", new DateTime(2024, 8, 15, 19, 44, 55, 855, DateTimeKind.Local).AddTicks(7371), new DateTime(2024, 8, 15, 19, 44, 55, 855, DateTimeKind.Local).AddTicks(7363), new DateTime(2024, 8, 15, 19, 44, 55, 855, DateTimeKind.Local).AddTicks(7371), "AQAAAAIAAYagAAAAEFU7LX4rqSF1E4uEctloxhNBUPhgdK7FouDHXWVr5PvqSzWsCHWvr880Z3jlkIxA1A==", "dbd874f1-7117-4cee-9062-db1757258e34" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37b07aba-a715-466f-90f0-502eb2a3fadb", new DateTime(2024, 8, 15, 10, 41, 57, 731, DateTimeKind.Local).AddTicks(3440), new DateTime(2024, 8, 15, 10, 41, 57, 731, DateTimeKind.Local).AddTicks(3421), new DateTime(2024, 8, 15, 10, 41, 57, 731, DateTimeKind.Local).AddTicks(3439), "AQAAAAIAAYagAAAAEF2tvi3NUcp9x2N2x0VtM9E6cGRb5deyTDnZwqDDL/7LDoYGVKM8m20EHAPVJl6QQQ==", "4ec95644-6fdf-45d3-b328-c74a7c232d7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5bb9c452-3447-4f72-a136-01d8d7ab6691", new DateTime(2024, 8, 15, 10, 41, 57, 674, DateTimeKind.Local).AddTicks(1290), new DateTime(2024, 8, 15, 10, 41, 57, 674, DateTimeKind.Local).AddTicks(1266), new DateTime(2024, 8, 15, 10, 41, 57, 674, DateTimeKind.Local).AddTicks(1290), "AQAAAAIAAYagAAAAEEg5I0nqpo4lNO1n0nPQyIqLHAcA3mKkFskbkhlETbkEMc+isv5ENd64MyXaEQt8WQ==", "bb5877de-d6a4-46b4-988d-67b3eaee76fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c6b51ca-901f-4ee6-bad4-bd1b1c998db1", new DateTime(2024, 8, 15, 10, 41, 57, 793, DateTimeKind.Local).AddTicks(4793), new DateTime(2024, 8, 15, 10, 41, 57, 793, DateTimeKind.Local).AddTicks(4763), new DateTime(2024, 8, 15, 10, 41, 57, 793, DateTimeKind.Local).AddTicks(4792), "AQAAAAIAAYagAAAAEG2Hv7BN1gjs07dFN4/RFTrkjMy3hHvWK/TROddthFFB5zf0AIt/4N/2wO+H902zIQ==", "d61187ad-49b7-4ca5-a1c2-9544e1343011" });
        }
    }
}
