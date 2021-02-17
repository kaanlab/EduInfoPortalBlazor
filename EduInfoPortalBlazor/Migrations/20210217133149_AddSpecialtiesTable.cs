using Microsoft.EntityFrameworkCore.Migrations;

namespace EduInfoPortalBlazor.Migrations
{
    public partial class AddSpecialtiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamSpecialty_Specialty_SpecialtiesId",
                table: "ExamSpecialty");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionSpecialty_Specialty_SpecialtiesId",
                table: "ProfessionSpecialty");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_Faculties_FacultyId",
                table: "Specialty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty");

            migrationBuilder.RenameTable(
                name: "Specialty",
                newName: "Specialties");

            migrationBuilder.RenameIndex(
                name: "IX_Specialty_FacultyId",
                table: "Specialties",
                newName: "IX_Specialties_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSpecialty_Specialties_SpecialtiesId",
                table: "ExamSpecialty",
                column: "SpecialtiesId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionSpecialty_Specialties_SpecialtiesId",
                table: "ProfessionSpecialty",
                column: "SpecialtiesId",
                principalTable: "Specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialties_Faculties_FacultyId",
                table: "Specialties",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamSpecialty_Specialties_SpecialtiesId",
                table: "ExamSpecialty");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionSpecialty_Specialties_SpecialtiesId",
                table: "ProfessionSpecialty");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialties_Faculties_FacultyId",
                table: "Specialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties");

            migrationBuilder.RenameTable(
                name: "Specialties",
                newName: "Specialty");

            migrationBuilder.RenameIndex(
                name: "IX_Specialties_FacultyId",
                table: "Specialty",
                newName: "IX_Specialty_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSpecialty_Specialty_SpecialtiesId",
                table: "ExamSpecialty",
                column: "SpecialtiesId",
                principalTable: "Specialty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionSpecialty_Specialty_SpecialtiesId",
                table: "ProfessionSpecialty",
                column: "SpecialtiesId",
                principalTable: "Specialty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_Faculties_FacultyId",
                table: "Specialty",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
