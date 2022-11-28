using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAB_2_Solution_grp5.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Participants",
                table: "Activities");

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_Participants_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "MaintenanceLogs",
                keyColumn: "MaintenanceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 11, 12, 4, 11, 31, 839, DateTimeKind.Local).AddTicks(5624));

            migrationBuilder.UpdateData(
                table: "MaintenanceLogs",
                keyColumn: "MaintenanceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 11, 12, 4, 11, 31, 839, DateTimeKind.Local).AddTicks(5666));

            migrationBuilder.InsertData(
                table: "MaintenanceLogs",
                columns: new[] { "MaintenanceId", "Date", "Description", "FacilityId", "PersId" },
                values: new object[] { 3, new DateTime(2022, 11, 11, 21, 11, 31, 839, DateTimeKind.Local).AddTicks(5669), "Rengjort toilletter", 1, 2 });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "ParticipantId", "ActivityId", "Cpr" },
                values: new object[,]
                {
                    { 1, 1, "123021-1234" },
                    { 2, 1, "123021-2345" },
                    { 3, 2, "123021-3456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ActivityId",
                table: "Participants",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DeleteData(
                table: "MaintenanceLogs",
                keyColumn: "MaintenanceId",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "Participants",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 1,
                column: "Participants",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 2,
                column: "Participants",
                value: 10);

            migrationBuilder.UpdateData(
                table: "MaintenanceLogs",
                keyColumn: "MaintenanceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 11, 11, 15, 9, 3, 805, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "MaintenanceLogs",
                keyColumn: "MaintenanceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 11, 11, 15, 9, 3, 805, DateTimeKind.Local).AddTicks(7919));
        }
    }
}
