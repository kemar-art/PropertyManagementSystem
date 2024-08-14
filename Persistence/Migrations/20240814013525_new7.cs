using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class new7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RegionId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "RegionId", "SecurityStamp" },
                values: new object[] { "dd0802fa-e787-4a03-a91a-97e1964aa204", new DateTime(2024, 8, 13, 20, 35, 25, 619, DateTimeKind.Local).AddTicks(2041), new DateTime(2024, 8, 13, 20, 35, 25, 619, DateTimeKind.Local).AddTicks(2034), new DateTime(2024, 8, 13, 20, 35, 25, 619, DateTimeKind.Local).AddTicks(2041), "AQAAAAIAAYagAAAAEHpeL3Qa8FWouAr7QulEji6Kq0mKYZce2HasvENT3WxsgHriC3gXXE10itL2ctOL0A==", null, "fbdcc6d4-29f3-49d3-bb94-a4df80abb31c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "RegionId", "SecurityStamp" },
                values: new object[] { "586ecccf-85bf-45fc-a5f5-4658a8ab7334", new DateTime(2024, 8, 13, 20, 35, 25, 579, DateTimeKind.Local).AddTicks(4507), new DateTime(2024, 8, 13, 20, 35, 25, 579, DateTimeKind.Local).AddTicks(4497), new DateTime(2024, 8, 13, 20, 35, 25, 579, DateTimeKind.Local).AddTicks(4507), "AQAAAAIAAYagAAAAEIvOJQ4R+PBl8tfNNqmp2jIZ2nehqtAVkWqLQcYpf+ynR0FvVvILPVGIbpuI6BZgZw==", null, "e15c21f3-eb1e-4e0c-a5c0-53612ba04cf2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "RegionId", "SecurityStamp" },
                values: new object[] { "b57deecb-6cbc-4fcb-bd85-7ed5cf3f8a46", new DateTime(2024, 8, 13, 20, 35, 25, 658, DateTimeKind.Local).AddTicks(9162), new DateTime(2024, 8, 13, 20, 35, 25, 658, DateTimeKind.Local).AddTicks(9146), new DateTime(2024, 8, 13, 20, 35, 25, 658, DateTimeKind.Local).AddTicks(9162), "AQAAAAIAAYagAAAAELfgaeFQ5HhSCW2ASNGQKm6vvgCUdR18Q+7P1t/NTd0o1EHroQKxr+Xe7RjrbTEJMg==", null, "fd0e228c-5458-4803-a883-628c13270d10" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RegionId",
                table: "AspNetUsers",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Regions_RegionId",
                table: "AspNetUsers",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Regions_RegionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RegionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87b42647-8bcf-4c29-8c8b-bf27e5967335", new DateTime(2024, 8, 13, 12, 23, 21, 585, DateTimeKind.Local).AddTicks(4595), new DateTime(2024, 8, 13, 12, 23, 21, 585, DateTimeKind.Local).AddTicks(4584), new DateTime(2024, 8, 13, 12, 23, 21, 585, DateTimeKind.Local).AddTicks(4594), "AQAAAAIAAYagAAAAEGNGD+iT0qaLlIMIMwGLMFdywRwEpBWJMvPAYYWNRmbusaX4A95xxAfmB+ggfDHZtg==", "416e6e94-ef3e-46ca-95ab-c58fe12041e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0980fd06-fd87-43da-98ef-2de7c5be0baf", new DateTime(2024, 8, 13, 12, 23, 21, 527, DateTimeKind.Local).AddTicks(14), new DateTime(2024, 8, 13, 12, 23, 21, 527, DateTimeKind.Local), new DateTime(2024, 8, 13, 12, 23, 21, 527, DateTimeKind.Local).AddTicks(14), "AQAAAAIAAYagAAAAEEtG9wcpK80/90fvRZahT3aa206jYHfBy70XuxbSn0ChJrRW2zu5PQZNiJb3dduIVQ==", "9b7f1e22-80dd-4031-83a3-2149d2d06050" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8119ac81-1ea7-463f-8505-d7c0acbfb38c", new DateTime(2024, 8, 13, 12, 23, 21, 646, DateTimeKind.Local).AddTicks(439), new DateTime(2024, 8, 13, 12, 23, 21, 646, DateTimeKind.Local).AddTicks(406), new DateTime(2024, 8, 13, 12, 23, 21, 646, DateTimeKind.Local).AddTicks(439), "AQAAAAIAAYagAAAAEH6JiSmqJH8l5OBhbYrU1Ov+x/lY64W9bC6KdtonHUAuEeTKO8qI+jNNGXajR9011Q==", "340a5829-5af3-4c29-96e1-f53a9090cc4f" });
        }
    }
}
