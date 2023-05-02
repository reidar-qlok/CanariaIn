using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanariaApi.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeytoapartmentnumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FkApartmentId",
                table: "ApartmentNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 13, 6, 57, 594, DateTimeKind.Local).AddTicks(9078));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 13, 6, 57, 594, DateTimeKind.Local).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 13, 6, 57, 594, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 13, 6, 57, 594, DateTimeKind.Local).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "ApartmentId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 2, 13, 6, 57, 594, DateTimeKind.Local).AddTicks(9207));

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentNumbers_FkApartmentId",
                table: "ApartmentNumbers",
                column: "FkApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentNumbers_Apartments_FkApartmentId",
                table: "ApartmentNumbers",
                column: "FkApartmentId",
                principalTable: "Apartments",
                principalColumn: "ApartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentNumbers_Apartments_FkApartmentId",
                table: "ApartmentNumbers");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentNumbers_FkApartmentId",
                table: "ApartmentNumbers");

            migrationBuilder.DropColumn(
                name: "FkApartmentId",
                table: "ApartmentNumbers");

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
    }
}
