using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediMed.Migrations
{
    /// <inheritdoc />
    public partial class meg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "NursePatients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "NursePatients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "NursePatients");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "NursePatients");
        }
    }
}
