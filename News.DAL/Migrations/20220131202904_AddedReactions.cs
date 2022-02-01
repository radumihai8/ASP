using Microsoft.EntityFrameworkCore.Migrations;

namespace News.DAL.Migrations
{
    public partial class AddedReactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleReaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReactionId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleReaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleReaction_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleReaction_Reaction_ReactionId",
                        column: x => x.ReactionId,
                        principalTable: "Reaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleReaction_ArticleId",
                table: "ArticleReaction",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleReaction_ReactionId",
                table: "ArticleReaction",
                column: "ReactionId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "ArticleReaction");

            migrationBuilder.DropTable(
                name: "Reaction");

        }
    }
}
