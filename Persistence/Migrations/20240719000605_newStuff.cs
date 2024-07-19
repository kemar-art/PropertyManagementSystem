using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurposeOfValuationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurposeOfValuationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequestItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequestItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfPropertyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPropertyItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequestFormPurposeOfValuationItems",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "int", nullable: false),
                    PurposeOfValuationItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequestFormPurposeOfValuationItems", x => new { x.FormId, x.PurposeOfValuationItemId });
                    table.ForeignKey(
                        name: "FK_ServiceRequestFormPurposeOfValuationItems_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequestFormPurposeOfValuationItems_PurposeOfValuationItems_PurposeOfValuationItemId",
                        column: x => x.PurposeOfValuationItemId,
                        principalTable: "PurposeOfValuationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequestFormServiceRequestItems",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "int", nullable: false),
                    ServiceRequestItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequestFormServiceRequestItems", x => new { x.FormId, x.ServiceRequestItemId });
                    table.ForeignKey(
                        name: "FK_ServiceRequestFormServiceRequestItems_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequestFormServiceRequestItems_ServiceRequestItems_ServiceRequestItemId",
                        column: x => x.ServiceRequestItemId,
                        principalTable: "ServiceRequestItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequesFormTypeOfPropertyItems",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "int", nullable: false),
                    TypeOfPropertyItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequesFormTypeOfPropertyItems", x => new { x.FormId, x.TypeOfPropertyItemId });
                    table.ForeignKey(
                        name: "FK_ServiceRequesFormTypeOfPropertyItems_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequesFormTypeOfPropertyItems_TypeOfPropertyItems_TypeOfPropertyItemId",
                        column: x => x.TypeOfPropertyItemId,
                        principalTable: "TypeOfPropertyItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aea7c575-1fb8-4ada-91af-cf7ad83c1e46", new DateTime(2024, 7, 18, 19, 6, 5, 397, DateTimeKind.Local).AddTicks(7838), new DateTime(2024, 7, 18, 19, 6, 5, 397, DateTimeKind.Local).AddTicks(7833), new DateTime(2024, 7, 18, 19, 6, 5, 397, DateTimeKind.Local).AddTicks(7838), "AQAAAAIAAYagAAAAEP786BwfrwbQWPgFpFqsIUcDTtmSBUD538LurdACZkKqnFL62rM7Xd+Bg6K/47ky6A==", "95f1ed38-bbed-4437-bb36-122a1c51dd26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54c9fcf2-32f1-41b1-864b-19add1412e5a", new DateTime(2024, 7, 18, 19, 6, 5, 357, DateTimeKind.Local).AddTicks(6625), new DateTime(2024, 7, 18, 19, 6, 5, 357, DateTimeKind.Local).AddTicks(6617), new DateTime(2024, 7, 18, 19, 6, 5, 357, DateTimeKind.Local).AddTicks(6625), "AQAAAAIAAYagAAAAEDVac+LiHYNw0FBxjVQFUsR/CHFgIT1GptOly/X4rETXEbG0TodCc5oGIgDlr7uSZw==", "39b1a5b7-0bdb-4693-9571-91f7e67d9a1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30d6eaf2-3abf-4ddc-92af-e96a410785d0", new DateTime(2024, 7, 18, 19, 6, 5, 438, DateTimeKind.Local).AddTicks(5541), new DateTime(2024, 7, 18, 19, 6, 5, 438, DateTimeKind.Local).AddTicks(5536), new DateTime(2024, 7, 18, 19, 6, 5, 438, DateTimeKind.Local).AddTicks(5541), "AQAAAAIAAYagAAAAEF87sLhD8tSZMx8OxCQmkX0SXqnEA5xCiwtMf9sGA7C+itFPUwTDwy5j7aU5yReTUg==", "8f8bef5f-a71f-46ad-b17f-656498ef0a58" });

            migrationBuilder.InsertData(
                table: "PurposeOfValuationItems",
                columns: new[] { "Id", "IsChecked", "Title" },
                values: new object[,]
                {
                    { 1, false, "Market Value" },
                    { 2, false, "Sale" },
                    { 3, false, "Purchase" },
                    { 4, false, "Mortgage" },
                    { 5, false, "Insurance" },
                    { 6, false, "Probate" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequestItems",
                columns: new[] { "Id", "IsChecked", "Title" },
                values: new object[,]
                {
                    { 1, false, "VALUATION" },
                    { 2, false, "LAND SURVEYOR" },
                    { 3, false, "LEGAL REPRESENTATION" },
                    { 4, false, "SALES/RENTALS" },
                    { 5, false, "AUCTION" },
                    { 6, false, "PROPERTY MANAGEMENT" },
                    { 7, false, "STRUCTURAL SURVEY" },
                    { 8, false, "CONSTRUCTION ESTIMATE" },
                    { 9, false, "GENERAL CONTRACTOR" },
                    { 10, false, "OTHER" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfPropertyItems",
                columns: new[] { "Id", "IsChecked", "Title" },
                values: new object[,]
                {
                    { 1, false, "Commercial" },
                    { 2, false, "Residential" },
                    { 3, false, "Agricultural" },
                    { 4, false, "Industrial" },
                    { 5, false, "Vacant Lot" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequesFormTypeOfPropertyItems_TypeOfPropertyItemId",
                table: "ServiceRequesFormTypeOfPropertyItems",
                column: "TypeOfPropertyItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestFormPurposeOfValuationItems_PurposeOfValuationItemId",
                table: "ServiceRequestFormPurposeOfValuationItems",
                column: "PurposeOfValuationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestFormServiceRequestItems_ServiceRequestItemId",
                table: "ServiceRequestFormServiceRequestItems",
                column: "ServiceRequestItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRequesFormTypeOfPropertyItems");

            migrationBuilder.DropTable(
                name: "ServiceRequestFormPurposeOfValuationItems");

            migrationBuilder.DropTable(
                name: "ServiceRequestFormServiceRequestItems");

            migrationBuilder.DropTable(
                name: "TypeOfPropertyItems");

            migrationBuilder.DropTable(
                name: "PurposeOfValuationItems");

            migrationBuilder.DropTable(
                name: "ServiceRequestItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1e91b53-9437-46f3-af3c-701e39667f7d", new DateTime(2024, 7, 17, 23, 45, 4, 520, DateTimeKind.Local).AddTicks(4488), new DateTime(2024, 7, 17, 23, 45, 4, 520, DateTimeKind.Local).AddTicks(4483), new DateTime(2024, 7, 17, 23, 45, 4, 520, DateTimeKind.Local).AddTicks(4487), "AQAAAAIAAYagAAAAEAJAi15A3T97zluCK7XJNVqEC95LuyQCsxWwlx8YHlBTnDtIQa/xZCGaG+PBUdAXpA==", "5259e4c2-ac6d-4527-9b2d-5c96a5f11de9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31ec8cde-1e81-41a7-b2fe-35943b127c66", new DateTime(2024, 7, 17, 23, 45, 4, 481, DateTimeKind.Local).AddTicks(912), new DateTime(2024, 7, 17, 23, 45, 4, 481, DateTimeKind.Local).AddTicks(900), new DateTime(2024, 7, 17, 23, 45, 4, 481, DateTimeKind.Local).AddTicks(912), "AQAAAAIAAYagAAAAEC/wqpq8tXbZ8y1d1TQnu5FgaQxI6068Umg9Wzd7sTVjnm4rEwcCljjl8WC+kPE5Vw==", "58531423-aaab-490c-93db-d72bf12fcaff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "475f8841-0226-4ed5-bcae-511fc2c671e6", new DateTime(2024, 7, 17, 23, 45, 4, 560, DateTimeKind.Local).AddTicks(2022), new DateTime(2024, 7, 17, 23, 45, 4, 560, DateTimeKind.Local).AddTicks(2012), new DateTime(2024, 7, 17, 23, 45, 4, 560, DateTimeKind.Local).AddTicks(2022), "AQAAAAIAAYagAAAAECGkEgsG/9yp/CGGgZvBTlAG/he7+8hOBiQ5CFUosNdio2Xei4D33IHtgEG7WnXQwA==", "15d8ed58-c517-48cf-884a-6dd32d92552c" });
        }
    }
}
