using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediMed.Migrations
{
    /// <inheritdoc />
    public partial class rel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "NursePatients",
                columns: table => new
                {
                    NurseId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursePatients", x => new { x.NurseId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_NursePatients_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NursePatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Nurses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Password" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Password" },
                values: new object[] { "", "" });

            migrationBuilder.CreateIndex(
                name: "IX_NursePatients_PatientId",
                table: "NursePatients",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NursePatients");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Nurses");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
