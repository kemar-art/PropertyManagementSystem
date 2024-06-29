using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNotesPropertyToForm : Migration
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
                    { "4cb8218a-f54a-472f-84db-275ff92a659f", 0, "", "6e1f5f7e-f3c1-40e4-990c-51a6c705ac39", new DateTime(2024, 6, 28, 22, 23, 32, 552, DateTimeKind.Local).AddTicks(8316), new DateTime(2024, 6, 28, 22, 23, 32, 552, DateTimeKind.Local).AddTicks(8304), new DateTime(2024, 6, 28, 22, 23, 32, 552, DateTimeKind.Local).AddTicks(8315), "appraiser@localhost.com", true, "Appraiser", "", "", "Appraiser", false, null, "", "APPRAISER@LOCALHOST.COM", "APPRAISER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEOeYdfkgsfcTk3LTvEtRPoBjTZgco3MuM9O702f3UCQ7RaiHcxk57EfrHfcbEg2iIg==", null, false, "", "c9162294-9a50-4149-ab82-514f74b5da25", "", false, "appraiser@localhost.com" },
                    { "588cc79d-bfba-4063-a577-a08a19ff3fba", 0, "", "e6288e35-84bc-44a2-a73f-1d583b2c0479", new DateTime(2024, 6, 28, 22, 23, 32, 514, DateTimeKind.Local).AddTicks(3959), new DateTime(2024, 6, 28, 22, 23, 32, 514, DateTimeKind.Local).AddTicks(3951), new DateTime(2024, 6, 28, 22, 23, 32, 514, DateTimeKind.Local).AddTicks(3959), "admin@localhost.com", true, "Admin", "", "", "Admin", false, null, "", "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEP1WZAQ8HuxbJzdF+2j3ybj3iNpAr9coTaQybUfqLVHl20k8wufvvAk5q/T3zaB18A==", null, false, "", "e48d1e19-dc5d-4247-b630-e7974c1cb1a3", "", false, "admin@localhost.com" },
                    { "89d67a78-bd8e-4e72-93dc-602de068282a", 0, "", "955acfff-7230-4d0a-90f5-c0ff16c5e6b2", new DateTime(2024, 6, 28, 22, 23, 32, 590, DateTimeKind.Local).AddTicks(3475), new DateTime(2024, 6, 28, 22, 23, 32, 590, DateTimeKind.Local).AddTicks(3470), new DateTime(2024, 6, 28, 22, 23, 32, 590, DateTimeKind.Local).AddTicks(3474), "client@localhost.com", true, "Client", "", "", "Client", false, null, "", "CLIENT@LOCALHOST.COM", "CLIENT@LOCALHOST.COM", "AQAAAAIAAYagAAAAEIYYl0AVctTRfF6x/MKSHUnvGvARvYvLkBCec8JsHTpJ67MGYMs5xEMgo4nY7d/aTw==", null, false, "", "7e555b38-8cea-4e03-a2f2-36b811bb1868", "", false, "client@localhost.com" }
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
