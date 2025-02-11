﻿using MediMed.Models;
using Microsoft.EntityFrameworkCore;

namespace MediMed.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<HealthTip> HealthTips { get; set; }
        public DbSet<NursePatient> NursePatients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NursePatient>()
       .HasKey(np => new { np.NurseId, np.PatientId });

            modelBuilder.Entity<NursePatient>()
                .HasOne(np => np.Nurse)
                .WithMany(n => n.NursePatients)
                .HasForeignKey(np => np.NurseId);

            modelBuilder.Entity<NursePatient>()
                .HasOne(np => np.Patient)
                .WithMany(p => p.NursePatients)
                .HasForeignKey(np => np.PatientId);

            // Seed data (if needed)
            
            // Seed Nurses
            modelBuilder.Entity<Nurse>().HasData(
                new Nurse
                {
                    Id = 1,
                    FirstName = "Ahmed",
                    LastName = "Ali",
                    LicenseNumber = "RN123456",
                    Contact = "+201234567890",
                    ProfessionalPracticeLicense = "https://example.com/nurse1/professional-license.jpg",
                    GraduationCertificate = "https://example.com/nurse1/graduation-certificate.jpg",
                    IDCard = "https://example.com/nurse1/id-card.jpg",
                    CriminalRecordAndIdentification = "https://example.com/nurse1/criminal-record.jpg",
                    Address = "123 Main St, Cairo, Egypt",
                    Location = "Cairo"
                },
                new Nurse
                {
                    Id = 2,
                    FirstName = "Fatima",
                    LastName = "Mohamed",
                    LicenseNumber = "RN654321",
                    Contact = "+201098765432",
                    ProfessionalPracticeLicense = "https://example.com/nurse2/professional-license.jpg",
                    GraduationCertificate = "https://example.com/nurse2/graduation-certificate.jpg",
                    IDCard = "https://example.com/nurse2/id-card.jpg",
                    CriminalRecordAndIdentification = "https://example.com/nurse2/criminal-record.jpg",
                    Address = "456 Elm St, Alexandria, Egypt",
                    Location = "Alexandria"
                }
            );

            // Seed Patients

            // Seed HealthTips
            modelBuilder.Entity<HealthTip>().HasData(
                new HealthTip
                {
                    Id = 1,
                    Tip = "Drink at least 8 glasses of water daily."
                },
                new HealthTip
                {
                    Id = 2,
                    Tip = "Get at least 7-8 hours of sleep every night."
                },
                new HealthTip
                {
                    Id = 3,
                    Tip = "Exercise for at least 30 minutes a day."
                },
                new HealthTip
                {
                    Id = 4,
                    Tip = "Eat a balanced diet with plenty of fruits and vegetables."
                },
                new HealthTip
                {
                    Id = 5,
                    Tip = "Avoid smoking and limit alcohol consumption."
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
