using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polyglot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeLessonAndExerciseHaveManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_exercises_lessons_lesson_id",
                table: "exercises");

            migrationBuilder.DropIndex(
                name: "ix_exercises_lesson_id",
                table: "exercises");

            migrationBuilder.DropColumn(
                name: "lesson_id",
                table: "exercises");

            migrationBuilder.CreateTable(
                name: "lesson_exercises",
                columns: table => new
                {
                    lesson_id = table.Column<int>(type: "integer", nullable: false),
                    exercise_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lesson_exercises", x => new { x.lesson_id, x.exercise_id });
                    table.ForeignKey(
                        name: "fk_lesson_exercises_exercises_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lesson_exercises_lessons_lesson_id",
                        column: x => x.lesson_id,
                        principalTable: "lessons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_lesson_exercises_exercise_id",
                table: "lesson_exercises",
                column: "exercise_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lesson_exercises");

            migrationBuilder.AddColumn<int>(
                name: "lesson_id",
                table: "exercises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_exercises_lesson_id",
                table: "exercises",
                column: "lesson_id");

            migrationBuilder.AddForeignKey(
                name: "fk_exercises_lessons_lesson_id",
                table: "exercises",
                column: "lesson_id",
                principalTable: "lessons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
