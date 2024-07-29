using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b56d24b-bbe2-4249-ad65-28a5c2e25596", new DateTime(2024, 7, 28, 19, 5, 36, 428, DateTimeKind.Local).AddTicks(2953), new DateTime(2024, 7, 28, 19, 5, 36, 428, DateTimeKind.Local).AddTicks(2948), new DateTime(2024, 7, 28, 19, 5, 36, 428, DateTimeKind.Local).AddTicks(2953), "AQAAAAIAAYagAAAAEDGzmLN8jELbwBdRYhYyw4kSrAce06E1OwhS2ofWxdASh6qqyJC4U7wiKdIampYKnA==", "5a30a528-bd68-4e92-9dee-0239e5618032" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d81cf255-424d-43cf-9357-9abc98a6669c", new DateTime(2024, 7, 28, 19, 5, 36, 389, DateTimeKind.Local).AddTicks(3160), new DateTime(2024, 7, 28, 19, 5, 36, 389, DateTimeKind.Local).AddTicks(3146), new DateTime(2024, 7, 28, 19, 5, 36, 389, DateTimeKind.Local).AddTicks(3159), "AQAAAAIAAYagAAAAECmFFhYU6T7NWla5BDq1C09NdcPHsuDsEC/OiDjo5y0N5HG6tXW3vymIGl9XZl90SQ==", "2cb0b1d0-4bbf-4e15-95d0-0313697de455" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a38823c6-acbe-4798-85cf-4cd457c8e93d", new DateTime(2024, 7, 28, 19, 5, 36, 466, DateTimeKind.Local).AddTicks(5526), new DateTime(2024, 7, 28, 19, 5, 36, 466, DateTimeKind.Local).AddTicks(5522), new DateTime(2024, 7, 28, 19, 5, 36, 466, DateTimeKind.Local).AddTicks(5526), "AQAAAAIAAYagAAAAEAeoDHIFjS94yJvPJLtWtZHfEo+MvSwC5GO7zVKN6lgp8n62D5tuXwBrvDUGXDg3mQ==", "7ab2ab3d-ae71-4237-8d65-36a4b8567131" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52a99854-8d26-4bca-8cee-03e202f56f03", new DateTime(2024, 7, 28, 16, 55, 36, 731, DateTimeKind.Local).AddTicks(8447), new DateTime(2024, 7, 28, 16, 55, 36, 731, DateTimeKind.Local).AddTicks(8432), new DateTime(2024, 7, 28, 16, 55, 36, 731, DateTimeKind.Local).AddTicks(8447), "AQAAAAIAAYagAAAAECjm6OoQZMWEeXvK3ICZ3xdVcYT93hyOUmTJZ0F4xNHrzQN2yTp2iHhTz+2Ya4z3cw==", "d01f7a85-3fe3-4256-a951-949e4451e83d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f40f88f7-b34f-4d2a-abcf-9baec2530c06", new DateTime(2024, 7, 28, 16, 55, 36, 690, DateTimeKind.Local).AddTicks(9885), new DateTime(2024, 7, 28, 16, 55, 36, 690, DateTimeKind.Local).AddTicks(9872), new DateTime(2024, 7, 28, 16, 55, 36, 690, DateTimeKind.Local).AddTicks(9884), "AQAAAAIAAYagAAAAELTlfQo9unyEkmJjTqSAirDFQj1CvVoV9dJDOb4jIxticgvRLMmVCb7vEnQs3lAQsQ==", "c67b92c8-93c1-4729-95c9-231b449617f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38648b34-f176-4b9a-8841-89cc9a1f1286", new DateTime(2024, 7, 28, 16, 55, 36, 771, DateTimeKind.Local).AddTicks(4262), new DateTime(2024, 7, 28, 16, 55, 36, 771, DateTimeKind.Local).AddTicks(4247), new DateTime(2024, 7, 28, 16, 55, 36, 771, DateTimeKind.Local).AddTicks(4262), "AQAAAAIAAYagAAAAELHFF8npeJXn2uNJRKXZTGgsk5sFW+tC8cKLoQ/EABzH0Xn6UMa65oouTY3WASWh2w==", "317957e3-f4ce-4187-a5c8-3a3aef35bf8e" });
        }
    }
}
