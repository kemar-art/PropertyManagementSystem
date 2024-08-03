using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class new8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e380a199-db84-4bfc-bf52-9f286f8c0c3c", new DateTime(2024, 8, 3, 9, 20, 26, 403, DateTimeKind.Local).AddTicks(6312), new DateTime(2024, 8, 3, 9, 20, 26, 403, DateTimeKind.Local).AddTicks(6309), new DateTime(2024, 8, 3, 9, 20, 26, 403, DateTimeKind.Local).AddTicks(6312), "AQAAAAIAAYagAAAAEM7ooTg4iP26CHDzPBTgfasecEUbQNQSoHtU1+oUpUFaKNgESgfiPCSEY7M6AuQPCA==", "f62e19a4-0b98-4da0-81f5-d56284975e34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d899ce4c-1aa2-4d33-bc2c-16fa8df2a93b", new DateTime(2024, 8, 3, 9, 20, 26, 364, DateTimeKind.Local).AddTicks(2122), new DateTime(2024, 8, 3, 9, 20, 26, 364, DateTimeKind.Local).AddTicks(2115), new DateTime(2024, 8, 3, 9, 20, 26, 364, DateTimeKind.Local).AddTicks(2122), "AQAAAAIAAYagAAAAELNkn/TheiKV9QRRJqaKjSV5u7B34haYQKGbUnhP+Q2N7/IK+K0W8S7oXspCRsmpTA==", "55873e21-1e2d-4d0b-8f76-196ffbe7f02d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52b54bbb-c063-42c6-8e18-e41e3ce3a620", new DateTime(2024, 8, 3, 9, 20, 26, 441, DateTimeKind.Local).AddTicks(6851), new DateTime(2024, 8, 3, 9, 20, 26, 441, DateTimeKind.Local).AddTicks(6847), new DateTime(2024, 8, 3, 9, 20, 26, 441, DateTimeKind.Local).AddTicks(6851), "AQAAAAIAAYagAAAAEAWmK8/9xR30E7JB4/smgRb1pImZUBCyU7h741x1H3omrOjveIqK5gc5bbo7xl3vBA==", "2229fc5a-b8f4-4f35-92f9-9a0b6cafb7e7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
