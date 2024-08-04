using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class asgdsderfl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6e75380-b757-428a-ae36-c9c676b29cca", new DateTime(2024, 8, 4, 13, 55, 58, 480, DateTimeKind.Local).AddTicks(2250), new DateTime(2024, 8, 4, 13, 55, 58, 480, DateTimeKind.Local).AddTicks(2240), new DateTime(2024, 8, 4, 13, 55, 58, 480, DateTimeKind.Local).AddTicks(2249), "AQAAAAIAAYagAAAAEODuc9zQRL3N9fxGbCoJs/FfU4I9QWhbuAm3ICpZGvZ1cBk3uoUxQsppDVX5Yn37lA==", "be6416c2-3edd-4baa-b2c8-0ae6e757e1d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f18b2bdd-4523-4f71-93b5-159ea77fb281", new DateTime(2024, 8, 4, 13, 55, 58, 422, DateTimeKind.Local).AddTicks(6264), new DateTime(2024, 8, 4, 13, 55, 58, 422, DateTimeKind.Local).AddTicks(6251), new DateTime(2024, 8, 4, 13, 55, 58, 422, DateTimeKind.Local).AddTicks(6263), "AQAAAAIAAYagAAAAEP6DcYgUN9pDa0Zxz3/TGq9klt1M8L4q3Nn8/9dqyz2YBdKgm9IrTT0qgKI5ZxMhsw==", "51c6e5cd-eaea-4001-9f5f-2b6f7af60562" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92f3c163-3253-47be-80bc-f70a59e238dc", new DateTime(2024, 8, 4, 13, 55, 58, 537, DateTimeKind.Local).AddTicks(3094), new DateTime(2024, 8, 4, 13, 55, 58, 537, DateTimeKind.Local).AddTicks(3086), new DateTime(2024, 8, 4, 13, 55, 58, 537, DateTimeKind.Local).AddTicks(3094), "AQAAAAIAAYagAAAAEGGKveyncMQpdTySiXOt4sbs3l0W3J0GBHdKfT6ZExyQPSAseQN3QeDzREDPaqIAxw==", "49139f2e-8139-485c-bb18-f169184c45d7" });

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
    }
}
