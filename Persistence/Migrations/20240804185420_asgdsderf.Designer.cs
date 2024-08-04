﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.DatabaseContext;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(PMSDatabaseContext))]
    [Migration("20240804185420_asgdsderf")]
    partial class asgdsderf
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateEnded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NationalInsuranceScheme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxRegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "588cc79d-bfba-4063-a577-a08a19ff3fba",
                            AccessFailedCount = 0,
                            Address = "",
                            ConcurrencyStamp = "e7efaae7-45f3-4435-be41-93e25aa98d8b",
                            DateEnded = new DateTime(2024, 8, 4, 13, 54, 20, 103, DateTimeKind.Local).AddTicks(7799),
                            DateOfBirth = new DateTime(2024, 8, 4, 13, 54, 20, 103, DateTimeKind.Local).AddTicks(7785),
                            DateRegistered = new DateTime(2024, 8, 4, 13, 54, 20, 103, DateTimeKind.Local).AddTicks(7798),
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            Gender = "",
                            ImagePath = "",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NationalInsuranceScheme = "",
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEKULTwDOfAUltULqNFWm7ilsY+pIubHgDVoAu3xIjr8ZOBb9Kjy1tEUoAD66IPULHg==",
                            PhoneNumberConfirmed = false,
                            Role = "",
                            SecurityStamp = "4d546455-a762-43e2-be8d-b92bbbb03757",
                            TaxRegistrationNumber = "",
                            TwoFactorEnabled = false,
                            UserName = "admin@localhost.com"
                        },
                        new
                        {
                            Id = "4cb8218a-f54a-472f-84db-275ff92a659f",
                            AccessFailedCount = 0,
                            Address = "",
                            ConcurrencyStamp = "76653e5d-7d2a-47c1-9128-a8524daea8c7",
                            DateEnded = new DateTime(2024, 8, 4, 13, 54, 20, 164, DateTimeKind.Local).AddTicks(6130),
                            DateOfBirth = new DateTime(2024, 8, 4, 13, 54, 20, 164, DateTimeKind.Local).AddTicks(6104),
                            DateRegistered = new DateTime(2024, 8, 4, 13, 54, 20, 164, DateTimeKind.Local).AddTicks(6129),
                            Email = "appraiser@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "Appraiser",
                            Gender = "",
                            ImagePath = "",
                            LastName = "Appraiser",
                            LockoutEnabled = false,
                            NationalInsuranceScheme = "",
                            NormalizedEmail = "APPRAISER@LOCALHOST.COM",
                            NormalizedUserName = "APPRAISER@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEFaq1vMF+tjpry0pWx+53D3eIIYUU4V3xHcvAA5xbT4lXwYE8ReuvLOxks0wWEpU0g==",
                            PhoneNumberConfirmed = false,
                            Role = "",
                            SecurityStamp = "fed9ba7c-099e-4eeb-8967-c2e3c93e15d8",
                            TaxRegistrationNumber = "",
                            TwoFactorEnabled = false,
                            UserName = "appraiser@localhost.com"
                        },
                        new
                        {
                            Id = "89d67a78-bd8e-4e72-93dc-602de068282a",
                            AccessFailedCount = 0,
                            Address = "",
                            ConcurrencyStamp = "e3682881-de65-45cb-8009-81e44f779608",
                            DateEnded = new DateTime(2024, 8, 4, 13, 54, 20, 222, DateTimeKind.Local).AddTicks(6674),
                            DateOfBirth = new DateTime(2024, 8, 4, 13, 54, 20, 222, DateTimeKind.Local).AddTicks(6657),
                            DateRegistered = new DateTime(2024, 8, 4, 13, 54, 20, 222, DateTimeKind.Local).AddTicks(6674),
                            Email = "client@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "Client",
                            Gender = "",
                            ImagePath = "",
                            LastName = "Client",
                            LockoutEnabled = false,
                            NationalInsuranceScheme = "",
                            NormalizedEmail = "CLIENT@LOCALHOST.COM",
                            NormalizedUserName = "CLIENT@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEBOLzBFbR+HfwiMCRdChNwppOtYhra21cbl4SphM+3qqyDAAkRArKvp2r5nQHYygSQ==",
                            PhoneNumberConfirmed = false,
                            Role = "",
                            SecurityStamp = "dc996855-6f1e-4d53-be6a-217c08972bce",
                            TaxRegistrationNumber = "",
                            TwoFactorEnabled = false,
                            UserName = "client@localhost.com"
                        });
                });

            modelBuilder.Entity("Domain.CheckBoxItems.PurposeOfValuationItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PurposeOfValuationItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("58267416-7f04-4835-a58d-4312388daa00"),
                            IsChecked = false,
                            Title = "Market Value"
                        },
                        new
                        {
                            Id = new Guid("665cbc87-cce3-406a-939f-fcded826144b"),
                            IsChecked = false,
                            Title = "Sale"
                        },
                        new
                        {
                            Id = new Guid("d0a14c91-db14-4cb0-bac0-4b3906b98c90"),
                            IsChecked = false,
                            Title = "Purchase"
                        },
                        new
                        {
                            Id = new Guid("aaab7fca-32b7-477e-9686-1b07a9029c78"),
                            IsChecked = false,
                            Title = "Mortgage"
                        },
                        new
                        {
                            Id = new Guid("9c969106-3a24-464a-bef2-92bcbfceb831"),
                            IsChecked = false,
                            Title = "Insurance"
                        },
                        new
                        {
                            Id = new Guid("f19291ab-2852-42ad-a29b-c3fdc91caf35"),
                            IsChecked = false,
                            Title = "Probate"
                        });
                });

            modelBuilder.Entity("Domain.CheckBoxItems.ServiceRequestItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServiceRequestItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8a7f9203-3906-41ea-8345-de258ff9d23a"),
                            IsChecked = false,
                            Title = "VALUATION"
                        },
                        new
                        {
                            Id = new Guid("3f2bd4ce-b418-43f2-8cc6-58096bafbf92"),
                            IsChecked = false,
                            Title = "LAND SURVEYOR"
                        },
                        new
                        {
                            Id = new Guid("7bc822a4-0b9f-4783-94e2-536b4833d4e6"),
                            IsChecked = false,
                            Title = "LEGAL REPRESENTATION"
                        },
                        new
                        {
                            Id = new Guid("c464358d-7c96-40b5-9530-8596796bfecc"),
                            IsChecked = false,
                            Title = "SALES/RENTALS"
                        },
                        new
                        {
                            Id = new Guid("db1069d2-7ba8-4ead-89d9-c2ad3c4805ca"),
                            IsChecked = false,
                            Title = "AUCTION"
                        },
                        new
                        {
                            Id = new Guid("23d13fcf-3e3c-46b1-aad3-02e0fb63dcd7"),
                            IsChecked = false,
                            Title = "PROPERTY MANAGEMENT"
                        },
                        new
                        {
                            Id = new Guid("bf8207bc-5c6b-4c01-9559-9b2488b04dcb"),
                            IsChecked = false,
                            Title = "STRUCTURAL SURVEY"
                        },
                        new
                        {
                            Id = new Guid("d1b9d319-ff21-4a37-842d-a6a0073ef246"),
                            IsChecked = false,
                            Title = "CONSTRUCTION ESTIMATE"
                        },
                        new
                        {
                            Id = new Guid("75c9ad78-7831-4c87-b83b-4bb51d0ea542"),
                            IsChecked = false,
                            Title = "GENERAL CONTRACTOR"
                        },
                        new
                        {
                            Id = new Guid("a316cb71-7ced-4053-8b05-2078555007c2"),
                            IsChecked = false,
                            Title = "OTHER"
                        });
                });

            modelBuilder.Entity("Domain.CheckBoxItems.TypeOfPropertyItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfPropertyItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("61817dfe-5a97-4bc1-8f5a-ca92a7637b97"),
                            IsChecked = false,
                            Title = "Commercial"
                        },
                        new
                        {
                            Id = new Guid("ce6a20ec-d833-4cee-8301-365c796e7467"),
                            IsChecked = false,
                            Title = "Residential"
                        },
                        new
                        {
                            Id = new Guid("d5c0a1ba-4cad-4ec7-a4de-39d7b1e0b723"),
                            IsChecked = false,
                            Title = "Agricultural"
                        },
                        new
                        {
                            Id = new Guid("a13c3ef8-1c60-4be9-bc68-947e93f1ed7c"),
                            IsChecked = false,
                            Title = "Industrial"
                        },
                        new
                        {
                            Id = new Guid("0f60350d-072b-43f8-9026-9896cd0b601f"),
                            IsChecked = false,
                            Title = "Vacant Lot"
                        });
                });

            modelBuilder.Entity("Domain.Form", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppraiserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppraiserNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ApprovedForm")
                        .HasColumnType("datetime2");

                    b.Property<string>("BackOfPropertyImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CancelledForm")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<DateTime>("DataCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFormWasFilledOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Folio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FormInProcess")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FromAccepted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FromAssigned")
                        .HasColumnType("datetime2");

                    b.Property<string>("FrontOfProperyImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstructionsIssuedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsKeyAvailable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobAssignerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeftSideOfPropertImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MarkFromAsCompleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MortgageInstitution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Other")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyDirection")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RejectedForm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnFromToAppraiser")
                        .HasColumnType("datetime2");

                    b.Property<string>("RightSideOfPropertyImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryContactPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrataPlan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SubmittedFormForApproval")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValuationRequiredBy")
                        .HasColumnType("datetime2");

                    b.Property<string>("Volume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppraiserId");

                    b.HasIndex("JobAssignerId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("Domain.FormInteractionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdminNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AppraiserNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LogMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Submitted")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("FormId");

                    b.ToTable("FormInteractionLogs");
                });

            modelBuilder.Entity("Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountiesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8c8a6b61-43f9-4b7c-ab58-be16c05762b4"),
                            CountiesName = "Surrey",
                            ParishName = "Kingston"
                        },
                        new
                        {
                            Id = new Guid("49ebba81-a529-490c-add9-37046df783f4"),
                            CountiesName = "Surrey",
                            ParishName = "St. Andrew"
                        },
                        new
                        {
                            Id = new Guid("67a014d7-dbc6-40e7-a5b8-8eb12edfd68b"),
                            CountiesName = "Surrey",
                            ParishName = "Portland"
                        },
                        new
                        {
                            Id = new Guid("5d3bb8cd-bdb8-4752-9a53-b656e2543481"),
                            CountiesName = "Surrey",
                            ParishName = "St. Thomas"
                        },
                        new
                        {
                            Id = new Guid("02befa99-5924-4fea-a633-3736e651a2dc"),
                            CountiesName = "Middlesex",
                            ParishName = "St. Catherine"
                        },
                        new
                        {
                            Id = new Guid("05b21946-589d-4195-a632-1f0c554206bb"),
                            CountiesName = "Middlesex",
                            ParishName = "St. Mary"
                        },
                        new
                        {
                            Id = new Guid("cfcfccac-f17b-4ae2-96af-2a4be6b42ba2"),
                            CountiesName = "Middlesex",
                            ParishName = "St. Ann"
                        },
                        new
                        {
                            Id = new Guid("bc5cee4e-a273-4b67-8697-23a489b041fe"),
                            CountiesName = "Middlesex",
                            ParishName = "Manchester"
                        },
                        new
                        {
                            Id = new Guid("1d0844ea-761c-4d00-8446-57cbed7d971a"),
                            CountiesName = "Middlesex",
                            ParishName = "Clarendon"
                        },
                        new
                        {
                            Id = new Guid("5cc3280f-7a72-4fa0-9452-d320bc5dc000"),
                            CountiesName = "Cornwall",
                            ParishName = "Hanover"
                        },
                        new
                        {
                            Id = new Guid("2f020ff7-8b30-48ff-8aff-caf7f18503c2"),
                            CountiesName = "Cornwall",
                            ParishName = "Westmoreland"
                        },
                        new
                        {
                            Id = new Guid("d6b104f3-693f-4c43-8035-21661b61a82b"),
                            CountiesName = "Cornwall",
                            ParishName = "St. James"
                        },
                        new
                        {
                            Id = new Guid("957748c0-ba86-4764-b8c7-a8c0c0bc20c8"),
                            CountiesName = "Cornwall",
                            ParishName = "Trelawny"
                        },
                        new
                        {
                            Id = new Guid("e80ac700-0536-476a-8c7e-467a25a13f55"),
                            CountiesName = "Cornwall",
                            ParishName = "St. Elizabeth"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "0b3c24a8-fd98-4dd7-8e8e-13b70a7ccc9c",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "1ff8b9a5-91cd-478d-942d-baaca93a4bf9",
                            Name = "Appraiser",
                            NormalizedName = "APPRAISER"
                        },
                        new
                        {
                            Id = "abcf3529-e04c-4fc6-b654-da3f444b3c0c",
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "588cc79d-bfba-4063-a577-a08a19ff3fba",
                            RoleId = "0b3c24a8-fd98-4dd7-8e8e-13b70a7ccc9c"
                        },
                        new
                        {
                            UserId = "4cb8218a-f54a-472f-84db-275ff92a659f",
                            RoleId = "1ff8b9a5-91cd-478d-942d-baaca93a4bf9"
                        },
                        new
                        {
                            UserId = "89d67a78-bd8e-4e72-93dc-602de068282a",
                            RoleId = "abcf3529-e04c-4fc6-b654-da3f444b3c0c"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Form", b =>
                {
                    b.HasOne("Domain.ApplicationUser", "Appraiser")
                        .WithMany()
                        .HasForeignKey("AppraiserId");

                    b.HasOne("Domain.ApplicationUser", "JobAssigner")
                        .WithMany()
                        .HasForeignKey("JobAssignerId");

                    b.Navigation("Appraiser");

                    b.Navigation("JobAssigner");
                });

            modelBuilder.Entity("Domain.FormInteractionLog", b =>
                {
                    b.HasOne("Domain.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Form", "Form")
                        .WithMany()
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Form");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
