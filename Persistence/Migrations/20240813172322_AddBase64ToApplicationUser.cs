using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddBase64ToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87b42647-8bcf-4c29-8c8b-bf27e5967335", new DateTime(2024, 8, 13, 12, 23, 21, 585, DateTimeKind.Local).AddTicks(4595), new DateTime(2024, 8, 13, 12, 23, 21, 585, DateTimeKind.Local).AddTicks(4584), new DateTime(2024, 8, 13, 12, 23, 21, 585, DateTimeKind.Local).AddTicks(4594), "AQAAAAIAAYagAAAAEGNGD+iT0qaLlIMIMwGLMFdywRwEpBWJMvPAYYWNRmbusaX4A95xxAfmB+ggfDHZtg==", "416e6e94-ef3e-46ca-95ab-c58fe12041e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0980fd06-fd87-43da-98ef-2de7c5be0baf", new DateTime(2024, 8, 13, 12, 23, 21, 527, DateTimeKind.Local).AddTicks(14), new DateTime(2024, 8, 13, 12, 23, 21, 527, DateTimeKind.Local), new DateTime(2024, 8, 13, 12, 23, 21, 527, DateTimeKind.Local).AddTicks(14), "AQAAAAIAAYagAAAAEEtG9wcpK80/90fvRZahT3aa206jYHfBy70XuxbSn0ChJrRW2zu5PQZNiJb3dduIVQ==", "9b7f1e22-80dd-4031-83a3-2149d2d06050" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8119ac81-1ea7-463f-8505-d7c0acbfb38c", new DateTime(2024, 8, 13, 12, 23, 21, 646, DateTimeKind.Local).AddTicks(439), new DateTime(2024, 8, 13, 12, 23, 21, 646, DateTimeKind.Local).AddTicks(406), new DateTime(2024, 8, 13, 12, 23, 21, 646, DateTimeKind.Local).AddTicks(439), "AQAAAAIAAYagAAAAEH6JiSmqJH8l5OBhbYrU1Ov+x/lY64W9bC6KdtonHUAuEeTKO8qI+jNNGXajR9011Q==", "340a5829-5af3-4c29-96e1-f53a9090cc4f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4cb8218a-f54a-472f-84db-275ff92a659f",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "778a2b55-516e-4f49-8767-47522a7bc127", new DateTime(2024, 8, 6, 21, 41, 31, 707, DateTimeKind.Local).AddTicks(831), new DateTime(2024, 8, 6, 21, 41, 31, 707, DateTimeKind.Local).AddTicks(827), new DateTime(2024, 8, 6, 21, 41, 31, 707, DateTimeKind.Local).AddTicks(831), "AQAAAAIAAYagAAAAEDvY4mk4DUO8ftJBCdskT7soNDm1cvVPa6IaPvpG4MlJ3Xw0a8sa6QVx1RILvwc5fQ==", "37cfa910-f329-4057-92c9-8d68d09e6e6e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "588cc79d-bfba-4063-a577-a08a19ff3fba",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fd8a3a3-e780-4d5e-8cd7-b25c441604c5", new DateTime(2024, 8, 6, 21, 41, 31, 666, DateTimeKind.Local).AddTicks(7954), new DateTime(2024, 8, 6, 21, 41, 31, 666, DateTimeKind.Local).AddTicks(7945), new DateTime(2024, 8, 6, 21, 41, 31, 666, DateTimeKind.Local).AddTicks(7954), "AQAAAAIAAYagAAAAEHVX3Qr3iuZ/OEfDagzRiUJEcegmxHTxfw6xV/xFIiCJ2lfa97v6NwD9X/mCBQXg7Q==", "8cde622f-46dc-43b1-a689-ab35c1b60bad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d67a78-bd8e-4e72-93dc-602de068282a",
                columns: new[] { "ConcurrencyStamp", "DateEnded", "DateOfBirth", "DateRegistered", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bdba3c3-906c-42e4-9f07-ef6c8830e955", new DateTime(2024, 8, 6, 21, 41, 31, 745, DateTimeKind.Local).AddTicks(6783), new DateTime(2024, 8, 6, 21, 41, 31, 745, DateTimeKind.Local).AddTicks(6773), new DateTime(2024, 8, 6, 21, 41, 31, 745, DateTimeKind.Local).AddTicks(6783), "AQAAAAIAAYagAAAAEGOPMQ0UAY75DrnMSlpgjfBhUtL0q9x6npUazlMz+kOTO6wE8SAxC2J1xF9zYS5dPA==", "f81c97ac-eaf3-4ab9-af06-ef3b279e40cc" });
        }
    }
}
