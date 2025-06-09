using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediMed.Migrations
{
    /// <inheritdoc />
    public partial class nursepatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NursePatients",
                table: "NursePatients");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "NursePatients",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "NursePatients",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "NursePatients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NursePatients",
                table: "NursePatients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NursePatients_NurseId",
                table: "NursePatients",
                column: "NurseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NursePatients",
                table: "NursePatients");

            migrationBuilder.DropIndex(
                name: "IX_NursePatients_NurseId",
                table: "NursePatients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "NursePatients");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "NursePatients");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "NursePatients",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NursePatients",
                table: "NursePatients",
                columns: new[] { "NurseId", "PatientId" });
        }
    }
}
