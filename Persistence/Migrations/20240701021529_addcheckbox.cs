using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addcheckbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurposeOfValuationCheckBoxProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurposeOfValuationCheckBoxProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequestCheckBoxProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequestCheckBoxProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfPropertyCheckBoxProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPropertyCheckBoxProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurposeOfValuationCheckBoxes",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "int", nullable: false),
                    PurposeOfValuationCheckBoxPropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurposeOfValuationCheckBoxes", x => new { x.FormId, x.PurposeOfValuationCheckBoxPropertyId });
                    table.ForeignKey(
                        name: "FK_PurposeOfValuationCheckBoxes_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurposeOfValuationCheckBoxes_PurposeOfValuationCheckBoxProperties_PurposeOfValuationCheckBoxPropertyId",
                        column: x => x.PurposeOfValuationCheckBoxPropertyId,
                        principalTable: "PurposeOfValuationCheckBoxProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequestCheckBoxes",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "int", nullable: false),
                    ServiceRequestCheckBoxPropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequestCheckBoxes", x => new { x.FormId, x.ServiceRequestCheckBoxPropertyId });
                    table.ForeignKey(
                        name: "FK_ServiceRequestCheckBoxes_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequestCheckBoxes_ServiceRequestCheckBoxProperties_ServiceRequestCheckBoxPropertyId",
                        column: x => x.ServiceRequestCheckBoxPropertyId,
                        principalTable: "ServiceRequestCheckBoxProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfPropertyCheckBoxes",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "int", nullable: false),
                    TypeOfPropertyCheckBoxPropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPropertyCheckBoxes", x => new { x.FormId, x.TypeOfPropertyCheckBoxPropertyId });
                    table.ForeignKey(
                        name: "FK_TypeOfPropertyCheckBoxes_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeOfPropertyCheckBoxes_TypeOfPropertyCheckBoxProperties_TypeOfPropertyCheckBoxPropertyId",
                        column: x => x.TypeOfPropertyCheckBoxPropertyId,
                        principalTable: "TypeOfPropertyCheckBoxProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05d8df58-2c94-4d36-860e-69f04d55f312", new DateTime(2024, 6, 30, 21, 15, 29, 5, DateTimeKind.Local).AddTicks(8360), new DateTime(2024, 6, 30, 21, 15, 29, 5, DateTimeKind.Local).AddTicks(8352), new DateTime(2024, 6, 30, 21, 15, 29, 5, DateTimeKind.Local).AddTicks(8360), "AQAAAAIAAYagAAAAELlW1RyjhtwC6kCFayfzPC5VkhHGVTt42m26/07OJpAm7RQiMWzS+og+esE2y+zBHA==", "a11b61be-f97c-4781-a80f-23f2258ffb76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd4aa7cc-6efa-4f91-aed8-9d9513eaf38a", new DateTime(2024, 6, 30, 21, 15, 28, 964, DateTimeKind.Local).AddTicks(5527), new DateTime(2024, 6, 30, 21, 15, 28, 964, DateTimeKind.Local).AddTicks(5516), new DateTime(2024, 6, 30, 21, 15, 28, 964, DateTimeKind.Local).AddTicks(5527), "AQAAAAIAAYagAAAAEC0WcPZdQgJL7ZHBMbqsJ7jqK2OAuxz2YUsdGkCep6JDWEfKmVhiOmOZseYJf3mNaw==", "571dcc03-b882-4b1e-a737-8cdc8dd78697" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a77602e8-b2d2-4632-b861-b3005cbdebe5", new DateTime(2024, 6, 30, 21, 15, 29, 45, DateTimeKind.Local).AddTicks(3509), new DateTime(2024, 6, 30, 21, 15, 29, 45, DateTimeKind.Local).AddTicks(3502), new DateTime(2024, 6, 30, 21, 15, 29, 45, DateTimeKind.Local).AddTicks(3509), "AQAAAAIAAYagAAAAECOv/oHqhwrxlLwLeQ1ImHsaLgHCs8uRHho3RIKtesnEGD8KqX3zErFruCyGBpp9ag==", "40613276-b1d3-429e-afd9-971ba85c2d71" });

            migrationBuilder.InsertData(
                table: "PurposeOfValuationCheckBoxProperties",
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
                table: "ServiceRequestCheckBoxProperties",
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
                table: "TypeOfPropertyCheckBoxProperties",
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
                name: "IX_PurposeOfValuationCheckBoxes_PurposeOfValuationCheckBoxPropertyId",
                table: "PurposeOfValuationCheckBoxes",
                column: "PurposeOfValuationCheckBoxPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequestCheckBoxes_ServiceRequestCheckBoxPropertyId",
                table: "ServiceRequestCheckBoxes",
                column: "ServiceRequestCheckBoxPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfPropertyCheckBoxes_TypeOfPropertyCheckBoxPropertyId",
                table: "TypeOfPropertyCheckBoxes",
                column: "TypeOfPropertyCheckBoxPropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurposeOfValuationCheckBoxes");

            migrationBuilder.DropTable(
                name: "ServiceRequestCheckBoxes");

            migrationBuilder.DropTable(
                name: "TypeOfPropertyCheckBoxes");

            migrationBuilder.DropTable(
                name: "PurposeOfValuationCheckBoxProperties");

            migrationBuilder.DropTable(
                name: "ServiceRequestCheckBoxProperties");

            migrationBuilder.DropTable(
                name: "TypeOfPropertyCheckBoxProperties");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e1f5f7e-f3c1-40e4-990c-51a6c705ac39", new DateTime(2024, 6, 28, 22, 23, 32, 552, DateTimeKind.Local).AddTicks(8316), new DateTime(2024, 6, 28, 22, 23, 32, 552, DateTimeKind.Local).AddTicks(8304), new DateTime(2024, 6, 28, 22, 23, 32, 552, DateTimeKind.Local).AddTicks(8315), "AQAAAAIAAYagAAAAEOeYdfkgsfcTk3LTvEtRPoBjTZgco3MuM9O702f3UCQ7RaiHcxk57EfrHfcbEg2iIg==", "c9162294-9a50-4149-ab82-514f74b5da25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6288e35-84bc-44a2-a73f-1d583b2c0479", new DateTime(2024, 6, 28, 22, 23, 32, 514, DateTimeKind.Local).AddTicks(3959), new DateTime(2024, 6, 28, 22, 23, 32, 514, DateTimeKind.Local).AddTicks(3951), new DateTime(2024, 6, 28, 22, 23, 32, 514, DateTimeKind.Local).AddTicks(3959), "AQAAAAIAAYagAAAAEP1WZAQ8HuxbJzdF+2j3ybj3iNpAr9coTaQybUfqLVHl20k8wufvvAk5q/T3zaB18A==", "e48d1e19-dc5d-4247-b630-e7974c1cb1a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "955acfff-7230-4d0a-90f5-c0ff16c5e6b2", new DateTime(2024, 6, 28, 22, 23, 32, 590, DateTimeKind.Local).AddTicks(3475), new DateTime(2024, 6, 28, 22, 23, 32, 590, DateTimeKind.Local).AddTicks(3470), new DateTime(2024, 6, 28, 22, 23, 32, 590, DateTimeKind.Local).AddTicks(3474), "AQAAAAIAAYagAAAAEIYYl0AVctTRfF6x/MKSHUnvGvARvYvLkBCec8JsHTpJ67MGYMs5xEMgo4nY7d/aTw==", "7e555b38-8cea-4e03-a2f2-36b811bb1868" });
        }
    }
}
