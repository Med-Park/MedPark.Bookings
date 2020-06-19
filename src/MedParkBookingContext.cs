using MedPark.Bookings.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings
{
    public class MedParkBookingContext : DbContext
    {
        DbSet<Appointment> Appointment { get; set; }
        DbSet<Patient> Customer { get; set; }
        DbSet<Specialist> Specialist { get; set; }
        DbSet<MedicalScheme> MedicalScheme { get; set; }
        DbSet<PatientMedicalScheme> PatientMedicalScheme { get; set; }

        public MedParkBookingContext(DbContextOptions<MedParkBookingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Appointment>().ToTable("Appointment");
            builder.Entity<Patient>().ToTable("Patient");
            builder.Entity<Specialist>().ToTable("Specialist");
            builder.Entity<MedicalScheme>().ToTable("MedicalScheme");
            builder.Entity<PatientMedicalScheme>().ToTable("PatientMedicalScheme");
        }
    }
}
