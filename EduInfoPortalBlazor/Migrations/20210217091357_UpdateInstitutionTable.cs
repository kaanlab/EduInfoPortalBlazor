using Microsoft.EntityFrameworkCore.Migrations;

namespace EduInfoPortalBlazor.Migrations
{
    public partial class UpdateInstitutionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Cities_CityId",
                table: "Institutions");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Institutions",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Cities_CityId",
                table: "Institutions",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Cities_CityId",
                table: "Institutions");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Institutions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Cities_CityId",
                table: "Institutions",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
