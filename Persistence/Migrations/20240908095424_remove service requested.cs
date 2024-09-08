using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removeservicerequested : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceRequestItemSelectId",
                table: "Forms");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f26b8f5d-6601-4f6f-a57b-8601e9b5420f", new DateTime(2024, 9, 8, 4, 54, 24, 222, DateTimeKind.Local).AddTicks(9235), "AQAAAAIAAYagAAAAEJMXgkJT3TZmvN30Yoj+N5m6L3IQRjqLGnnRk+OUQ6oZD0HWPu0/+ANKMaIrF+Q3Jw==", "8ffd4ce7-f2b5-4ea3-ac2b-e996ec8a534b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac71a915-71f9-4f5d-96d0-f4ffc675ddc4", new DateTime(2024, 9, 8, 4, 54, 24, 183, DateTimeKind.Local).AddTicks(1391), "AQAAAAIAAYagAAAAEDzMaflZtY4k9hQXGYvphuNp6ZqJP7BrlDWb8b5zrNXWdDWRnybyD0IWHvAMUhID1g==", "b59ea4f0-55bc-44aa-bd6e-5061cf4c5891" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aab2a34c-1a6e-4e7d-b3e1-98faf949d516", new DateTime(2024, 9, 8, 4, 54, 24, 263, DateTimeKind.Local).AddTicks(1834), "AQAAAAIAAYagAAAAEJqaZ36+TPW2m0nHHnh1TSkPOiNAlcKypKp516FlHHFcIIN1HsXmNSMUhrNvnhu+pg==", "4e529222-597e-401c-8a9c-8546ce61caa4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceRequestItemSelectId",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb2f689d-559c-4f7f-9a2e-dac4a7c4d142", new DateTime(2024, 9, 7, 2, 28, 41, 425, DateTimeKind.Local).AddTicks(1364), "AQAAAAIAAYagAAAAEFWkq23A8AfosLQJGvnj8BkfacgJoGGD1nuySkxJr3tYPZN7J8Ekfc16IuLptb6GCQ==", "e30af4f1-b8ac-4d1a-af93-043883e5f444" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48c589a7-f4fe-4c6e-8378-bdb476cb749c", new DateTime(2024, 9, 7, 2, 28, 41, 386, DateTimeKind.Local).AddTicks(3000), "AQAAAAIAAYagAAAAEN+HhZlXlAYPR6ui+wTvuTXTW09KexPxw1Grg4F59LWOr5vgZp2nlpNcJej545Ftqg==", "daca0b1f-45a3-4c77-b40f-ec8489b5bedb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5752de2d-cfff-41e9-bfcc-ce7817dc75ac", new DateTime(2024, 9, 7, 2, 28, 41, 463, DateTimeKind.Local).AddTicks(8110), "AQAAAAIAAYagAAAAELGhzHxr7genB/HAKea1RREudza606TW476vn3zLNsjR1fANhD3v3txIPNQPKyRXkg==", "2a10997a-ce03-4153-a047-4f12ff09a284" });
        }
    }
}
