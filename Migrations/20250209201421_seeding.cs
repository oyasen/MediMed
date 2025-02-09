using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediMed.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HealthTips",
                columns: new[] { "Id", "Tip" },
                values: new object[,]
                {
                    { 1, "Drink at least 8 glasses of water daily." },
                    { 2, "Get at least 7-8 hours of sleep every night." },
                    { 3, "Exercise for at least 30 minutes a day." },
                    { 4, "Eat a balanced diet with plenty of fruits and vegetables." },
                    { 5, "Avoid smoking and limit alcohol consumption." }
                });

            migrationBuilder.InsertData(
                table: "Nurses",
                columns: new[] { "Id", "Address", "Contact", "CriminalRecordAndIdentification", "FirstName", "GraduationCertificate", "IDCard", "LastName", "LicenseNumber", "Location", "ProfessionalPracticeLicense" },
                values: new object[,]
                {
                    { 1, "123 Main St, Cairo, Egypt", "+201234567890", "https://example.com/nurse1/criminal-record.jpg", "Ahmed", "https://example.com/nurse1/graduation-certificate.jpg", "https://example.com/nurse1/id-card.jpg", "Ali", "RN123456", "Cairo", "https://example.com/nurse1/professional-license.jpg" },
                    { 2, "456 Elm St, Alexandria, Egypt", "+201098765432", "https://example.com/nurse2/criminal-record.jpg", "Fatima", "https://example.com/nurse2/graduation-certificate.jpg", "https://example.com/nurse2/id-card.jpg", "Mohamed", "RN654321", "Alexandria", "https://example.com/nurse2/professional-license.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Contact", "DateOfBirth", "FirstName", "Gender", "IDCard", "LastName", "Location" },
                values: new object[,]
                {
                    { 1, "+201112223344", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mohamed", "Male", "https://example.com/patient1/id-card.jpg", "Hassan", "Cairo" },
                    { 2, "+201122334455", new DateTime(1990, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aisha", "Female", "https://example.com/patient2/id-card.jpg", "Mahmoud", "Alexandria" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HealthTips",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HealthTips",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HealthTips",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HealthTips",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HealthTips",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
