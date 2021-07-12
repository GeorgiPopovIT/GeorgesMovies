using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeorgesMovies.Models.Migrations
{
    public partial class RefactorColumnInMovieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRelease",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "CountryRelease",
                table: "Movies",
                newName: "ReleaseInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseInfo",
                table: "Movies",
                newName: "CountryRelease");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRelease",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
