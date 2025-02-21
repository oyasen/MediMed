using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediMed.Migrations
{
    /// <inheritdoc />
    public partial class pat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Approved",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalPicture",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Nurses",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalPicture",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PersonalPicture",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "PersonalPicture",
                table: "Nurses");
        }
    }
}
