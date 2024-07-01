﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.DatabaseContext;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(PMSDatabaseContext))]
    partial class PMSDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
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

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Datestarted")
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
                            ConcurrencyStamp = "bd4aa7cc-6efa-4f91-aed8-9d9513eaf38a",
                            DateEnded = new DateTime(2024, 6, 30, 21, 15, 28, 964, DateTimeKind.Local).AddTicks(5527),
                            DateOfBirth = new DateTime(2024, 6, 30, 21, 15, 28, 964, DateTimeKind.Local).AddTicks(5516),
                            Datestarted = new DateTime(2024, 6, 30, 21, 15, 28, 964, DateTimeKind.Local).AddTicks(5527),
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
                            PasswordHash = "AQAAAAIAAYagAAAAEC0WcPZdQgJL7ZHBMbqsJ7jqK2OAuxz2YUsdGkCep6JDWEfKmVhiOmOZseYJf3mNaw==",
                            PhoneNumberConfirmed = false,
                            Role = "",
                            SecurityStamp = "571dcc03-b882-4b1e-a737-8cdc8dd78697",
                            TaxRegistrationNumber = "",
                            TwoFactorEnabled = false,
                            UserName = "admin@localhost.com"
                        },
                        new
                        {
                            Id = "4cb8218a-f54a-472f-84db-275ff92a659f",
                            AccessFailedCount = 0,
                            Address = "",
                            ConcurrencyStamp = "05d8df58-2c94-4d36-860e-69f04d55f312",
                            DateEnded = new DateTime(2024, 6, 30, 21, 15, 29, 5, DateTimeKind.Local).AddTicks(8360),
                            DateOfBirth = new DateTime(2024, 6, 30, 21, 15, 29, 5, DateTimeKind.Local).AddTicks(8352),
                            Datestarted = new DateTime(2024, 6, 30, 21, 15, 29, 5, DateTimeKind.Local).AddTicks(8360),
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
                            PasswordHash = "AQAAAAIAAYagAAAAELlW1RyjhtwC6kCFayfzPC5VkhHGVTt42m26/07OJpAm7RQiMWzS+og+esE2y+zBHA==",
                            PhoneNumberConfirmed = false,
                            Role = "",
                            SecurityStamp = "a11b61be-f97c-4781-a80f-23f2258ffb76",
                            TaxRegistrationNumber = "",
                            TwoFactorEnabled = false,
                            UserName = "appraiser@localhost.com"
                        },
                        new
                        {
                            Id = "89d67a78-bd8e-4e72-93dc-602de068282a",
                            AccessFailedCount = 0,
                            Address = "",
                            ConcurrencyStamp = "a77602e8-b2d2-4632-b861-b3005cbdebe5",
                            DateEnded = new DateTime(2024, 6, 30, 21, 15, 29, 45, DateTimeKind.Local).AddTicks(3509),
                            DateOfBirth = new DateTime(2024, 6, 30, 21, 15, 29, 45, DateTimeKind.Local).AddTicks(3502),
                            Datestarted = new DateTime(2024, 6, 30, 21, 15, 29, 45, DateTimeKind.Local).AddTicks(3509),
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
                            PasswordHash = "AQAAAAIAAYagAAAAECOv/oHqhwrxlLwLeQ1ImHsaLgHCs8uRHho3RIKtesnEGD8KqX3zErFruCyGBpp9ag==",
                            PhoneNumberConfirmed = false,
                            Role = "",
                            SecurityStamp = "40613276-b1d3-429e-afd9-971ba85c2d71",
                            TaxRegistrationNumber = "",
                            TwoFactorEnabled = false,
                            UserName = "client@localhost.com"
                        });
                });

            modelBuilder.Entity("Domain.CheckBox.PurposeValuation.PurposeOfValuationCheckBox", b =>
                {
                    b.Property<int?>("FormId")
                        .HasColumnType("int");

                    b.Property<int>("PurposeOfValuationCheckBoxPropertyId")
                        .HasColumnType("int");

                    b.HasKey("FormId", "PurposeOfValuationCheckBoxPropertyId");

                    b.HasIndex("PurposeOfValuationCheckBoxPropertyId");

                    b.ToTable("PurposeOfValuationCheckBoxes");
                });

            modelBuilder.Entity("Domain.CheckBox.PurposeValuation.PurposeOfValuationCheckBoxProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PurposeOfValuationCheckBoxProperties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsChecked = false,
                            Title = "Market Value"
                        },
                        new
                        {
                            Id = 2,
                            IsChecked = false,
                            Title = "Sale"
                        },
                        new
                        {
                            Id = 3,
                            IsChecked = false,
                            Title = "Purchase"
                        },
                        new
                        {
                            Id = 4,
                            IsChecked = false,
                            Title = "Mortgage"
                        },
                        new
                        {
                            Id = 5,
                            IsChecked = false,
                            Title = "Insurance"
                        },
                        new
                        {
                            Id = 6,
                            IsChecked = false,
                            Title = "Probate"
                        });
                });

            modelBuilder.Entity("Domain.CheckBox.ServiceRequest.ServiceRequestCheckBox", b =>
                {
                    b.Property<int?>("FormId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceRequestCheckBoxPropertyId")
                        .HasColumnType("int");

                    b.HasKey("FormId", "ServiceRequestCheckBoxPropertyId");

                    b.HasIndex("ServiceRequestCheckBoxPropertyId");

                    b.ToTable("ServiceRequestCheckBoxes");
                });

            modelBuilder.Entity("Domain.CheckBox.ServiceRequest.ServiceRequestCheckBoxProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServiceRequestCheckBoxProperties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsChecked = false,
                            Title = "VALUATION"
                        },
                        new
                        {
                            Id = 2,
                            IsChecked = false,
                            Title = "LAND SURVEYOR"
                        },
                        new
                        {
                            Id = 3,
                            IsChecked = false,
                            Title = "LEGAL REPRESENTATION"
                        },
                        new
                        {
                            Id = 4,
                            IsChecked = false,
                            Title = "SALES/RENTALS"
                        },
                        new
                        {
                            Id = 5,
                            IsChecked = false,
                            Title = "AUCTION"
                        },
                        new
                        {
                            Id = 6,
                            IsChecked = false,
                            Title = "PROPERTY MANAGEMENT"
                        },
                        new
                        {
                            Id = 7,
                            IsChecked = false,
                            Title = "STRUCTURAL SURVEY"
                        },
                        new
                        {
                            Id = 8,
                            IsChecked = false,
                            Title = "CONSTRUCTION ESTIMATE"
                        },
                        new
                        {
                            Id = 9,
                            IsChecked = false,
                            Title = "GENERAL CONTRACTOR"
                        },
                        new
                        {
                            Id = 10,
                            IsChecked = false,
                            Title = "OTHER"
                        });
                });

            modelBuilder.Entity("Domain.CheckBox.TypeOfProperty.TypeOfPropertyCheckBox", b =>
                {
                    b.Property<int?>("FormId")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfPropertyCheckBoxPropertyId")
                        .HasColumnType("int");

                    b.HasKey("FormId", "TypeOfPropertyCheckBoxPropertyId");

                    b.HasIndex("TypeOfPropertyCheckBoxPropertyId");

                    b.ToTable("TypeOfPropertyCheckBoxes");
                });

            modelBuilder.Entity("Domain.CheckBox.TypeOfProperty.TypeOfPropertyCheckBoxProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfPropertyCheckBoxProperties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsChecked = false,
                            Title = "Commercial"
                        },
                        new
                        {
                            Id = 2,
                            IsChecked = false,
                            Title = "Residential"
                        },
                        new
                        {
                            Id = 3,
                            IsChecked = false,
                            Title = "Agricultural"
                        },
                        new
                        {
                            Id = 4,
                            IsChecked = false,
                            Title = "Industrial"
                        },
                        new
                        {
                            Id = 5,
                            IsChecked = false,
                            Title = "Vacant Lot"
                        });
                });

            modelBuilder.Entity("Domain.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<DateTime>("CancelledForm")
                        .HasColumnType("datetime2");

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

                    b.Property<int>("Folio")
                        .HasColumnType("int");

                    b.Property<DateTime>("FormInProcess")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FromAccepted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FromAssigned")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstructionsIssuedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsKeyAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("JobAssignerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
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

                    b.Property<string>("SecondaryContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryContactFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryContactLastName")
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

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppraiserId");

                    b.HasIndex("JobAssignerId");

                    b.ToTable("Forms");
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

            modelBuilder.Entity("Domain.CheckBox.PurposeValuation.PurposeOfValuationCheckBox", b =>
                {
                    b.HasOne("Domain.Form", "Form")
                        .WithMany("PurposeOfValuationCheckBoxItems")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.CheckBox.PurposeValuation.PurposeOfValuationCheckBoxProperty", "PurposeOfValuationCheckBoxProperty")
                        .WithMany("PurposeOfValuationItemCheckBoxes")
                        .HasForeignKey("PurposeOfValuationCheckBoxPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");

                    b.Navigation("PurposeOfValuationCheckBoxProperty");
                });

            modelBuilder.Entity("Domain.CheckBox.ServiceRequest.ServiceRequestCheckBox", b =>
                {
                    b.HasOne("Domain.Form", "Form")
                        .WithMany("ServiceRequestCheckBoxItems")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.CheckBox.ServiceRequest.ServiceRequestCheckBoxProperty", "ServiceRequestCheckBoxProperty")
                        .WithMany("ServiceRequestCheckBoxes")
                        .HasForeignKey("ServiceRequestCheckBoxPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");

                    b.Navigation("ServiceRequestCheckBoxProperty");
                });

            modelBuilder.Entity("Domain.CheckBox.TypeOfProperty.TypeOfPropertyCheckBox", b =>
                {
                    b.HasOne("Domain.Form", "Form")
                        .WithMany("TypeOfPropertyCheckBoxItems")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.CheckBox.TypeOfProperty.TypeOfPropertyCheckBoxProperty", "TypeOfPropertyCheckProperty")
                        .WithMany("TypeOfPropertyCheckBoxes")
                        .HasForeignKey("TypeOfPropertyCheckBoxPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");

                    b.Navigation("TypeOfPropertyCheckProperty");
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

            modelBuilder.Entity("Domain.CheckBox.PurposeValuation.PurposeOfValuationCheckBoxProperty", b =>
                {
                    b.Navigation("PurposeOfValuationItemCheckBoxes");
                });

            modelBuilder.Entity("Domain.CheckBox.ServiceRequest.ServiceRequestCheckBoxProperty", b =>
                {
                    b.Navigation("ServiceRequestCheckBoxes");
                });

            modelBuilder.Entity("Domain.CheckBox.TypeOfProperty.TypeOfPropertyCheckBoxProperty", b =>
                {
                    b.Navigation("TypeOfPropertyCheckBoxes");
                });

            modelBuilder.Entity("Domain.Form", b =>
                {
                    b.Navigation("PurposeOfValuationCheckBoxItems");

                    b.Navigation("ServiceRequestCheckBoxItems");

                    b.Navigation("TypeOfPropertyCheckBoxItems");
                });
#pragma warning restore 612, 618
        }
    }
}
