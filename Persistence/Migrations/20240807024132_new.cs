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
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "PurposeOfValuationItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurposeOfValuationItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountiesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParishName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequestItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPropertyItems", x => x.Id);
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructionsIssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyDirection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Folio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrataPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsKeyAvailable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MortgageInstitution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    ApprovedForm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FrontOfProperyImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightSideOfPropertyImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeftSideOfPropertImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackOfPropertyImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfPropertySelectedIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceRequestItemSelectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurposeOfValuationItemSelectedIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Forms_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormInteractionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "Email", "EmailConfirmed", "FirstName", "Gender", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NationalInsuranceScheme", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TaxRegistrationNumber", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4cb8218a-f54a-472f-84db-275ff92a659f", 0, "", "778a2b55-516e-4f49-8767-47522a7bc127", new DateTime(2024, 8, 6, 21, 41, 31, 707, DateTimeKind.Local).AddTicks(831), new DateTime(2024, 8, 6, 21, 41, 31, 707, DateTimeKind.Local).AddTicks(827), new DateTime(2024, 8, 6, 21, 41, 31, 707, DateTimeKind.Local).AddTicks(831), "appraiser@localhost.com", true, "Appraiser", "", "", "Appraiser", false, null, "", "APPRAISER@LOCALHOST.COM", "APPRAISER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEDvY4mk4DUO8ftJBCdskT7soNDm1cvVPa6IaPvpG4MlJ3Xw0a8sa6QVx1RILvwc5fQ==", null, false, "", "37cfa910-f329-4057-92c9-8d68d09e6e6e", "", false, "appraiser@localhost.com" },
                    { "588cc79d-bfba-4063-a577-a08a19ff3fba", 0, "", "3fd8a3a3-e780-4d5e-8cd7-b25c441604c5", new DateTime(2024, 8, 6, 21, 41, 31, 666, DateTimeKind.Local).AddTicks(7954), new DateTime(2024, 8, 6, 21, 41, 31, 666, DateTimeKind.Local).AddTicks(7945), new DateTime(2024, 8, 6, 21, 41, 31, 666, DateTimeKind.Local).AddTicks(7954), "admin@localhost.com", true, "Admin", "", "", "Admin", false, null, "", "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEHVX3Qr3iuZ/OEfDagzRiUJEcegmxHTxfw6xV/xFIiCJ2lfa97v6NwD9X/mCBQXg7Q==", null, false, "", "8cde622f-46dc-43b1-a689-ab35c1b60bad", "", false, "admin@localhost.com" },
                    { "89d67a78-bd8e-4e72-93dc-602de068282a", 0, "", "6bdba3c3-906c-42e4-9f07-ef6c8830e955", new DateTime(2024, 8, 6, 21, 41, 31, 745, DateTimeKind.Local).AddTicks(6783), new DateTime(2024, 8, 6, 21, 41, 31, 745, DateTimeKind.Local).AddTicks(6773), new DateTime(2024, 8, 6, 21, 41, 31, 745, DateTimeKind.Local).AddTicks(6783), "client@localhost.com", true, "Client", "", "", "Client", false, null, "", "CLIENT@LOCALHOST.COM", "CLIENT@LOCALHOST.COM", "AQAAAAIAAYagAAAAEGOPMQ0UAY75DrnMSlpgjfBhUtL0q9x6npUazlMz+kOTO6wE8SAxC2J1xF9zYS5dPA==", null, false, "", "f81c97ac-eaf3-4ab9-af06-ef3b279e40cc", "", false, "client@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "PurposeOfValuationItems",
                columns: new[] { "Id", "IsChecked", "Title" },
                values: new object[,]
                {
                    { new Guid("58267416-7f04-4835-a58d-4312388daa00"), false, "Market Value" },
                    { new Guid("665cbc87-cce3-406a-939f-fcded826144b"), false, "Sale" },
                    { new Guid("9c969106-3a24-464a-bef2-92bcbfceb831"), false, "Insurance" },
                    { new Guid("aaab7fca-32b7-477e-9686-1b07a9029c78"), false, "Mortgage" },
                    { new Guid("d0a14c91-db14-4cb0-bac0-4b3906b98c90"), false, "Purchase" },
                    { new Guid("f19291ab-2852-42ad-a29b-c3fdc91caf35"), false, "Probate" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CountiesName", "ParishName" },
                values: new object[,]
                {
                    { new Guid("02befa99-5924-4fea-a633-3736e651a2dc"), "Middlesex", "St. Catherine" },
                    { new Guid("05b21946-589d-4195-a632-1f0c554206bb"), "Middlesex", "St. Mary" },
                    { new Guid("1d0844ea-761c-4d00-8446-57cbed7d971a"), "Middlesex", "Clarendon" },
                    { new Guid("2f020ff7-8b30-48ff-8aff-caf7f18503c2"), "Cornwall", "Westmoreland" },
                    { new Guid("49ebba81-a529-490c-add9-37046df783f4"), "Surrey", "St. Andrew" },
                    { new Guid("5cc3280f-7a72-4fa0-9452-d320bc5dc000"), "Cornwall", "Hanover" },
                    { new Guid("5d3bb8cd-bdb8-4752-9a53-b656e2543481"), "Surrey", "St. Thomas" },
                    { new Guid("67a014d7-dbc6-40e7-a5b8-8eb12edfd68b"), "Surrey", "Portland" },
                    { new Guid("8c8a6b61-43f9-4b7c-ab58-be16c05762b4"), "Surrey", "Kingston" },
                    { new Guid("957748c0-ba86-4764-b8c7-a8c0c0bc20c8"), "Cornwall", "Trelawny" },
                    { new Guid("bc5cee4e-a273-4b67-8697-23a489b041fe"), "Middlesex", "Manchester" },
                    { new Guid("cfcfccac-f17b-4ae2-96af-2a4be6b42ba2"), "Middlesex", "St. Ann" },
                    { new Guid("d6b104f3-693f-4c43-8035-21661b61a82b"), "Cornwall", "St. James" },
                    { new Guid("e80ac700-0536-476a-8c7e-467a25a13f55"), "Cornwall", "St. Elizabeth" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequestItems",
                columns: new[] { "Id", "IsChecked", "Title" },
                values: new object[,]
                {
                    { new Guid("23d13fcf-3e3c-46b1-aad3-02e0fb63dcd7"), false, "PROPERTY MANAGEMENT" },
                    { new Guid("3f2bd4ce-b418-43f2-8cc6-58096bafbf92"), false, "LAND SURVEYOR" },
                    { new Guid("75c9ad78-7831-4c87-b83b-4bb51d0ea542"), false, "GENERAL CONTRACTOR" },
                    { new Guid("7bc822a4-0b9f-4783-94e2-536b4833d4e6"), false, "LEGAL REPRESENTATION" },
                    { new Guid("8a7f9203-3906-41ea-8345-de258ff9d23a"), false, "VALUATION" },
                    { new Guid("a316cb71-7ced-4053-8b05-2078555007c2"), false, "OTHER" },
                    { new Guid("bf8207bc-5c6b-4c01-9559-9b2488b04dcb"), false, "STRUCTURAL SURVEY" },
                    { new Guid("c464358d-7c96-40b5-9530-8596796bfecc"), false, "SALES/RENTALS" },
                    { new Guid("d1b9d319-ff21-4a37-842d-a6a0073ef246"), false, "CONSTRUCTION ESTIMATE" },
                    { new Guid("db1069d2-7ba8-4ead-89d9-c2ad3c4805ca"), false, "AUCTION" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfPropertyItems",
                columns: new[] { "Id", "IsChecked", "Title" },
                values: new object[,]
                {
                    { new Guid("0f60350d-072b-43f8-9026-9896cd0b601f"), false, "Vacant Lot" },
                    { new Guid("61817dfe-5a97-4bc1-8f5a-ca92a7637b97"), false, "Commercial" },
                    { new Guid("a13c3ef8-1c60-4be9-bc68-947e93f1ed7c"), false, "Industrial" },
                    { new Guid("ce6a20ec-d833-4cee-8301-365c796e7467"), false, "Residential" },
                    { new Guid("d5c0a1ba-4cad-4ec7-a4de-39d7b1e0b723"), false, "Agricultural" }
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
                name: "IX_FormInteractionLogs_ApplicationUserId",
                table: "FormInteractionLogs",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FormInteractionLogs_FormId",
                table: "FormInteractionLogs",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_AppraiserId",
                table: "Forms",
                column: "AppraiserId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_JobAssignerId",
                table: "Forms",
                column: "JobAssignerId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_RegionId",
                table: "Forms",
                column: "RegionId");
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
                name: "FormInteractionLogs");

            migrationBuilder.DropTable(
                name: "PurposeOfValuationItems");

            migrationBuilder.DropTable(
                name: "ServiceRequestItems");

            migrationBuilder.DropTable(
                name: "TypeOfPropertyItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
