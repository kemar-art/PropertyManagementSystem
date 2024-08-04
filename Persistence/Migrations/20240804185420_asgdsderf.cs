using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class asgdsderf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Regions_RegionId",
                table: "Forms");

            migrationBuilder.DropIndex(
                name: "IX_Forms_RegionId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "PurposeOfValuationItemSelectedIds",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "ServiceRequestItemSelectId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "TypeOfPropertySelectedIds",
                table: "Forms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76653e5d-7d2a-47c1-9128-a8524daea8c7", new DateTime(2024, 8, 4, 13, 54, 20, 164, DateTimeKind.Local).AddTicks(6130), new DateTime(2024, 8, 4, 13, 54, 20, 164, DateTimeKind.Local).AddTicks(6104), new DateTime(2024, 8, 4, 13, 54, 20, 164, DateTimeKind.Local).AddTicks(6129), "AQAAAAIAAYagAAAAEFaq1vMF+tjpry0pWx+53D3eIIYUU4V3xHcvAA5xbT4lXwYE8ReuvLOxks0wWEpU0g==", "fed9ba7c-099e-4eeb-8967-c2e3c93e15d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7efaae7-45f3-4435-be41-93e25aa98d8b", new DateTime(2024, 8, 4, 13, 54, 20, 103, DateTimeKind.Local).AddTicks(7799), new DateTime(2024, 8, 4, 13, 54, 20, 103, DateTimeKind.Local).AddTicks(7785), new DateTime(2024, 8, 4, 13, 54, 20, 103, DateTimeKind.Local).AddTicks(7798), "AQAAAAIAAYagAAAAEKULTwDOfAUltULqNFWm7ilsY+pIubHgDVoAu3xIjr8ZOBb9Kjy1tEUoAD66IPULHg==", "4d546455-a762-43e2-be8d-b92bbbb03757" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3682881-de65-45cb-8009-81e44f779608", new DateTime(2024, 8, 4, 13, 54, 20, 222, DateTimeKind.Local).AddTicks(6674), new DateTime(2024, 8, 4, 13, 54, 20, 222, DateTimeKind.Local).AddTicks(6657), new DateTime(2024, 8, 4, 13, 54, 20, 222, DateTimeKind.Local).AddTicks(6674), "AQAAAAIAAYagAAAAEBOLzBFbR+HfwiMCRdChNwppOtYhra21cbl4SphM+3qqyDAAkRArKvp2r5nQHYygSQ==", "dc996855-6f1e-4d53-be6a-217c08972bce" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurposeOfValuationItemSelectedIds",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "RegionId",
                table: "Forms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceRequestItemSelectId",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfPropertySelectedIds",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
