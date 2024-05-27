using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initailmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    SecondaryContactFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryContactLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryContactPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
