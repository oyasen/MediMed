﻿// <auto-generated />
using System;
using MediMed.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediMed.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MediMed.Models.HealthTip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HealthTips");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Tip = "Drink at least 8 glasses of water daily."
                        },
                        new
                        {
                            Id = 2,
                            Tip = "Get at least 7-8 hours of sleep every night."
                        },
                        new
                        {
                            Id = 3,
                            Tip = "Exercise for at least 30 minutes a day."
                        },
                        new
                        {
                            Id = 4,
                            Tip = "Eat a balanced diet with plenty of fruits and vegetables."
                        },
                        new
                        {
                            Id = 5,
                            Tip = "Avoid smoking and limit alcohol consumption."
                        });
                });

            modelBuilder.Entity("MediMed.Models.Nurse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CriminalRecordAndIdentification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GraduationCertificate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfessionalPracticeLicense")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nurses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St, Cairo, Egypt",
                            Contact = "+201234567890",
                            CriminalRecordAndIdentification = "https://example.com/nurse1/criminal-record.jpg",
                            Email = "",
                            FirstName = "Ahmed",
                            GraduationCertificate = "https://example.com/nurse1/graduation-certificate.jpg",
                            IDCard = "https://example.com/nurse1/id-card.jpg",
                            LastName = "Ali",
                            LicenseNumber = "RN123456",
                            Location = "Cairo",
                            Password = "",
                            ProfessionalPracticeLicense = "https://example.com/nurse1/professional-license.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St, Alexandria, Egypt",
                            Contact = "+201098765432",
                            CriminalRecordAndIdentification = "https://example.com/nurse2/criminal-record.jpg",
                            Email = "",
                            FirstName = "Fatima",
                            GraduationCertificate = "https://example.com/nurse2/graduation-certificate.jpg",
                            IDCard = "https://example.com/nurse2/id-card.jpg",
                            LastName = "Mohamed",
                            LicenseNumber = "RN654321",
                            Location = "Alexandria",
                            Password = "",
                            ProfessionalPracticeLicense = "https://example.com/nurse2/professional-license.jpg"
                        });
                });

            modelBuilder.Entity("MediMed.Models.NursePatient", b =>
                {
                    b.Property<int>("NurseId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("NurseId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("NursePatients");
                });

            modelBuilder.Entity("MediMed.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Contact = "+201112223344",
                            DateOfBirth = new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "",
                            FirstName = "Mohamed",
                            Gender = "Male",
                            IDCard = "https://example.com/patient1/id-card.jpg",
                            LastName = "Hassan",
                            Location = "Cairo",
                            Password = ""
                        },
                        new
                        {
                            Id = 2,
                            Contact = "+201122334455",
                            DateOfBirth = new DateTime(1990, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "",
                            FirstName = "Aisha",
                            Gender = "Female",
                            IDCard = "https://example.com/patient2/id-card.jpg",
                            LastName = "Mahmoud",
                            Location = "Alexandria",
                            Password = ""
                        });
                });

            modelBuilder.Entity("MediMed.Models.NursePatient", b =>
                {
                    b.HasOne("MediMed.Models.Nurse", "Nurse")
                        .WithMany("NursePatients")
                        .HasForeignKey("NurseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediMed.Models.Patient", "Patient")
                        .WithMany("NursePatients")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nurse");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MediMed.Models.Nurse", b =>
                {
                    b.Navigation("NursePatients");
                });

            modelBuilder.Entity("MediMed.Models.Patient", b =>
                {
                    b.Navigation("NursePatients");
                });
#pragma warning restore 612, 618
        }
    }
}
