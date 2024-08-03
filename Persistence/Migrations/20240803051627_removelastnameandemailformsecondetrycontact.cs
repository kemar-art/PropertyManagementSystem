using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removelastnameandemailformsecondetrycontact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondaryContactEmail",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "SecondaryContactFirstName",
                table: "Forms");

            migrationBuilder.RenameColumn(
                name: "SecondaryContactLastName",
                table: "Forms",
                newName: "SecondaryContactName");

            migrationBuilder.AlterColumn<string>(
                name: "IsKeyAvailable",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondaryContactName",
                table: "Forms",
                newName: "SecondaryContactLastName");

            migrationBuilder.AlterColumn<bool>(
                name: "IsKeyAvailable",
                table: "Forms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryContactEmail",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryContactFirstName",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "211b83de-ec28-4a08-b14e-54100666f04e", new DateTime(2024, 7, 29, 20, 15, 23, 247, DateTimeKind.Local).AddTicks(7783), new DateTime(2024, 7, 29, 20, 15, 23, 247, DateTimeKind.Local).AddTicks(7779), new DateTime(2024, 7, 29, 20, 15, 23, 247, DateTimeKind.Local).AddTicks(7783), "AQAAAAIAAYagAAAAEOpsy6laJ/BJU1W9cD/F2hRM5lDMjxzPhybL3h1GbDjSz3drRnx+0DvQ+AfU7/prag==", "9cadbc30-3ba4-4c53-bf85-f6bccffa88dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c9d2aa5-ea1d-4be8-aab1-3e3e4a05273f", new DateTime(2024, 7, 29, 20, 15, 23, 209, DateTimeKind.Local).AddTicks(2940), new DateTime(2024, 7, 29, 20, 15, 23, 209, DateTimeKind.Local).AddTicks(2931), new DateTime(2024, 7, 29, 20, 15, 23, 209, DateTimeKind.Local).AddTicks(2940), "AQAAAAIAAYagAAAAEEhHmmilyjd9Ljhyde6wuzZ6XKws4Y1LoXcu7x8XiS7BVMGWlYf/e3DcB/oXHCDXxQ==", "e03beb23-6f84-4cdb-a12a-39ce972cffb5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85887b01-1f1c-416c-b5cf-ff6d89748164", new DateTime(2024, 7, 29, 20, 15, 23, 287, DateTimeKind.Local).AddTicks(6376), new DateTime(2024, 7, 29, 20, 15, 23, 287, DateTimeKind.Local).AddTicks(6372), new DateTime(2024, 7, 29, 20, 15, 23, 287, DateTimeKind.Local).AddTicks(6376), "AQAAAAIAAYagAAAAEFLvSPxLBrVqgC9PQsphKwuKwPKv4hmODMg5Be/JTCSX2otAB38ExZ4XC6ZknRmHyQ==", "c47f3903-aed8-42c7-b4a2-cfaa73291b93" });
        }
    }
}
