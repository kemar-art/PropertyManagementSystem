using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class adddatae : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Datestarted",
                table: "AspNetUsers",
                newName: "DateRegistered");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62036824-2a52-4634-8329-8bd61fda0728", new DateTime(2024, 7, 12, 22, 6, 25, 617, DateTimeKind.Local).AddTicks(4147), new DateTime(2024, 7, 12, 22, 6, 25, 617, DateTimeKind.Local).AddTicks(4143), new DateTime(2024, 7, 12, 22, 6, 25, 617, DateTimeKind.Local).AddTicks(4146), "AQAAAAIAAYagAAAAELS9gDTV9NIhbUkhLvqCRjwnvg7NWusbEbly/hdwJaNlaxA10sPRSQDKKsg+vICsqw==", "aef32c66-8319-452e-907d-b1355c252dfd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90980c8f-0ede-4a61-be00-291501a92e58", new DateTime(2024, 7, 12, 22, 6, 25, 577, DateTimeKind.Local).AddTicks(4985), new DateTime(2024, 7, 12, 22, 6, 25, 577, DateTimeKind.Local).AddTicks(4972), new DateTime(2024, 7, 12, 22, 6, 25, 577, DateTimeKind.Local).AddTicks(4984), "AQAAAAIAAYagAAAAEKLBgA77bLogFdm/tYKrwm5wQvWa55s/noDCYOOxC/inbx6u6wUdwNs4EbHPS0YrUw==", "414ad647-8c80-4383-befd-e46a3a07ac3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33bd3819-da26-48d7-892f-d1af64f985bb", new DateTime(2024, 7, 12, 22, 6, 25, 656, DateTimeKind.Local).AddTicks(1143), new DateTime(2024, 7, 12, 22, 6, 25, 656, DateTimeKind.Local).AddTicks(1139), new DateTime(2024, 7, 12, 22, 6, 25, 656, DateTimeKind.Local).AddTicks(1142), "AQAAAAIAAYagAAAAENlD+fN+UjyhOaGOKRDWv+j59FF1QUCY1cFCyTQIC0MO6721H8fBQuQqz8VIZJeT1Q==", "3e0d05ab-5dee-43e5-98df-a1eb57c88d55" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateRegistered",
                table: "AspNetUsers",
                newName: "Datestarted");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "352553b3-9576-4cf2-8af6-f2e7ada72aaf", new DateTime(2024, 7, 9, 21, 17, 57, 242, DateTimeKind.Local).AddTicks(8374), new DateTime(2024, 7, 9, 21, 17, 57, 242, DateTimeKind.Local).AddTicks(8358), new DateTime(2024, 7, 9, 21, 17, 57, 242, DateTimeKind.Local).AddTicks(8374), "AQAAAAIAAYagAAAAEPTyVu6MJJSvLrMocAOFUY6Nbsf+SFJkOWEE9hPX9mSQReUZw4/eLa5G8lsmEMMfFQ==", "85c2a573-88be-4b87-a7d0-e4d07ee2561b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddcadf87-f04b-4545-b482-5098812a028a", new DateTime(2024, 7, 9, 21, 17, 57, 201, DateTimeKind.Local).AddTicks(1677), new DateTime(2024, 7, 9, 21, 17, 57, 201, DateTimeKind.Local).AddTicks(1662), new DateTime(2024, 7, 9, 21, 17, 57, 201, DateTimeKind.Local).AddTicks(1677), "AQAAAAIAAYagAAAAEA48bdga96s1QhocwQyZjFHuxo+d1LCsaG3NCuf/z6inC9P7ExIzJ5ZjUvx+6h/9ew==", "ae02e0f8-be9f-4b61-8233-4d664281e1f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08430862-d177-4616-a607-65676a07436f", new DateTime(2024, 7, 9, 21, 17, 57, 282, DateTimeKind.Local).AddTicks(7888), new DateTime(2024, 7, 9, 21, 17, 57, 282, DateTimeKind.Local).AddTicks(7879), new DateTime(2024, 7, 9, 21, 17, 57, 282, DateTimeKind.Local).AddTicks(7888), "AQAAAAIAAYagAAAAEMCD8R9BvYV0waHt0nceM0d5QpHcPEo6ulsi0zatWLaK/rrGbuNvlm8xyEe/720Vgg==", "0ad66d75-df2b-43b3-9012-5ace1e54373e" });
        }
    }
}
