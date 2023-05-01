using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanariaApi.Migrations
{
    /// <inheritdoc />
    public partial class allin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 14, 39, 25, 827, DateTimeKind.Local).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 14, 39, 25, 827, DateTimeKind.Local).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 14, 39, 25, 827, DateTimeKind.Local).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 14, 39, 25, 827, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 1, 14, 39, 25, 827, DateTimeKind.Local).AddTicks(6256));
        }
    }
}
