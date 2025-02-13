using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediMed.Migrations
{
    /// <inheritdoc />
    public partial class signup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Patients",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Patients",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Contact", "DateOfBirth", "Email", "FirstName", "Gender", "IDCard", "LastName", "Location", "Password" },
                values: new object[,]
                {
                    { 1, "+201112223344", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Mohamed", "Male", "https://example.com/patient1/id-card.jpg", "Hassan", "Cairo", "" },
                    { 2, "+201122334455", new DateTime(1990, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Aisha", "Female", "https://example.com/patient2/id-card.jpg", "Mahmoud", "Alexandria", "" }
                });
        }
    }
}
