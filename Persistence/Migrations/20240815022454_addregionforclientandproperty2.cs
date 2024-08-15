using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addregionforclientandproperty2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Regions_RegionId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "AspNetUsers",
                newName: "ClientRegionId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_RegionId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ClientRegionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Regions_ClientRegionId",
                table: "AspNetUsers",
                column: "ClientRegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Regions_ClientRegionId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ClientRegionId",
                table: "AspNetUsers",
                newName: "RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ClientRegionId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_RegionId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eef94473-5c4b-43ba-9056-06c0176e5128", new DateTime(2024, 8, 14, 20, 40, 47, 767, DateTimeKind.Local).AddTicks(9041), new DateTime(2024, 8, 14, 20, 40, 47, 767, DateTimeKind.Local).AddTicks(9035), new DateTime(2024, 8, 14, 20, 40, 47, 767, DateTimeKind.Local).AddTicks(9041), "AQAAAAIAAYagAAAAEH5sTtSOkOJCZi/ZdOGhF5j4V6avfkT4yV9TQRS4kncmVNPc0eKj0eyhUo1mM1uvjw==", "a504d6bf-f736-4b84-a3e0-2aec00245158" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df6d7b56-1392-4dae-a998-ec016a1d1fc0", new DateTime(2024, 8, 14, 20, 40, 47, 729, DateTimeKind.Local).AddTicks(4403), new DateTime(2024, 8, 14, 20, 40, 47, 729, DateTimeKind.Local).AddTicks(4389), new DateTime(2024, 8, 14, 20, 40, 47, 729, DateTimeKind.Local).AddTicks(4403), "AQAAAAIAAYagAAAAELE8M6q6RLILUgVAh1taW1U9SKGrJ4pFPO/oA7MjNKJKokP4PuGXRV8uuaLwwzYDiQ==", "8700917c-92d8-4c95-a7a7-985e20e8dff5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b04a036-c927-437e-ba6a-81fa49155f65", new DateTime(2024, 8, 14, 20, 40, 47, 806, DateTimeKind.Local).AddTicks(6526), new DateTime(2024, 8, 14, 20, 40, 47, 806, DateTimeKind.Local).AddTicks(6521), new DateTime(2024, 8, 14, 20, 40, 47, 806, DateTimeKind.Local).AddTicks(6526), "AQAAAAIAAYagAAAAEEixSxqzkLLIOF6+8RpAhk81CqAOJU1/IVV9BRS8V2L3SxyoweOIisMlK9WGm016xA==", "71927fb0-6910-47a8-b233-6753d7d778cb" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Regions_RegionId",
                table: "AspNetUsers",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }
    }
}
