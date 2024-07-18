using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addRegionToForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RegionId",
                table: "Forms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1e91b53-9437-46f3-af3c-701e39667f7d", new DateTime(2024, 7, 17, 23, 45, 4, 520, DateTimeKind.Local).AddTicks(4488), new DateTime(2024, 7, 17, 23, 45, 4, 520, DateTimeKind.Local).AddTicks(4483), new DateTime(2024, 7, 17, 23, 45, 4, 520, DateTimeKind.Local).AddTicks(4487), "AQAAAAIAAYagAAAAEAJAi15A3T97zluCK7XJNVqEC95LuyQCsxWwlx8YHlBTnDtIQa/xZCGaG+PBUdAXpA==", "5259e4c2-ac6d-4527-9b2d-5c96a5f11de9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31ec8cde-1e81-41a7-b2fe-35943b127c66", new DateTime(2024, 7, 17, 23, 45, 4, 481, DateTimeKind.Local).AddTicks(912), new DateTime(2024, 7, 17, 23, 45, 4, 481, DateTimeKind.Local).AddTicks(900), new DateTime(2024, 7, 17, 23, 45, 4, 481, DateTimeKind.Local).AddTicks(912), "AQAAAAIAAYagAAAAEC/wqpq8tXbZ8y1d1TQnu5FgaQxI6068Umg9Wzd7sTVjnm4rEwcCljjl8WC+kPE5Vw==", "58531423-aaab-490c-93db-d72bf12fcaff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "475f8841-0226-4ed5-bcae-511fc2c671e6", new DateTime(2024, 7, 17, 23, 45, 4, 560, DateTimeKind.Local).AddTicks(2022), new DateTime(2024, 7, 17, 23, 45, 4, 560, DateTimeKind.Local).AddTicks(2012), new DateTime(2024, 7, 17, 23, 45, 4, 560, DateTimeKind.Local).AddTicks(2022), "AQAAAAIAAYagAAAAECGkEgsG/9yp/CGGgZvBTlAG/he7+8hOBiQ5CFUosNdio2Xei4D33IHtgEG7WnXQwA==", "15d8ed58-c517-48cf-884a-6dd32d92552c" });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_RegionId",
                table: "Forms",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Regions_RegionId",
                table: "Forms",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Regions_RegionId",
                table: "Forms");

            migrationBuilder.DropIndex(
                name: "IX_Forms_RegionId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Forms");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b13dfcff-9379-417a-a85f-088f5d6bb073", new DateTime(2024, 7, 17, 23, 43, 42, 278, DateTimeKind.Local).AddTicks(2909), new DateTime(2024, 7, 17, 23, 43, 42, 278, DateTimeKind.Local).AddTicks(2896), new DateTime(2024, 7, 17, 23, 43, 42, 278, DateTimeKind.Local).AddTicks(2908), "AQAAAAIAAYagAAAAEHXABHHq9dJ85yLvyDPXLgVLeCnp9DwWHC6kBbGPYxf/xfSS5v7qG6sEENRxj4b9/g==", "2c9b00ea-f46a-4867-9f97-bfd93cc73938" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd979246-7ae6-4547-aabb-797d9197ee29", new DateTime(2024, 7, 17, 23, 43, 42, 236, DateTimeKind.Local).AddTicks(2729), new DateTime(2024, 7, 17, 23, 43, 42, 236, DateTimeKind.Local).AddTicks(2720), new DateTime(2024, 7, 17, 23, 43, 42, 236, DateTimeKind.Local).AddTicks(2728), "AQAAAAIAAYagAAAAEHr/f2UJAEncr7sqFh/e5MW9oAoACeyf+Yqkh29PTBgnFiYDCziFaEuRvbtpenW+jA==", "b5935bd0-6f24-4c46-9699-659c483353e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4fa81f5-a962-4a25-8aa5-34ce3a10e13a", new DateTime(2024, 7, 17, 23, 43, 42, 318, DateTimeKind.Local).AddTicks(3296), new DateTime(2024, 7, 17, 23, 43, 42, 318, DateTimeKind.Local).AddTicks(3291), new DateTime(2024, 7, 17, 23, 43, 42, 318, DateTimeKind.Local).AddTicks(3296), "AQAAAAIAAYagAAAAECXvDbSn4uU5HoxczpUxPNHkigWYhP4KSNS/Kn+xhVxtFNakddzFmYijeL0XxtFFLA==", "2ee61dd6-f5e6-43ef-8d9d-ce054d1cc893" });
        }
    }
}
