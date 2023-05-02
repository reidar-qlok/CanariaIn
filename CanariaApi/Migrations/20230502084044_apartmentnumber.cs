using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanariaApi.Migrations
{
    /// <inheritdoc />
    public partial class apartmentnumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentNumbers",
                columns: table => new
                {
                    ApartmentNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentNumbers", x => x.ApartmentNo);
                });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 10, 40, 44, 277, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 10, 40, 44, 277, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 10, 40, 44, 277, DateTimeKind.Local).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 10, 40, 44, 277, DateTimeKind.Local).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 10, 40, 44, 277, DateTimeKind.Local).AddTicks(1415));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentNumbers");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 20, 58, 29, 182, DateTimeKind.Local).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 20, 58, 29, 182, DateTimeKind.Local).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 20, 58, 29, 182, DateTimeKind.Local).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 20, 58, 29, 182, DateTimeKind.Local).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 20, 58, 29, 182, DateTimeKind.Local).AddTicks(6327));
        }
    }
}
