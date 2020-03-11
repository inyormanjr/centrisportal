using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrisWebApi.Migrations
{
    public partial class ExtendedInfoForPersonalInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CollegeAttended",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollegeYearGraduated",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContactNumber",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DegreeName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EyeColor",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaceBookUrl",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HighSchoolAttended",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HighSchoolYearGraduated",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "JobAddress",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobDescrtion",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollegeAttended",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CollegeYearGraduated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DegreeName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EyeColor",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FaceBookUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HighSchoolAttended",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HighSchoolYearGraduated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JobAddress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JobDescrtion",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JobName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Users");
        }
    }
}
