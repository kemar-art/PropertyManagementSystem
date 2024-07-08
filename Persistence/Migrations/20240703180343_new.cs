using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalInsuranceScheme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Datestarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructionsIssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyDirection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    Folio = table.Column<int>(type: "int", nullable: false),
                    StrataPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsKeyAvailable = table.Column<bool>(type: "bit", nullable: false),
                    MortgageInstitution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryContactFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryContactLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryContactPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppraiserNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppraiserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JobAssignerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuationRequiredBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFormWasFilledOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromAssigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromAccepted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormInProcess = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RejectedForm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MarkFromAsCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnFromToAppraiser = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmittedFormForApproval = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelledForm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedForm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forms_AspNetUsers_AppraiserId",
                        column: x => x.AppraiserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Forms_AspNetUsers_JobAssignerId",
                        column: x => x.JobAssignerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b3c24a8-fd98-4dd7-8e8e-13b70a7ccc9c", null, "Administrator", "ADMINISTRATOR" },
                    { "1ff8b9a5-91cd-478d-942d-baaca93a4bf9", null, "Appraiser", "APPRAISER" },
                    { "abcf3529-e04c-4fc6-b654-da3f444b3c0c", null, "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateEnded", "DateOfBirth", "Datestarted", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NationalInsuranceScheme", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TaxRegistrationNumber", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4cb8218a-f54a-472f-84db-275ff92a659f", 0, "", "1048d917-33cd-4bda-8931-d956eb8f12b2", new DateTime(2024, 7, 3, 13, 3, 41, 632, DateTimeKind.Local).AddTicks(2816), new DateTime(2024, 7, 3, 13, 3, 41, 632, DateTimeKind.Local).AddTicks(2810), new DateTime(2024, 7, 3, 13, 3, 41, 632, DateTimeKind.Local).AddTicks(2816), "appraiser@localhost.com", true, "Appraiser", "", "", "Appraiser", false, null, "", "APPRAISER@LOCALHOST.COM", "APPRAISER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEAHD6bD53mL2kslK7z/6e2EtWYP2GbOrm0TxgXo9FHRUgTZZuU2lz5af7dBMUUfaDQ==", null, false, "", "6828af87-fd29-411d-b15b-ff94d2a5eea0", "", false, "appraiser@localhost.com" },
                    { "588cc79d-bfba-4063-a577-a08a19ff3fba", 0, "", "e124f3bf-9abf-479f-9192-3be8b687fe8f", new DateTime(2024, 7, 3, 13, 3, 41, 594, DateTimeKind.Local).AddTicks(1654), new DateTime(2024, 7, 3, 13, 3, 41, 594, DateTimeKind.Local).AddTicks(1644), new DateTime(2024, 7, 3, 13, 3, 41, 594, DateTimeKind.Local).AddTicks(1653), "admin@localhost.com", true, "Admin", "", "", "Admin", false, null, "", "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEPaEu351+CCo6mRJTkl8cqH6v4eoVdGkBIH3L/gPojlisRGBCrdoAosyY7VTHtRRjg==", null, false, "", "efd32fed-3c9f-42df-8270-1f22bca686e4", "", false, "admin@localhost.com" },
                    { "89d67a78-bd8e-4e72-93dc-602de068282a", 0, "", "afb1f687-022e-4e05-9724-a110d87b13f7", new DateTime(2024, 7, 3, 13, 3, 41, 671, DateTimeKind.Local).AddTicks(1359), new DateTime(2024, 7, 3, 13, 3, 41, 671, DateTimeKind.Local).AddTicks(1356), new DateTime(2024, 7, 3, 13, 3, 41, 671, DateTimeKind.Local).AddTicks(1359), "client@localhost.com", true, "Client", "", "", "Client", false, null, "", "CLIENT@LOCALHOST.COM", "CLIENT@LOCALHOST.COM", "AQAAAAIAAYagAAAAEDqgkRX44G1h4oy57u5J/1kr4YTDkYLmi0LbHLUcdUX5eNqXsr05ntDjfaqo/1s8mw==", null, false, "", "c439905d-a769-418f-bc33-a1b467be5104", "", false, "client@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1ff8b9a5-91cd-478d-942d-baaca93a4bf9", "4cb8218a-f54a-472f-84db-275ff92a659f" },
                    { "0b3c24a8-fd98-4dd7-8e8e-13b70a7ccc9c", "588cc79d-bfba-4063-a577-a08a19ff3fba" },
                    { "abcf3529-e04c-4fc6-b654-da3f444b3c0c", "89d67a78-bd8e-4e72-93dc-602de068282a" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_AppraiserId",
                table: "Forms",
                column: "AppraiserId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_JobAssignerId",
                table: "Forms",
                column: "JobAssignerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
