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
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ed830c4-6c04-4976-b4be-86b0cc471479", new DateTime(2024, 8, 3, 9, 9, 30, 661, DateTimeKind.Local).AddTicks(1303), new DateTime(2024, 8, 3, 9, 9, 30, 661, DateTimeKind.Local).AddTicks(1298), new DateTime(2024, 8, 3, 9, 9, 30, 661, DateTimeKind.Local).AddTicks(1303), "AQAAAAIAAYagAAAAEMd65TxJ5TTFmNG2f8hARBTYPTVDMqW96m/bbG7fR5q4HIMRhDHKLjvXmTbNmGHN5g==", "79cfb089-421c-4351-8e76-f6d42434bcbc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5591881e-35e4-4ae7-8766-d5dcde3075eb", new DateTime(2024, 8, 3, 9, 9, 30, 620, DateTimeKind.Local).AddTicks(7841), new DateTime(2024, 8, 3, 9, 9, 30, 620, DateTimeKind.Local).AddTicks(7833), new DateTime(2024, 8, 3, 9, 9, 30, 620, DateTimeKind.Local).AddTicks(7841), "AQAAAAIAAYagAAAAEB6ldJMEYXj9LvDK1a64IWHK7yaFVMb7UWTc/gePEP8tQJrwEV1iyncmxjKtU5A6Fw==", "21736d11-0100-4df6-a74c-6d41dff60938" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2f9b876-9323-426c-9d23-af37d32ca62b", new DateTime(2024, 8, 3, 9, 9, 30, 700, DateTimeKind.Local).AddTicks(7834), new DateTime(2024, 8, 3, 9, 9, 30, 700, DateTimeKind.Local).AddTicks(7826), new DateTime(2024, 8, 3, 9, 9, 30, 700, DateTimeKind.Local).AddTicks(7834), "AQAAAAIAAYagAAAAEJUvkFWLDWEu2ZLJqTaTlQSNaZekqi+gs9B8qqgCfRIAYL12o45KNgndjqFZkFRKXw==", "54227e27-a4d2-4c57-b8ce-6a8e853f2ff7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
