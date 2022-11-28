using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAB_2_Solution_grp5.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    CitizenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.CitizenId);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.FacilityId);
                });

            migrationBuilder.CreateTable(
                name: "Personnels",
                columns: table => new
                {
                    PersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnels", x => x.PersId);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Participants = table.Column<int>(type: "int", nullable: false),
                    CitizenId = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "CitizenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceLogs",
                columns: table => new
                {
                    MaintenanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    PersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceLogs", x => x.MaintenanceId);
                    table.ForeignKey(
                        name: "FK_MaintenanceLogs_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceLogs_Personnels_PersId",
                        column: x => x.PersId,
                        principalTable: "Personnels",
                        principalColumn: "PersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "CitizenId", "CVR", "Category", "Email", "Namee", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "12103023031", "Business", "Clara@gmail.com", "Clara", "25252525" },
                    { 2, "109876543", "Forretning", "Rasmus@gmail.com", "Rasmus", "42345677" },
                    { 3, "098765432", "Forretning", "Heja@gmail.com", "Heja", "42336789" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "FacilityId", "Address", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "stranvej 123", "God plads", "AarhusStrand", "Privat" },
                    { 2, "navitasvej 123", "Den ligger ved haven kanten", "Navitas", "Forretning" },
                    { 3, "Langelandsgade 123", "Skole", "Aarhus Universitet", "Forretning" },
                    { 4, "Pauldan müllersvej", "Ligger i aarhus N", "Storcenter Nord", "Shopping" }
                });

            migrationBuilder.InsertData(
                table: "Personnels",
                column: "PersId",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "CitizenId", "EndDate", "EndTime", "FacilityId", "Note", "Participants", "StartDate", "StartTime" },
                values: new object[,]
                {
                    { 1, 3, "2/1/2022", new TimeSpan(0, 12, 0, 0, 0), 4, "jnjcxdzrtfyguhijokpszxrtfgyhuijokl", 5, "1/1/2022", new TimeSpan(0, 10, 0, 0, 0) },
                    { 2, 1, "3/2/2022", new TimeSpan(0, 10, 0, 0, 0), 2, "jnjcxdzrtfyguhijokpszxrtfgyhuijokl", 10, "2/2/2022", new TimeSpan(0, 8, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceLogs",
                columns: new[] { "MaintenanceId", "Date", "Description", "FacilityId", "PersId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 11, 15, 2, 31, 211, DateTimeKind.Local).AddTicks(3996), "Ved ikke", 1, 1 },
                    { 2, new DateTime(2022, 11, 11, 15, 2, 31, 211, DateTimeKind.Local).AddTicks(4028), "gegikvep", 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CitizenId",
                table: "Activities",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_FacilityId",
                table: "Activities",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogs_FacilityId",
                table: "MaintenanceLogs",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogs_PersId",
                table: "MaintenanceLogs",
                column: "PersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "MaintenanceLogs");

            migrationBuilder.DropTable(
                name: "Citizens");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Personnels");
        }
    }
}
