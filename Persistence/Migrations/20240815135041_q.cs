using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class q : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1180cbe2-3f5c-4a5f-b5b3-62c4837d4368", new DateTime(2024, 8, 15, 8, 50, 41, 129, DateTimeKind.Local).AddTicks(4038), new DateTime(2024, 8, 15, 8, 50, 41, 129, DateTimeKind.Local).AddTicks(4028), new DateTime(2024, 8, 15, 8, 50, 41, 129, DateTimeKind.Local).AddTicks(4037), "AQAAAAIAAYagAAAAEKR2CJZ5xKSfPY/E5b1apYKc6Hr4T3s+4B4Ue5AQE8sLz7FEzVBQ+LVMGfqDfouLxg==", "34e80a9d-7f01-4ec1-9585-7b59bd859ed2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d5c4916-a85f-478f-a082-2309b28bbcd4", new DateTime(2024, 8, 15, 8, 50, 41, 63, DateTimeKind.Local).AddTicks(2597), new DateTime(2024, 8, 15, 8, 50, 41, 63, DateTimeKind.Local).AddTicks(2583), new DateTime(2024, 8, 15, 8, 50, 41, 63, DateTimeKind.Local).AddTicks(2596), "AQAAAAIAAYagAAAAEN89BypIB1NhItjUfS/h68tk+5OgwzUmcdfWLcmvGXAoErChTcZPkQqzF+WvKtWOpQ==", "6849287c-0095-4907-a3f6-16a800a26cc0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a30d44b-78dc-422f-a5a8-75dd6846e7d6", new DateTime(2024, 8, 15, 8, 50, 41, 190, DateTimeKind.Local).AddTicks(5150), new DateTime(2024, 8, 15, 8, 50, 41, 190, DateTimeKind.Local).AddTicks(5111), new DateTime(2024, 8, 15, 8, 50, 41, 190, DateTimeKind.Local).AddTicks(5149), "AQAAAAIAAYagAAAAEJ5uRSsnG21/qdH8bUwe1mLyEcWqN8W9ywCqthctPNOqa7qo3EvNmx48NguCmYCbwQ==", "581b9add-855e-4614-a01a-35c280758531" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a49febc-6bbc-4911-9e56-7243646baad5", new DateTime(2024, 8, 14, 21, 24, 54, 440, DateTimeKind.Local).AddTicks(1457), new DateTime(2024, 8, 14, 21, 24, 54, 440, DateTimeKind.Local).AddTicks(1452), new DateTime(2024, 8, 14, 21, 24, 54, 440, DateTimeKind.Local).AddTicks(1457), "AQAAAAIAAYagAAAAENzU0fAvNN2kBdjMuSEBebc2SU0Mvrf5YW4Flb9rNXqXHPOyGstOnfiUCoyj9uHLZw==", "2fd16d41-8cff-4fcc-8760-3df7ca7b1595" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "654b7bcd-c682-49c1-b593-0d397af0b3b5", new DateTime(2024, 8, 14, 21, 24, 54, 401, DateTimeKind.Local).AddTicks(5767), new DateTime(2024, 8, 14, 21, 24, 54, 401, DateTimeKind.Local).AddTicks(5753), new DateTime(2024, 8, 14, 21, 24, 54, 401, DateTimeKind.Local).AddTicks(5767), "AQAAAAIAAYagAAAAENXISE3jOcCE/1KHR4X2ntmEgZ1yVs3Y+IN3nZYru53CrBjppdZtYdGG9BcftulGjA==", "e805a822-5937-4d8e-a748-301dd11df1da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6582755e-6748-44d5-a27e-6e4a40bbca78", new DateTime(2024, 8, 14, 21, 24, 54, 480, DateTimeKind.Local).AddTicks(9023), new DateTime(2024, 8, 14, 21, 24, 54, 480, DateTimeKind.Local).AddTicks(9019), new DateTime(2024, 8, 14, 21, 24, 54, 480, DateTimeKind.Local).AddTicks(9023), "AQAAAAIAAYagAAAAENwbVQa5tzcnLtNBBFtUvtmvJtgL5jW0CKqYUj6J3n2xOpm3mTKfliAFRAX5BDOn9Q==", "6cd3608a-5461-47e7-87a5-4415eb8810f7" });
        }
    }
}
