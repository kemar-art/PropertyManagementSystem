using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addFormInteractionLogTabe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormInteractionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Submitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppraiserNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormInteractionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormInteractionLogs_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormInteractionLogs_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_FormInteractionLogs_ApplicationUserId",
                table: "FormInteractionLogs",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FormInteractionLogs_FormId",
                table: "FormInteractionLogs",
                column: "FormId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormInteractionLogs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3ea52f1-b964-4c51-b80a-152a6696d2cf", new DateTime(2024, 7, 9, 19, 4, 31, 325, DateTimeKind.Local).AddTicks(5723), new DateTime(2024, 7, 9, 19, 4, 31, 325, DateTimeKind.Local).AddTicks(5715), new DateTime(2024, 7, 9, 19, 4, 31, 325, DateTimeKind.Local).AddTicks(5723), "AQAAAAIAAYagAAAAECslh/Mnf2EQyzZ4GPQfOtmQ4PstqpHGH0upQ3FbJnJ4hseQvoauL6pkbPd6ogLb4Q==", "e37e361b-6972-4607-a9e6-8fdb67dfe230" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a8dba41-eaba-4e5c-b305-ec55d0c0e537", new DateTime(2024, 7, 9, 19, 4, 31, 285, DateTimeKind.Local).AddTicks(8353), new DateTime(2024, 7, 9, 19, 4, 31, 285, DateTimeKind.Local).AddTicks(8344), new DateTime(2024, 7, 9, 19, 4, 31, 285, DateTimeKind.Local).AddTicks(8352), "AQAAAAIAAYagAAAAEJD5jwyjrPeWoECZUgXnD4LVyQuA4sfAXXtl+HtQNCNsD4/cfY0dh/jMLDPXUxyC+A==", "130e37d0-f7e7-4ee8-8a52-306e496049f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ec30acd-3f9a-4125-9aec-a1e0a12060c0", new DateTime(2024, 7, 9, 19, 4, 31, 365, DateTimeKind.Local).AddTicks(8137), new DateTime(2024, 7, 9, 19, 4, 31, 365, DateTimeKind.Local).AddTicks(8132), new DateTime(2024, 7, 9, 19, 4, 31, 365, DateTimeKind.Local).AddTicks(8137), "AQAAAAIAAYagAAAAEGpwRJxBz55nsii+G/77ELSou+USNtCuCJsDnHz5P9iOeR75y+Vfny2ngkpphFD7NA==", "4458acc3-933d-4509-9d8b-f6503993ef4e" });
        }
    }
}
