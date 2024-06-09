using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apbd_kol2cf_rev1.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoatStandard",
                columns: table => new
                {
                    IdBoatStandard = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatStandard", x => x.IdBoatStandard);
                });

            migrationBuilder.CreateTable(
                name: "ClientCategory",
                columns: table => new
                {
                    IdClientCategory = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiscountPerc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCategory", x => x.IdClientCategory);
                });

            migrationBuilder.CreateTable(
                name: "Sailboat",
                columns: table => new
                {
                    IdSailboat = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdBoatStandard = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sailboat", x => x.IdSailboat);
                    table.ForeignKey(
                        name: "Sailboat_BoatStandard",
                        column: x => x.IdBoatStandard,
                        principalTable: "BoatStandard",
                        principalColumn: "IdBoatStandard",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdClientCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                    table.ForeignKey(
                        name: "Client_ClientCategory",
                        column: x => x.IdClientCategory,
                        principalTable: "ClientCategory",
                        principalColumn: "IdClientCategory",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdBoatStandard = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    NumOfBoats = table.Column<int>(type: "int", nullable: false),
                    Fullfilled = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    CancelReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.IdReservation);
                    table.ForeignKey(
                        name: "BoatStandard_Reservation",
                        column: x => x.IdBoatStandard,
                        principalTable: "BoatStandard",
                        principalColumn: "IdBoatStandard",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Client_Reservation",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sailboat_Reservation",
                columns: table => new
                {
                    IdSailboat = table.Column<int>(type: "int", nullable: false),
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sailboat_Reservation", x => new { x.IdReservation, x.IdSailboat });
                    table.ForeignKey(
                        name: "Sailboat_Reservation_Reservation",
                        column: x => x.IdReservation,
                        principalTable: "Reservation",
                        principalColumn: "IdReservation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Sailboat_Reservation_Sailboat",
                        column: x => x.IdSailboat,
                        principalTable: "Sailboat",
                        principalColumn: "IdSailboat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdClientCategory",
                table: "Client",
                column: "IdClientCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdBoatStandard",
                table: "Reservation",
                column: "IdBoatStandard");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdClient",
                table: "Reservation",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Sailboat_IdBoatStandard",
                table: "Sailboat",
                column: "IdBoatStandard");

            migrationBuilder.CreateIndex(
                name: "IX_Sailboat_Reservation_IdSailboat",
                table: "Sailboat_Reservation",
                column: "IdSailboat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sailboat_Reservation");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Sailboat");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "BoatStandard");

            migrationBuilder.DropTable(
                name: "ClientCategory");
        }
    }
}
