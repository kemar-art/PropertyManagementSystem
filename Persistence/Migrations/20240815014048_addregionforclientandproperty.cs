using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addregionforclientandproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Regions_RegionId",
                table: "Forms");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Forms",
                newName: "PropertyRegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_RegionId",
                table: "Forms",
                newName: "IX_Forms_PropertyRegionId");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientRegionId",
                table: "Forms",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Forms_ClientRegionId",
                table: "Forms",
                column: "ClientRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Regions_ClientRegionId",
                table: "Forms",
                column: "ClientRegionId",
                principalTable: "Regions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Regions_PropertyRegionId",
                table: "Forms",
                column: "PropertyRegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Regions_ClientRegionId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Regions_PropertyRegionId",
                table: "Forms");

            migrationBuilder.DropIndex(
                name: "IX_Forms_ClientRegionId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "ClientRegionId",
                table: "Forms");

            migrationBuilder.RenameColumn(
                name: "PropertyRegionId",
                table: "Forms",
                newName: "RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_PropertyRegionId",
                table: "Forms",
                newName: "IX_Forms_RegionId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd0802fa-e787-4a03-a91a-97e1964aa204", new DateTime(2024, 8, 13, 20, 35, 25, 619, DateTimeKind.Local).AddTicks(2041), new DateTime(2024, 8, 13, 20, 35, 25, 619, DateTimeKind.Local).AddTicks(2034), new DateTime(2024, 8, 13, 20, 35, 25, 619, DateTimeKind.Local).AddTicks(2041), "AQAAAAIAAYagAAAAEHpeL3Qa8FWouAr7QulEji6Kq0mKYZce2HasvENT3WxsgHriC3gXXE10itL2ctOL0A==", "fbdcc6d4-29f3-49d3-bb94-a4df80abb31c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "586ecccf-85bf-45fc-a5f5-4658a8ab7334", new DateTime(2024, 8, 13, 20, 35, 25, 579, DateTimeKind.Local).AddTicks(4507), new DateTime(2024, 8, 13, 20, 35, 25, 579, DateTimeKind.Local).AddTicks(4497), new DateTime(2024, 8, 13, 20, 35, 25, 579, DateTimeKind.Local).AddTicks(4507), "AQAAAAIAAYagAAAAEIvOJQ4R+PBl8tfNNqmp2jIZ2nehqtAVkWqLQcYpf+ynR0FvVvILPVGIbpuI6BZgZw==", "e15c21f3-eb1e-4e0c-a5c0-53612ba04cf2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b57deecb-6cbc-4fcb-bd85-7ed5cf3f8a46", new DateTime(2024, 8, 13, 20, 35, 25, 658, DateTimeKind.Local).AddTicks(9162), new DateTime(2024, 8, 13, 20, 35, 25, 658, DateTimeKind.Local).AddTicks(9146), new DateTime(2024, 8, 13, 20, 35, 25, 658, DateTimeKind.Local).AddTicks(9162), "AQAAAAIAAYagAAAAELfgaeFQ5HhSCW2ASNGQKm6vvgCUdR18Q+7P1t/NTd0o1EHroQKxr+Xe7RjrbTEJMg==", "fd0e228c-5458-4803-a883-628c13270d10" });

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Regions_RegionId",
                table: "Forms",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }
    }
}
