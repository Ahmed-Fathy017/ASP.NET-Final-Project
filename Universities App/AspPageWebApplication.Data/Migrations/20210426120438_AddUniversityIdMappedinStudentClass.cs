using Microsoft.EntityFrameworkCore.Migrations;

namespace AspPageWebApplication.Data.Migrations
{
    public partial class AddUniversityIdMappedinStudentClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Universities_UniversityId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Universities_UniversityId",
                table: "Students",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Universities_UniversityId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Universities_UniversityId",
                table: "Students",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
