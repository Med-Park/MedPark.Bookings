using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.Bookings.Migrations
{
    public partial class AddedPatientAddedPatientMedScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropColumn(
                name: "HasMedicalAid",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "MedicalAidMembershipNo",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PatientEmail",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PatientMobile",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PatientSurname",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "SpecialistEmail",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "SpecialistInitials",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "SpecialistSurname",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "SpecialistTel",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "MedicalScheme",
                table: "Appointment",
                newName: "PatientMedicalSchemeId");

            migrationBuilder.CreateTable(
                name: "MedicalScheme",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    SchemeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalScheme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicalScheme",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: false),
                    SchemeId = table.Column<Guid>(nullable: false),
                    MembershipNo = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicalScheme", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalScheme");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "PatientMedicalScheme");

            migrationBuilder.RenameColumn(
                name: "PatientMedicalSchemeId",
                table: "Appointment",
                newName: "MedicalScheme");

            migrationBuilder.AddColumn<bool>(
                name: "HasMedicalAid",
                table: "Appointment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MedicalAidMembershipNo",
                table: "Appointment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientEmail",
                table: "Appointment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientMobile",
                table: "Appointment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "Appointment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientSurname",
                table: "Appointment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialistEmail",
                table: "Appointment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialistInitials",
                table: "Appointment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialistSurname",
                table: "Appointment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialistTel",
                table: "Appointment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Appointment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
        }
    }
}
