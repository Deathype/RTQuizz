using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class v03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "QuizzId",
                table: "Question",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizzId",
                table: "Question",
                column: "QuizzId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quizz_QuizzId",
                table: "Question",
                column: "QuizzId",
                principalTable: "Quizz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quizz_QuizzId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_QuizzId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuizzId",
                table: "Question");

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Question",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
