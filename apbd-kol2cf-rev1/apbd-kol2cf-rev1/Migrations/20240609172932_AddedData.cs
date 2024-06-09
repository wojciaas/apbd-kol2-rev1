using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apbd_kol2cf_rev1.Migrations
{
    /// <inheritdoc />
    public partial class AddedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BoatStandard",
                columns: new[] { "IdBoatStandard", "Level", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Standard" },
                    { 2, 2, "Premium" },
                    { 3, 3, "Luxury" }
                });

            migrationBuilder.InsertData(
                table: "ClientCategory",
                columns: new[] { "IdClientCategory", "DiscountPerc", "Name" },
                values: new object[,]
                {
                    { 1, 0, "VIP" },
                    { 2, 0, "Regular" },
                    { 3, 0, "Poor" }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "IdClient", "Birthday", "Email", "IdClientCategory", "LastName", "Name", "Pesel" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jkowal@ex.com", 2, "Kowalski", "Jan", "12345678901" },
                    { 2, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nowakA@ex.com", 3, "Nowak", "Anna", "12345678902" },
                    { 3, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pwis@ex.com", 1, "Wiśniewski", "Piotr", "12345678903" }
                });

            migrationBuilder.InsertData(
                table: "Sailboat",
                columns: new[] { "IdSailboat", "Capacity", "Description", "IdBoatStandard", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 5, "Sailboat1 description", 1, "Sailboat1", 100m },
                    { 2, 6, "Sailboat2 description", 2, "Sailboat2", 200m },
                    { 3, 7, "Sailboat3 description", 3, "Sailboat3", 300m }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "IdReservation", "CancelReason", "Capacity", "DateFrom", "DateTo", "Fullfilled", "IdBoatStandard", "IdClient", "NumOfBoats", "Price" },
                values: new object[,]
                {
                    { 1, null, 2, new DateTime(2021, 6, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 1, 1, 100m },
                    { 2, null, 4, new DateTime(2021, 6, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 2, 1, 200m },
                    { 3, null, 6, new DateTime(2021, 6, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 3, 1, 300m }
                });

            migrationBuilder.InsertData(
                table: "Sailboat_Reservation",
                columns: new[] { "IdReservation", "IdSailboat" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sailboat_Reservation",
                keyColumns: new[] { "IdReservation", "IdSailboat" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Sailboat_Reservation",
                keyColumns: new[] { "IdReservation", "IdSailboat" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Sailboat_Reservation",
                keyColumns: new[] { "IdReservation", "IdSailboat" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "IdReservation",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sailboat",
                keyColumn: "IdSailboat",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sailboat",
                keyColumn: "IdSailboat",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sailboat",
                keyColumn: "IdSailboat",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BoatStandard",
                keyColumn: "IdBoatStandard",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BoatStandard",
                keyColumn: "IdBoatStandard",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BoatStandard",
                keyColumn: "IdBoatStandard",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "IdClient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClientCategory",
                keyColumn: "IdClientCategory",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientCategory",
                keyColumn: "IdClientCategory",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClientCategory",
                keyColumn: "IdClientCategory",
                keyValue: 3);
        }
    }
}
