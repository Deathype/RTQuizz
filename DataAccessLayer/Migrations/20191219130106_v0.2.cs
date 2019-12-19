using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class v02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repondre",
                columns: table => new
                {
                    StagiaireId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    ReponsesId = table.Column<int>(nullable: false),
                    RepStagiaire = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repondre", x => new { x.StagiaireId, x.ReponsesId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_Repondre_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repondre_Reponses_ReponsesId",
                        column: x => x.ReponsesId,
                        principalTable: "Reponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repondre_Stagiaire_StagiaireId",
                        column: x => x.StagiaireId,
                        principalTable: "Stagiaire",
                        principalColumn: "StagiaireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repondre_QuestionId",
                table: "Repondre",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Repondre_ReponsesId",
                table: "Repondre",
                column: "ReponsesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repondre");
        }
    }
}
