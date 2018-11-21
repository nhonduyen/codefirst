using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace school.Migrations
{
    public partial class CreateSchoolDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                table: "Students",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DOB",
                table: "Students",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }
    }
}
