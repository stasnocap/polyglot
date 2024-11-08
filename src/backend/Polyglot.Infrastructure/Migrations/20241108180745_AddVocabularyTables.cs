using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Polyglot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVocabularyTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adjectives",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adjectives", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adverbs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adverbs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "comparison_adjectives",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    comparative_form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    superlative_form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comparison_adjectives", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "compounds",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_compounds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "determiners",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_determiners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "letter_numbers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_letter_numbers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "modal_verbs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    full_negative_form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    short_negative_form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_modal_verbs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nouns",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    plural_form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_nouns", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "prepositions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_prepositions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "primary_verbs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    past_form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    past_participle_form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    present_participle_form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    third_person_form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_primary_verbs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pronouns",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pronouns", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "question_words",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_words", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "verbs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    past_form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    past_participle_form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    present_participle_form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    third_person_form = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_irregular_verb = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_verbs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "additional_forms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    primary_verb_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_additional_forms", x => x.id);
                    table.ForeignKey(
                        name: "fk_additional_forms_primary_verbs_primary_verb_id",
                        column: x => x.primary_verb_id,
                        principalTable: "primary_verbs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "full_negative_forms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    primary_verb_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_full_negative_forms", x => x.id);
                    table.ForeignKey(
                        name: "fk_full_negative_forms_primary_verbs_primary_verb_id",
                        column: x => x.primary_verb_id,
                        principalTable: "primary_verbs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "short_negative_forms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    primary_verb_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_short_negative_forms", x => x.id);
                    table.ForeignKey(
                        name: "fk_short_negative_forms_primary_verbs_primary_verb_id",
                        column: x => x.primary_verb_id,
                        principalTable: "primary_verbs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_additional_forms_primary_verb_id",
                table: "additional_forms",
                column: "primary_verb_id");

            migrationBuilder.CreateIndex(
                name: "ix_full_negative_forms_primary_verb_id",
                table: "full_negative_forms",
                column: "primary_verb_id");

            migrationBuilder.CreateIndex(
                name: "ix_short_negative_forms_primary_verb_id",
                table: "short_negative_forms",
                column: "primary_verb_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "additional_forms");

            migrationBuilder.DropTable(
                name: "adjectives");

            migrationBuilder.DropTable(
                name: "adverbs");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "comparison_adjectives");

            migrationBuilder.DropTable(
                name: "compounds");

            migrationBuilder.DropTable(
                name: "determiners");

            migrationBuilder.DropTable(
                name: "full_negative_forms");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "letter_numbers");

            migrationBuilder.DropTable(
                name: "modal_verbs");

            migrationBuilder.DropTable(
                name: "nouns");

            migrationBuilder.DropTable(
                name: "prepositions");

            migrationBuilder.DropTable(
                name: "pronouns");

            migrationBuilder.DropTable(
                name: "question_words");

            migrationBuilder.DropTable(
                name: "short_negative_forms");

            migrationBuilder.DropTable(
                name: "verbs");

            migrationBuilder.DropTable(
                name: "primary_verbs");
        }
    }
}
