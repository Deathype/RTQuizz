using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quizz_QuizzId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizz_Stagiaire_StagiaireId",
                table: "Quizz");

            migrationBuilder.DropIndex(
                name: "IX_Quizz_StagiaireId",
                table: "Quizz");

            migrationBuilder.DropIndex(
                name: "IX_Question_QuizzId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "StagiaireId",
                table: "Quizz");

            migrationBuilder.DropColumn(
                name: "QuizzId",
                table: "Question");

            migrationBuilder.CreateTable(
                name: "QuizzStagiaire",
                columns: table => new
                {
                    QuizzId = table.Column<int>(nullable: false),
                    StagiaireId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizzStagiaire", x => new { x.QuizzId, x.StagiaireId });
                    table.ForeignKey(
                        name: "FK_QuizzStagiaire_Quizz_QuizzId",
                        column: x => x.QuizzId,
                        principalTable: "Quizz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizzStagiaire_Stagiaire_StagiaireId",
                        column: x => x.StagiaireId,
                        principalTable: "Stagiaire",
                        principalColumn: "StagiaireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizzStagiaire_StagiaireId",
                table: "QuizzStagiaire",
                column: "StagiaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizzStagiaire");

            migrationBuilder.AddColumn<int>(
                name: "StagiaireId",
                table: "Quizz",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuizzId",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quizz_StagiaireId",
                table: "Quizz",
                column: "StagiaireId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Quizz_Stagiaire_StagiaireId",
                table: "Quizz",
                column: "StagiaireId",
                principalTable: "Stagiaire",
                principalColumn: "StagiaireId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
