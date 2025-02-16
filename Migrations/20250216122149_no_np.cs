using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediMed.Migrations
{
    /// <inheritdoc />
    public partial class no_np : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NursePatients",
                table: "NursePatients");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "NursePatients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NursePatients",
                table: "NursePatients",
                columns: new[] { "NurseId", "PatientId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NursePatients",
                table: "NursePatients");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "NursePatients",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NursePatients",
                table: "NursePatients",
                columns: new[] { "NurseId", "PatientId", "Status" });
        }
    }
}
