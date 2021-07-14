using Microsoft.EntityFrameworkCore.Migrations;

namespace Bougle.French.Glaff.Storage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OldFashioned = table.Column<bool>(type: "INTEGER", nullable: false),
                    GraphicalForm = table.Column<string>(type: "TEXT", nullable: true),
                    MorphoSyntax = table.Column<string>(type: "TEXT", nullable: true),
                    Lemma = table.Column<string>(type: "TEXT", nullable: true),
                    ApiPronunciations = table.Column<string>(type: "TEXT", nullable: true),
                    SampaPronunciations = table.Column<string>(type: "TEXT", nullable: true),
                    FrantexAbsoluteFormFrequency = table.Column<double>(type: "REAL", nullable: false),
                    FrantexRelativeFormFrequency = table.Column<double>(type: "REAL", nullable: false),
                    FrantexAbsoluteLemmaFrequency = table.Column<double>(type: "REAL", nullable: false),
                    FrantexRelativeLemmaFrequency = table.Column<double>(type: "REAL", nullable: false),
                    LM10AbsoluteFormFrequency = table.Column<double>(type: "REAL", nullable: false),
                    LM10RelativeFormFrequency = table.Column<double>(type: "REAL", nullable: false),
                    LM10AbsoluteLemmaFrequency = table.Column<double>(type: "REAL", nullable: false),
                    LM10RelativeLemmaFrequency = table.Column<double>(type: "REAL", nullable: false),
                    FrWacAbsoluteFormFrequency = table.Column<double>(type: "REAL", nullable: false),
                    FrWacRelativeFormFrequency = table.Column<double>(type: "REAL", nullable: false),
                    FrWacAbsoluteLemmaFrequency = table.Column<double>(type: "REAL", nullable: false),
                    FrWacRelativeLemmaFrequency = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
