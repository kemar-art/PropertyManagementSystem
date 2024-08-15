using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class r : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedForm",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "CancelledForm",
                table: "Forms");

            migrationBuilder.RenameColumn(
                name: "ValuationRequiredBy",
                table: "Forms",
                newName: "DateSubmittedForApproval");

            migrationBuilder.RenameColumn(
                name: "SubmittedFormForApproval",
                table: "Forms",
                newName: "DateReturnToAppraiser");

            migrationBuilder.RenameColumn(
                name: "ReturnFromToAppraiser",
                table: "Forms",
                newName: "DateRejected");

            migrationBuilder.RenameColumn(
                name: "RejectedForm",
                table: "Forms",
                newName: "DateInProcess");

            migrationBuilder.RenameColumn(
                name: "MarkFromAsCompleted",
                table: "Forms",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "FromAssigned",
                table: "Forms",
                newName: "DateCompleted");

            migrationBuilder.RenameColumn(
                name: "FromAccepted",
                table: "Forms",
                newName: "DateCancelled");

            migrationBuilder.RenameColumn(
                name: "FormInProcess",
                table: "Forms",
                newName: "DateAssigned");

            migrationBuilder.RenameColumn(
                name: "DateFormWasFilledOut",
                table: "Forms",
                newName: "DateApproved");

            migrationBuilder.RenameColumn(
                name: "DataCreated",
                table: "Forms",
                newName: "DateAccepted");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37b07aba-a715-466f-90f0-502eb2a3fadb", new DateTime(2024, 8, 15, 10, 41, 57, 731, DateTimeKind.Local).AddTicks(3440), new DateTime(2024, 8, 15, 10, 41, 57, 731, DateTimeKind.Local).AddTicks(3421), new DateTime(2024, 8, 15, 10, 41, 57, 731, DateTimeKind.Local).AddTicks(3439), "AQAAAAIAAYagAAAAEF2tvi3NUcp9x2N2x0VtM9E6cGRb5deyTDnZwqDDL/7LDoYGVKM8m20EHAPVJl6QQQ==", "4ec95644-6fdf-45d3-b328-c74a7c232d7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5bb9c452-3447-4f72-a136-01d8d7ab6691", new DateTime(2024, 8, 15, 10, 41, 57, 674, DateTimeKind.Local).AddTicks(1290), new DateTime(2024, 8, 15, 10, 41, 57, 674, DateTimeKind.Local).AddTicks(1266), new DateTime(2024, 8, 15, 10, 41, 57, 674, DateTimeKind.Local).AddTicks(1290), "AQAAAAIAAYagAAAAEEg5I0nqpo4lNO1n0nPQyIqLHAcA3mKkFskbkhlETbkEMc+isv5ENd64MyXaEQt8WQ==", "bb5877de-d6a4-46b4-988d-67b3eaee76fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c6b51ca-901f-4ee6-bad4-bd1b1c998db1", new DateTime(2024, 8, 15, 10, 41, 57, 793, DateTimeKind.Local).AddTicks(4793), new DateTime(2024, 8, 15, 10, 41, 57, 793, DateTimeKind.Local).AddTicks(4763), new DateTime(2024, 8, 15, 10, 41, 57, 793, DateTimeKind.Local).AddTicks(4792), "AQAAAAIAAYagAAAAEG2Hv7BN1gjs07dFN4/RFTrkjMy3hHvWK/TROddthFFB5zf0AIt/4N/2wO+H902zIQ==", "d61187ad-49b7-4ca5-a1c2-9544e1343011" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateSubmittedForApproval",
                table: "Forms",
                newName: "ValuationRequiredBy");

            migrationBuilder.RenameColumn(
                name: "DateReturnToAppraiser",
                table: "Forms",
                newName: "SubmittedFormForApproval");

            migrationBuilder.RenameColumn(
                name: "DateRejected",
                table: "Forms",
                newName: "ReturnFromToAppraiser");

            migrationBuilder.RenameColumn(
                name: "DateInProcess",
                table: "Forms",
                newName: "RejectedForm");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Forms",
                newName: "MarkFromAsCompleted");

            migrationBuilder.RenameColumn(
                name: "DateCompleted",
                table: "Forms",
                newName: "FromAssigned");

            migrationBuilder.RenameColumn(
                name: "DateCancelled",
                table: "Forms",
                newName: "FromAccepted");

            migrationBuilder.RenameColumn(
                name: "DateAssigned",
                table: "Forms",
                newName: "FormInProcess");

            migrationBuilder.RenameColumn(
                name: "DateApproved",
                table: "Forms",
                newName: "DateFormWasFilledOut");

            migrationBuilder.RenameColumn(
                name: "DateAccepted",
                table: "Forms",
                newName: "DataCreated");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedForm",
                table: "Forms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelledForm",
                table: "Forms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1180cbe2-3f5c-4a5f-b5b3-62c4837d4368", new DateTime(2024, 8, 15, 8, 50, 41, 129, DateTimeKind.Local).AddTicks(4038), new DateTime(2024, 8, 15, 8, 50, 41, 129, DateTimeKind.Local).AddTicks(4028), new DateTime(2024, 8, 15, 8, 50, 41, 129, DateTimeKind.Local).AddTicks(4037), "AQAAAAIAAYagAAAAEKR2CJZ5xKSfPY/E5b1apYKc6Hr4T3s+4B4Ue5AQE8sLz7FEzVBQ+LVMGfqDfouLxg==", "34e80a9d-7f01-4ec1-9585-7b59bd859ed2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d5c4916-a85f-478f-a082-2309b28bbcd4", new DateTime(2024, 8, 15, 8, 50, 41, 63, DateTimeKind.Local).AddTicks(2597), new DateTime(2024, 8, 15, 8, 50, 41, 63, DateTimeKind.Local).AddTicks(2583), new DateTime(2024, 8, 15, 8, 50, 41, 63, DateTimeKind.Local).AddTicks(2596), "AQAAAAIAAYagAAAAEN89BypIB1NhItjUfS/h68tk+5OgwzUmcdfWLcmvGXAoErChTcZPkQqzF+WvKtWOpQ==", "6849287c-0095-4907-a3f6-16a800a26cc0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a30d44b-78dc-422f-a5a8-75dd6846e7d6", new DateTime(2024, 8, 15, 8, 50, 41, 190, DateTimeKind.Local).AddTicks(5150), new DateTime(2024, 8, 15, 8, 50, 41, 190, DateTimeKind.Local).AddTicks(5111), new DateTime(2024, 8, 15, 8, 50, 41, 190, DateTimeKind.Local).AddTicks(5149), "AQAAAAIAAYagAAAAEJ5uRSsnG21/qdH8bUwe1mLyEcWqN8W9ywCqthctPNOqa7qo3EvNmx48NguCmYCbwQ==", "581b9add-855e-4614-a01a-35c280758531" });
        }
    }
}
