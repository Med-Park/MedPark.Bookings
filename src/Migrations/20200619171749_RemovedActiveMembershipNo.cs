using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.Bookings.Migrations
{
    public partial class RemovedActiveMembershipNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "PatientMedicalScheme");

            migrationBuilder.DropColumn(
                name: "MembershipNo",
                table: "PatientMedicalScheme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "PatientMedicalScheme",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MembershipNo",
                table: "PatientMedicalScheme",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
