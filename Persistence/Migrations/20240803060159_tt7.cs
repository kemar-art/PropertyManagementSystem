using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tt7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdb82a08-0c3f-4d11-83b8-53048d2e1ce3", new DateTime(2024, 8, 3, 1, 1, 59, 231, DateTimeKind.Local).AddTicks(4079), new DateTime(2024, 8, 3, 1, 1, 59, 231, DateTimeKind.Local).AddTicks(4076), new DateTime(2024, 8, 3, 1, 1, 59, 231, DateTimeKind.Local).AddTicks(4079), "AQAAAAIAAYagAAAAEKLfEhu/cC9kdooGluU/G4vPGUr4wrQZbBeUtDD9Fq7HhpiNlhyjCEXTL1wRM+rmmA==", "bdfdf253-d1fe-491f-a800-38272db057ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e37efe8-ac48-413d-a9e3-25e7368f3a63", new DateTime(2024, 8, 3, 1, 1, 59, 191, DateTimeKind.Local).AddTicks(6146), new DateTime(2024, 8, 3, 1, 1, 59, 191, DateTimeKind.Local).AddTicks(6138), new DateTime(2024, 8, 3, 1, 1, 59, 191, DateTimeKind.Local).AddTicks(6146), "AQAAAAIAAYagAAAAENiWF8K0TOyy/lIU12iJA6m5mpe25+u4Skocuc9S23/9SiWzmHACkGFAObCHErg0GQ==", "8eb9afcd-a8bd-4ceb-ad2c-dc1ea2cea305" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdb1e498-b58a-4986-9a5b-61e1216ae6fe", new DateTime(2024, 8, 3, 1, 1, 59, 269, DateTimeKind.Local).AddTicks(6241), new DateTime(2024, 8, 3, 1, 1, 59, 269, DateTimeKind.Local).AddTicks(6238), new DateTime(2024, 8, 3, 1, 1, 59, 269, DateTimeKind.Local).AddTicks(6241), "AQAAAAIAAYagAAAAEHkX4u7X1HmspludhqpzOfp10VUpQCrr3wfVvZEaQgS8Y5e54j9LjEtgpkL6T79usg==", "7b31bad1-fe00-4bc8-822a-ce15f7da7128" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a65f69e3-0b7a-46ad-baf2-023aee60b88b", new DateTime(2024, 8, 3, 0, 16, 27, 44, DateTimeKind.Local).AddTicks(3394), new DateTime(2024, 8, 3, 0, 16, 27, 44, DateTimeKind.Local).AddTicks(3388), new DateTime(2024, 8, 3, 0, 16, 27, 44, DateTimeKind.Local).AddTicks(3394), "AQAAAAIAAYagAAAAEEBQQ2VZ+Xx/ePqy4H3Uq1QNy4Gxn7DYu24TNdsa09frMZFZmHwnSGvuLEBlEQbJUA==", "4dee0d43-1d7e-419b-8e3f-6bf43470b808" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "930e111c-666e-40d6-a430-b0420ef74ed6", new DateTime(2024, 8, 3, 0, 16, 27, 4, DateTimeKind.Local).AddTicks(4367), new DateTime(2024, 8, 3, 0, 16, 27, 4, DateTimeKind.Local).AddTicks(4357), new DateTime(2024, 8, 3, 0, 16, 27, 4, DateTimeKind.Local).AddTicks(4367), "AQAAAAIAAYagAAAAEJncW6aEtO0sTIB5tQF93J5uf8mv6E7ggLwoziMh574Gs4SkHMsJMeofWkTFlEZDNg==", "a324a56a-2ac7-484b-bf23-917452c22b97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32a0e1e0-11b6-4f6c-9a46-02151535185e", new DateTime(2024, 8, 3, 0, 16, 27, 82, DateTimeKind.Local).AddTicks(324), new DateTime(2024, 8, 3, 0, 16, 27, 82, DateTimeKind.Local).AddTicks(320), new DateTime(2024, 8, 3, 0, 16, 27, 82, DateTimeKind.Local).AddTicks(324), "AQAAAAIAAYagAAAAEHHc/Gq5ZwE8i+oESV9Rxxmx+PwyrwL2jN5ECXGMZ6aRHiKQv6bJEo/2H4uTcqsZng==", "d7ee3f57-3f5e-4dac-b56f-3dc8c2e4b847" });
        }
    }
}
