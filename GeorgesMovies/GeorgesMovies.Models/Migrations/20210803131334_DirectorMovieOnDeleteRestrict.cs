using Microsoft.EntityFrameworkCore.Migrations;

namespace GeorgesMovies.Models.Migrations
{
    public partial class DirectorMovieOnDeleteRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectorMovie_Directors_DirectorsId",
                table: "DirectorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectorMovie_Movies_MoviesId",
                table: "DirectorMovie");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorMovie_Directors_DirectorsId",
                table: "DirectorMovie",
                column: "DirectorsId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorMovie_Movies_MoviesId",
                table: "DirectorMovie",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectorMovie_Directors_DirectorsId",
                table: "DirectorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectorMovie_Movies_MoviesId",
                table: "DirectorMovie");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorMovie_Directors_DirectorsId",
                table: "DirectorMovie",
                column: "DirectorsId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorMovie_Movies_MoviesId",
                table: "DirectorMovie",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
