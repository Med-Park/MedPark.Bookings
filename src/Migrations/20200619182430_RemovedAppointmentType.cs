using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.Bookings.Migrations
{
    public partial class RemovedAppointmentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentType",
                table: "Appointment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentType",
                table: "Appointment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
