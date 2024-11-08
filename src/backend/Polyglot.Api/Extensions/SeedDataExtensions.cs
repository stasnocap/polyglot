using System.Data;
using Dapper;
using Polyglot.Application.Abstractions.Data;
using Polyglot.Domain.Lessons.Exercises;

namespace Polyglot.Api.Extensions;

internal static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ISqlConnectionFactory sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using IDbConnection connection = sqlConnectionFactory.CreateConnection();

        object[] lessons = GetLessons();
        object[] exercises = GetExercises();
        object[] lessonExercises = GetLessonExercises();
        object[] words = GetWords();

        const string lessonsSql = """
                                  INSERT INTO public.lessons (id, name)
                                  VALUES (@Id, @Name);
                                  """;

        const string exercisesSql = """
                                    INSERT INTO public.exercises (id, rus_phrase)
                                    VALUES (@Id, @RusPhrase);
                                    """;

        const string lessonExercisesSql = """
                                          INSERT INTO public.lesson_exercises (lesson_id, exercise_id)
                                          VALUES (@LessonId, @ExerciseId);
                                          """;

        const string wordsSql = """
                                INSERT INTO public.words (number, text, type, exercise_id)
                                VALUES (@Number, @Text, @Type, @ExerciseId);
                                """;

        connection.Execute(lessonsSql, lessons);
        connection.Execute(exercisesSql, exercises);
        connection.Execute(lessonExercisesSql, lessonExercises);
        connection.Execute(wordsSql, words);
    }

    private static object[] GetWords()
    {
        object[] words =
        [
            #region Lesson 1

            new { Number = 1, Text = "You", Type = WordType.Pronoun, ExerciseId = 1 },
            new { Number = 2, Text = "will not", Type = WordType.ModalVerb, ExerciseId = 1 },
            new { Number = 3, Text = "see.", Type = WordType.Verb, ExerciseId = 1 },

            new { Number = 1, Text = "Will", Type = WordType.ModalVerb, ExerciseId = 2 },
            new { Number = 2, Text = "we", Type = WordType.Pronoun, ExerciseId = 2 },
            new { Number = 3, Text = "show?", Type = WordType.Verb, ExerciseId = 2 },

            new { Number = 1, Text = "She", Type = WordType.Pronoun, ExerciseId = 3 },
            new { Number = 2, Text = "worked?", Type = WordType.Verb, ExerciseId = 3 },

            new { Number = 1, Text = "You", Type = WordType.Pronoun, ExerciseId = 4 },
            new { Number = 2, Text = "didn't", Type = WordType.PrimaryVerb, ExerciseId = 4 },
            new { Number = 3, Text = "think.", Type = WordType.Verb, ExerciseId = 4 },

            new { Number = 1, Text = "Will", Type = WordType.ModalVerb, ExerciseId = 5 },
            new { Number = 2, Text = "I", Type = WordType.Pronoun, ExerciseId = 5 },
            new { Number = 3, Text = "look?", Type = WordType.Verb, ExerciseId = 5 },

            #endregion

            #region Lesson 2

            new { Number = 1, Text = "We", Type = WordType.Pronoun, ExerciseId = 6 },
            new { Number = 2, Text = "didn't", Type = WordType.PrimaryVerb, ExerciseId = 6 },
            new { Number = 3, Text = "leave", Type = WordType.Verb, ExerciseId = 6 },
            new { Number = 4, Text = "him.", Type = WordType.Pronoun, ExerciseId = 6 },

            new { Number = 1, Text = "He", Type = WordType.Pronoun, ExerciseId = 7 },
            new { Number = 2, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 7 },
            new { Number = 3, Text = "understand", Type = WordType.Verb, ExerciseId = 7 },
            new { Number = 4, Text = "you.", Type = WordType.Pronoun, ExerciseId = 7 },

            new { Number = 1, Text = "You", Type = WordType.Pronoun, ExerciseId = 8 },
            new { Number = 2, Text = "open", Type = WordType.Verb, ExerciseId = 8 },
            new { Number = 3, Text = "her.", Type = WordType.Pronoun, ExerciseId = 8 },

            new { Number = 1, Text = "Will", Type = WordType.PrimaryVerb, ExerciseId = 9 },
            new { Number = 2, Text = "i", Type = WordType.Pronoun, ExerciseId = 9 },
            new { Number = 3, Text = "break?", Type = WordType.Verb, ExerciseId = 9 },

            new { Number = 1, Text = "Did", Type = WordType.PrimaryVerb, ExerciseId = 10 },
            new { Number = 2, Text = "i", Type = WordType.Pronoun, ExerciseId = 10 },
            new { Number = 3, Text = "show", Type = WordType.Verb, ExerciseId = 10 },
            new { Number = 4, Text = "them?", Type = WordType.Pronoun, ExerciseId = 10 },

            #endregion

            #region Lesson 3

            new { Number = 1, Text = "Do", Type = WordType.PrimaryVerb, ExerciseId = 11 },
            new { Number = 2, Text = "you", Type = WordType.Pronoun, ExerciseId = 11 },
            new { Number = 3, Text = "want", Type = WordType.Verb, ExerciseId = 11 },
            new { Number = 4, Text = "to", Type = WordType.Preposition, ExerciseId = 11 },
            new { Number = 5, Text = "drink?", Type = WordType.Verb, ExerciseId = 11 },

            new { Number = 1, Text = "Did", Type = WordType.PrimaryVerb, ExerciseId = 12 },
            new { Number = 2, Text = "she", Type = WordType.Pronoun, ExerciseId = 12 },
            new { Number = 3, Text = "want", Type = WordType.Verb, ExerciseId = 12 },
            new { Number = 4, Text = "to", Type = WordType.Preposition, ExerciseId = 12 },
            new { Number = 5, Text = "forget?", Type = WordType.Verb, ExerciseId = 12 },

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 13 },
            new { Number = 2, Text = "was", Type = WordType.PrimaryVerb, ExerciseId = 13 },
            new { Number = 3, Text = "at", Type = WordType.Preposition, ExerciseId = 13 },
            new { Number = 4, Text = "the", Type = WordType.Determiner, ExerciseId = 13 },
            new { Number = 5, Text = "museum.", Type = WordType.Noun, ExerciseId = 13 },

            new { Number = 1, Text = "She", Type = WordType.Pronoun, ExerciseId = 14 },
            new { Number = 2, Text = "didn't", Type = WordType.PrimaryVerb, ExerciseId = 14 },
            new { Number = 3, Text = "like", Type = WordType.Verb, ExerciseId = 14 },
            new { Number = 4, Text = "to", Type = WordType.Preposition, ExerciseId = 14 },
            new { Number = 5, Text = "show.", Type = WordType.Verb, ExerciseId = 14 },

            new { Number = 1, Text = "Is", Type = WordType.PrimaryVerb, ExerciseId = 15 },
            new { Number = 2, Text = "she", Type = WordType.Pronoun, ExerciseId = 15 },
            new { Number = 3, Text = "in", Type = WordType.Preposition, ExerciseId = 15 },
            new { Number = 4, Text = "the", Type = WordType.Determiner, ExerciseId = 15 },
            new { Number = 5, Text = "elevator?", Type = WordType.Noun, ExerciseId = 15 },

            #endregion

            #region Lesson 4

            new { Number = 1, Text = "Will", Type = WordType.PrimaryVerb, ExerciseId = 16 },
            new { Number = 2, Text = "he", Type = WordType.Pronoun, ExerciseId = 16 },
            new { Number = 3, Text = "be", Type = WordType.PrimaryVerb, ExerciseId = 16 },
            new { Number = 4, Text = "their", Type = WordType.Pronoun, ExerciseId = 16 },
            new { Number = 5, Text = "actor?", Type = WordType.Noun, ExerciseId = 16 },

            new { Number = 1, Text = "We", Type = WordType.Pronoun, ExerciseId = 17 },
            new { Number = 2, Text = "are not", Type = WordType.PrimaryVerb, ExerciseId = 17 },
            new { Number = 3, Text = "their", Type = WordType.Pronoun, ExerciseId = 17 },
            new { Number = 4, Text = "accountants.", Type = WordType.Noun, ExerciseId = 17 },

            new { Number = 1, Text = "We", Type = WordType.Pronoun, ExerciseId = 18 },
            new { Number = 2, Text = "were", Type = WordType.PrimaryVerb, ExerciseId = 18 },
            new { Number = 3, Text = "his", Type = WordType.Pronoun, ExerciseId = 18 },
            new { Number = 4, Text = "historians.", Type = WordType.Noun, ExerciseId = 18 },

            new { Number = 1, Text = "He", Type = WordType.Pronoun, ExerciseId = 19 },
            new { Number = 2, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 19 },
            new { Number = 3, Text = "be", Type = WordType.PrimaryVerb, ExerciseId = 19 },
            new { Number = 4, Text = "her", Type = WordType.Pronoun, ExerciseId = 19 },
            new { Number = 5, Text = "writer.", Type = WordType.Noun, ExerciseId = 19 },

            new { Number = 1, Text = "We", Type = WordType.Pronoun, ExerciseId = 20 },
            new { Number = 2, Text = "will not", Type = WordType.PrimaryVerb, ExerciseId = 20 },
            new { Number = 3, Text = "be", Type = WordType.PrimaryVerb, ExerciseId = 20 },
            new { Number = 4, Text = "their", Type = WordType.Pronoun, ExerciseId = 20 },
            new { Number = 5, Text = "guides.", Type = WordType.Noun, ExerciseId = 20 },

            #endregion

            #region Lesson 5

            new { Number = 1, Text = "Do", Type = WordType.PrimaryVerb, ExerciseId = 21 },
            new { Number = 2, Text = "they", Type = WordType.Pronoun, ExerciseId = 21 },
            new { Number = 3, Text = "study", Type = WordType.Verb, ExerciseId = 21 },
            new { Number = 4, Text = "to", Type = WordType.Preposition, ExerciseId = 21 },
            new { Number = 5, Text = "be", Type = WordType.PrimaryVerb, ExerciseId = 21 },
            new { Number = 6, Text = "guides?", Type = WordType.Noun, ExerciseId = 21 },

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 22 },
            new { Number = 2, Text = "will not", Type = WordType.PrimaryVerb, ExerciseId = 22 },
            new { Number = 3, Text = "be", Type = WordType.PrimaryVerb, ExerciseId = 22 },
            new { Number = 4, Text = "a", Type = WordType.Determiner, ExerciseId = 22 },
            new { Number = 5, Text = "manager.", Type = WordType.Noun, ExerciseId = 22 },

            new { Number = 1, Text = "We", Type = WordType.Pronoun, ExerciseId = 23 },
            new { Number = 2, Text = "studied", Type = WordType.Verb, ExerciseId = 23 },
            new { Number = 3, Text = "to", Type = WordType.Preposition, ExerciseId = 23 },
            new { Number = 4, Text = "be", Type = WordType.PrimaryVerb, ExerciseId = 23 },
            new { Number = 5, Text = "managers.", Type = WordType.Noun, ExerciseId = 23 },

            new { Number = 1, Text = "Did", Type = WordType.PrimaryVerb, ExerciseId = 24 },
            new { Number = 2, Text = "they", Type = WordType.Pronoun, ExerciseId = 24 },
            new { Number = 3, Text = "work", Type = WordType.Verb, ExerciseId = 24 },
            new { Number = 4, Text = "in", Type = WordType.Preposition, ExerciseId = 24 },
            new { Number = 5, Text = "a", Type = WordType.Determiner, ExerciseId = 24 },
            new { Number = 6, Text = "company", Type = WordType.Noun, ExerciseId = 24 },
            new { Number = 7, Text = "as", Type = WordType.Preposition, ExerciseId = 24 },
            new { Number = 8, Text = "designers?", Type = WordType.Noun, ExerciseId = 24 },

            new { Number = 1, Text = "You", Type = WordType.Pronoun, ExerciseId = 25 },
            new { Number = 2, Text = "are", Type = WordType.PrimaryVerb, ExerciseId = 25 },
            new { Number = 3, Text = "a", Type = WordType.Determiner, ExerciseId = 25 },
            new { Number = 4, Text = "historian.", Type = WordType.Noun, ExerciseId = 25 },

            #endregion

            #region Lesson 6

            new { Number = 1, Text = "This", Type = WordType.Pronoun, ExerciseId = 26 },
            new { Number = 2, Text = "pen", Type = WordType.Noun, ExerciseId = 26 },
            new { Number = 3, Text = "is not", Type = WordType.PrimaryVerb, ExerciseId = 26 },
            new { Number = 4, Text = "bigger", Type = WordType.ComparisonAdjective, ExerciseId = 26 },
            new { Number = 5, Text = "than", Type = WordType.Preposition, ExerciseId = 26 },
            new { Number = 6, Text = "that", Type = WordType.Pronoun, ExerciseId = 26 },
            new { Number = 7, Text = "one.", Type = WordType.Noun, ExerciseId = 26 },

            new { Number = 1, Text = "This", Type = WordType.Pronoun, ExerciseId = 27 },
            new { Number = 2, Text = "tv", Type = WordType.Noun, ExerciseId = 27 },
            new { Number = 3, Text = "is not", Type = WordType.PrimaryVerb, ExerciseId = 27 },
            new { Number = 4, Text = "expensive.", Type = WordType.ComparisonAdjective, ExerciseId = 27 },

            new { Number = 1, Text = "Is", Type = WordType.PrimaryVerb, ExerciseId = 28 },
            new { Number = 2, Text = "this", Type = WordType.Pronoun, ExerciseId = 28 },
            new { Number = 3, Text = "phone", Type = WordType.Noun, ExerciseId = 28 },
            new { Number = 4, Text = "cheaper", Type = WordType.ComparisonAdjective, ExerciseId = 28 },
            new { Number = 5, Text = "than", Type = WordType.Preposition, ExerciseId = 28 },
            new { Number = 6, Text = "that", Type = WordType.Pronoun, ExerciseId = 28 },
            new { Number = 7, Text = "one?", Type = WordType.Noun, ExerciseId = 28 },

            new { Number = 1, Text = "This", Type = WordType.Pronoun, ExerciseId = 29 },
            new { Number = 2, Text = "pen", Type = WordType.Noun, ExerciseId = 29 },
            new { Number = 3, Text = "is", Type = WordType.PrimaryVerb, ExerciseId = 29 },
            new { Number = 4, Text = "longer", Type = WordType.ComparisonAdjective, ExerciseId = 29 },
            new { Number = 5, Text = "than", Type = WordType.Preposition, ExerciseId = 29 },
            new { Number = 6, Text = "that", Type = WordType.Pronoun, ExerciseId = 29 },
            new { Number = 7, Text = "one.", Type = WordType.Noun, ExerciseId = 29 },

            new { Number = 1, Text = "Are", Type = WordType.PrimaryVerb, ExerciseId = 30 },
            new { Number = 2, Text = "these", Type = WordType.Pronoun, ExerciseId = 30 },
            new { Number = 3, Text = "oranges", Type = WordType.Noun, ExerciseId = 30 },
            new { Number = 4, Text = "the", Type = WordType.Determiner, ExerciseId = 30 },
            new { Number = 5, Text = "least?", Type = WordType.ComparisonAdjective, ExerciseId = 30 },

            #endregion

            #region Lesson 7

            new { Number = 1, Text = "We", Type = WordType.Pronoun, ExerciseId = 31 },
            new { Number = 2, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 31 },
            new { Number = 3, Text = "read", Type = WordType.Verb, ExerciseId = 31 },
            new { Number = 4, Text = "somebody.", Type = WordType.Compound, ExerciseId = 31 },

            new { Number = 1, Text = "Do", Type = WordType.PrimaryVerb, ExerciseId = 32 },
            new { Number = 2, Text = "they", Type = WordType.Pronoun, ExerciseId = 32 },
            new { Number = 3, Text = "feel", Type = WordType.Verb, ExerciseId = 32 },
            new { Number = 4, Text = "everywhere?", Type = WordType.Compound, ExerciseId = 32 },

            new { Number = 1, Text = "Do", Type = WordType.PrimaryVerb, ExerciseId = 33 },
            new { Number = 2, Text = "you", Type = WordType.Pronoun, ExerciseId = 33 },
            new { Number = 3, Text = "meet", Type = WordType.Verb, ExerciseId = 33 },
            new { Number = 4, Text = "everywhere?", Type = WordType.Compound, ExerciseId = 33 },

            new { Number = 1, Text = "Will", Type = WordType.PrimaryVerb, ExerciseId = 34 },
            new { Number = 2, Text = "he", Type = WordType.Pronoun, ExerciseId = 34 },
            new { Number = 3, Text = "know", Type = WordType.Verb, ExerciseId = 34 },
            new { Number = 4, Text = "everybody?", Type = WordType.Compound, ExerciseId = 34 },

            new { Number = 1, Text = "He", Type = WordType.Pronoun, ExerciseId = 35 },
            new { Number = 2, Text = "never", Type = WordType.Adverb, ExerciseId = 35 },
            new { Number = 3, Text = "sees.", Type = WordType.Verb, ExerciseId = 35 },

            #endregion

            #region Lesson 8

            new { Number = 1, Text = "She", Type = WordType.Pronoun, ExerciseId = 36 },
            new { Number = 2, Text = "didn't", Type = WordType.PrimaryVerb, ExerciseId = 36 },
            new { Number = 3, Text = "turn", Type = WordType.Verb, ExerciseId = 36 },
            new { Number = 4, Text = "us", Type = WordType.Pronoun, ExerciseId = 36 },
            new { Number = 5, Text = "six", Type = WordType.LetterNumber, ExerciseId = 36 },
            new { Number = 6, Text = "months", Type = WordType.Noun, ExerciseId = 36 },
            new { Number = 7, Text = "ago.", Type = WordType.Preposition, ExerciseId = 36 },

            new { Number = 1, Text = "Will", Type = WordType.PrimaryVerb, ExerciseId = 37 },
            new { Number = 2, Text = "he", Type = WordType.Pronoun, ExerciseId = 37 },
            new { Number = 3, Text = "grow", Type = WordType.Verb, ExerciseId = 37 },
            new { Number = 4, Text = "in", Type = WordType.Preposition, ExerciseId = 37 },
            new { Number = 5, Text = "2 months?", Type = WordType.NumberWithNoun, ExerciseId = 37 },

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 38 },
            new { Number = 2, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 38 },
            new { Number = 3, Text = "tell", Type = WordType.Verb, ExerciseId = 38 },
            new { Number = 4, Text = "you", Type = WordType.Pronoun, ExerciseId = 38 },
            new { Number = 5, Text = "in", Type = WordType.Preposition, ExerciseId = 38 },
            new { Number = 6, Text = "6 months.", Type = WordType.NumberWithNoun, ExerciseId = 38 },

            new { Number = 1, Text = "Will", Type = WordType.PrimaryVerb, ExerciseId = 39 },
            new { Number = 2, Text = "you", Type = WordType.Pronoun, ExerciseId = 39 },
            new { Number = 3, Text = "be", Type = WordType.PrimaryVerb, ExerciseId = 39 },
            new { Number = 4, Text = "there", Type = WordType.Adverb, ExerciseId = 39 },
            new { Number = 5, Text = "in", Type = WordType.Preposition, ExerciseId = 39 },
            new { Number = 6, Text = "6 months?", Type = WordType.NumberWithNoun, ExerciseId = 39 },

            new { Number = 1, Text = "Did", Type = WordType.PrimaryVerb, ExerciseId = 40 },
            new { Number = 2, Text = "she", Type = WordType.Pronoun, ExerciseId = 40 },
            new { Number = 3, Text = "love", Type = WordType.Verb, ExerciseId = 40 },
            new { Number = 4, Text = "them", Type = WordType.Pronoun, ExerciseId = 40 },
            new { Number = 5, Text = "at", Type = WordType.Preposition, ExerciseId = 40 },
            new { Number = 6, Text = "the", Type = WordType.Determiner, ExerciseId = 40 },
            new { Number = 7, Text = "weekend?", Type = WordType.Noun, ExerciseId = 40 },

            #endregion

            #region Lesson9

            new { Number = 1, Text = "There", Type = WordType.Adverb, ExerciseId = 41 },
            new { Number = 2, Text = "were not", Type = WordType.PrimaryVerb, ExerciseId = 41 },
            new { Number = 3, Text = "pens", Type = WordType.Noun, ExerciseId = 41 },
            new { Number = 4, Text = "on", Type = WordType.Preposition, ExerciseId = 41 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 41 },
            new { Number = 6, Text = "floor.", Type = WordType.Noun, ExerciseId = 41 },

            new { Number = 1, Text = "There", Type = WordType.Adverb, ExerciseId = 42 },
            new { Number = 2, Text = "are", Type = WordType.PrimaryVerb, ExerciseId = 42 },
            new { Number = 3, Text = "knives", Type = WordType.Noun, ExerciseId = 42 },
            new { Number = 4, Text = "under", Type = WordType.Preposition, ExerciseId = 42 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 42 },
            new { Number = 6, Text = "table.", Type = WordType.Noun, ExerciseId = 42 },

            new { Number = 1, Text = "There", Type = WordType.Adverb, ExerciseId = 43 },
            new { Number = 2, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 43 },
            new { Number = 3, Text = "be", Type = WordType.PrimaryVerb, ExerciseId = 43 },
            new { Number = 4, Text = "a", Type = WordType.Determiner, ExerciseId = 43 },
            new { Number = 5, Text = "ball", Type = WordType.Noun, ExerciseId = 43 },
            new { Number = 6, Text = "under", Type = WordType.Preposition, ExerciseId = 43 },
            new { Number = 7, Text = "the", Type = WordType.Determiner, ExerciseId = 43 },
            new { Number = 8, Text = "armchair.", Type = WordType.Noun, ExerciseId = 43 },

            new { Number = 1, Text = "There", Type = WordType.Adverb, ExerciseId = 44 },
            new { Number = 2, Text = "isn't", Type = WordType.PrimaryVerb, ExerciseId = 44 },
            new { Number = 3, Text = "a", Type = WordType.Determiner, ExerciseId = 44 },
            new { Number = 4, Text = "pen", Type = WordType.Noun, ExerciseId = 44 },
            new { Number = 5, Text = "on", Type = WordType.Preposition, ExerciseId = 44 },
            new { Number = 6, Text = "the", Type = WordType.Determiner, ExerciseId = 44 },
            new { Number = 7, Text = "table.", Type = WordType.Noun, ExerciseId = 44 },

            new { Number = 1, Text = "Was", Type = WordType.PrimaryVerb, ExerciseId = 45 },
            new { Number = 2, Text = "there", Type = WordType.Adverb, ExerciseId = 45 },
            new { Number = 3, Text = "a", Type = WordType.Determiner, ExerciseId = 45 },
            new { Number = 4, Text = "glass", Type = WordType.Noun, ExerciseId = 45 },
            new { Number = 5, Text = "under", Type = WordType.Preposition, ExerciseId = 45 },
            new { Number = 6, Text = "the", Type = WordType.Determiner, ExerciseId = 45 },
            new { Number = 7, Text = "armchair?", Type = WordType.Noun, ExerciseId = 45 },

            #endregion

            #region Lesson 10

            new { Number = 1, Text = "Does", Type = WordType.PrimaryVerb, ExerciseId = 46 },
            new { Number = 2, Text = "he", Type = WordType.Pronoun, ExerciseId = 46 },
            new { Number = 3, Text = "go", Type = WordType.Verb, ExerciseId = 46 },
            new { Number = 4, Text = "on", Type = WordType.Preposition, ExerciseId = 46 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 46 },
            new { Number = 6, Text = "station?", Type = WordType.Noun, ExerciseId = 46 },

            new { Number = 1, Text = "You", Type = WordType.Pronoun, ExerciseId = 47 },
            new { Number = 2, Text = "will not", Type = WordType.PrimaryVerb, ExerciseId = 47 },
            new { Number = 3, Text = "out", Type = WordType.Adverb, ExerciseId = 47 },
            new { Number = 4, Text = "of", Type = WordType.Preposition, ExerciseId = 47 },
            new { Number = 5, Text = "from", Type = WordType.Preposition, ExerciseId = 47 },
            new { Number = 6, Text = "the", Type = WordType.Determiner, ExerciseId = 47 },
            new { Number = 7, Text = "garden.", Type = WordType.Noun, ExerciseId = 47 },

            new { Number = 1, Text = "There", Type = WordType.Adverb, ExerciseId = 48 },
            new { Number = 2, Text = "won't", Type = WordType.PrimaryVerb, ExerciseId = 48 },
            new { Number = 3, Text = "be", Type = WordType.PrimaryVerb, ExerciseId = 48 },
            new { Number = 4, Text = "cupboards", Type = WordType.Noun, ExerciseId = 48 },
            new { Number = 5, Text = "in", Type = WordType.Preposition, ExerciseId = 48 },
            new { Number = 6, Text = "the", Type = WordType.Determiner, ExerciseId = 48 },
            new { Number = 7, Text = "room.", Type = WordType.Noun, ExerciseId = 48 },

            new { Number = 1, Text = "There", Type = WordType.Adverb, ExerciseId = 49 },
            new { Number = 2, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 49 },
            new { Number = 3, Text = "be", Type = WordType.PrimaryVerb, ExerciseId = 49 },
            new { Number = 4, Text = "a", Type = WordType.Determiner, ExerciseId = 49 },
            new { Number = 5, Text = "cup", Type = WordType.Noun, ExerciseId = 49 },
            new { Number = 6, Text = "on", Type = WordType.Preposition, ExerciseId = 49 },
            new { Number = 7, Text = "the", Type = WordType.Determiner, ExerciseId = 49 },
            new { Number = 8, Text = "windowsill.", Type = WordType.Noun, ExerciseId = 49 },

            new { Number = 1, Text = "Were", Type = WordType.PrimaryVerb, ExerciseId = 50 },
            new { Number = 2, Text = "there", Type = WordType.Adverb, ExerciseId = 50 },
            new { Number = 3, Text = "glasses", Type = WordType.Noun, ExerciseId = 50 },
            new { Number = 4, Text = "under", Type = WordType.Preposition, ExerciseId = 50 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 50 },
            new { Number = 6, Text = "table?", Type = WordType.Noun, ExerciseId = 50 },

            #endregion

            #region Lesson 11

            new { Number = 1, Text = "We", Type = WordType.Pronoun, ExerciseId = 51 },
            new { Number = 2, Text = "mustn't", Type = WordType.ModalVerb, ExerciseId = 51 },
            new { Number = 3, Text = "feel.", Type = WordType.Verb, ExerciseId = 51 },

            new { Number = 1, Text = "Should", Type = WordType.ModalVerb, ExerciseId = 52 },
            new { Number = 2, Text = "I", Type = WordType.Pronoun, ExerciseId = 52 },
            new { Number = 3, Text = "stand?", Type = WordType.Verb, ExerciseId = 52 },

            new { Number = 1, Text = "We", Type = WordType.Pronoun, ExerciseId = 53 },
            new { Number = 2, Text = "can", Type = WordType.ModalVerb, ExerciseId = 53 },
            new { Number = 3, Text = "close.", Type = WordType.Verb, ExerciseId = 53 },

            new { Number = 1, Text = "We", Type = WordType.Pronoun, ExerciseId = 54 },
            new { Number = 2, Text = "didn't", Type = WordType.PrimaryVerb, ExerciseId = 54 },
            new { Number = 3, Text = "show.", Type = WordType.Verb, ExerciseId = 54 },

            new { Number = 1, Text = "She", Type = WordType.Pronoun, ExerciseId = 55 },
            new { Number = 2, Text = "must not", Type = WordType.ModalVerb, ExerciseId = 55 },
            new { Number = 3, Text = "answer.", Type = WordType.Verb, ExerciseId = 55 },

            #endregion

            #region Lesson 12

            new { Number = 1, Text = "He", Type = WordType.Pronoun, ExerciseId = 56 },
            new { Number = 2, Text = "was", Type = WordType.PrimaryVerb, ExerciseId = 56 },
            new { Number = 3, Text = "reading", Type = WordType.Verb, ExerciseId = 56 },
            new { Number = 4, Text = "the", Type = WordType.Determiner, ExerciseId = 56 },
            new { Number = 5, Text = "letter", Type = WordType.Noun, ExerciseId = 56 },
            new { Number = 6, Text = "from", Type = WordType.Preposition, ExerciseId = 56 },
            new { Number = 7, Text = "four", Type = WordType.LetterNumber, ExerciseId = 56 },
            new { Number = 8, Text = "to", Type = WordType.Preposition, ExerciseId = 56 },
            new { Number = 9, Text = "ten", Type = WordType.LetterNumber, ExerciseId = 56 },
            new { Number = 10, Text = "yesterday.", Type = WordType.Adverb, ExerciseId = 56 },

            new { Number = 1, Text = "We", Type = WordType.Pronoun, ExerciseId = 57 },
            new { Number = 2, Text = "were", Type = WordType.PrimaryVerb, ExerciseId = 57 },
            new { Number = 3, Text = "answering", Type = WordType.Verb, ExerciseId = 57 },
            new { Number = 4, Text = "the", Type = WordType.Determiner, ExerciseId = 57 },
            new { Number = 5, Text = "letter", Type = WordType.Noun, ExerciseId = 57 },
            new { Number = 6, Text = "at", Type = WordType.Preposition, ExerciseId = 57 },
            new { Number = 7, Text = "four", Type = WordType.LetterNumber, ExerciseId = 57 },
            new { Number = 8, Text = "yesterday.", Type = WordType.Adverb, ExerciseId = 57 },

            new { Number = 1, Text = "You", Type = WordType.Pronoun, ExerciseId = 58 },
            new { Number = 2, Text = "are", Type = WordType.PrimaryVerb, ExerciseId = 58 },
            new { Number = 3, Text = "feeling", Type = WordType.Verb, ExerciseId = 58 },
            new { Number = 4, Text = "bad", Type = WordType.Adjective, ExerciseId = 58 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 58 },
            new { Number = 6, Text = "whole", Type = WordType.Adjective, ExerciseId = 58 },
            new { Number = 7, Text = "day", Type = WordType.Noun, ExerciseId = 58 },
            new { Number = 8, Text = "today.", Type = WordType.Adverb, ExerciseId = 58 },

            new { Number = 1, Text = "We", Type = WordType.Pronoun, ExerciseId = 59 },
            new { Number = 2, Text = "were", Type = WordType.PrimaryVerb, ExerciseId = 59 },
            new { Number = 3, Text = "studying", Type = WordType.Verb, ExerciseId = 59 },
            new { Number = 4, Text = "French", Type = WordType.Language, ExerciseId = 59 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 59 },
            new { Number = 6, Text = "whole", Type = WordType.Adjective, ExerciseId = 59 },
            new { Number = 7, Text = "day", Type = WordType.Noun, ExerciseId = 59 },
            new { Number = 8, Text = "yesterday.", Type = WordType.Preposition, ExerciseId = 59 },

            new { Number = 1, Text = "You", Type = WordType.Pronoun, ExerciseId = 60 },
            new { Number = 2, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 60 },
            new { Number = 3, Text = "be", Type = WordType.PrimaryVerb, ExerciseId = 60 },
            new { Number = 4, Text = "reading", Type = WordType.Verb, ExerciseId = 60 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 60 },
            new { Number = 6, Text = "book", Type = WordType.Noun, ExerciseId = 60 },
            new { Number = 7, Text = "the", Type = WordType.Determiner, ExerciseId = 60 },
            new { Number = 8, Text = "whole", Type = WordType.Adjective, ExerciseId = 60 },
            new { Number = 9, Text = "day", Type = WordType.Noun, ExerciseId = 60 },
            new { Number = 10, Text = "tomorrow.", Type = WordType.Adverb, ExerciseId = 60 },

            #endregion

            #region Lesson 13

            new { Number = 1, Text = "Am", Type = WordType.PrimaryVerb, ExerciseId = 61 },
            new { Number = 2, Text = "I", Type = WordType.Pronoun, ExerciseId = 61 },
            new { Number = 3, Text = "cold?", Type = WordType.Adjective, ExerciseId = 61 },

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 62 },
            new { Number = 2, Text = "do not", Type = WordType.PrimaryVerb, ExerciseId = 62 },
            new { Number = 3, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 62 },
            new { Number = 4, Text = "blue", Type = WordType.Adverb, ExerciseId = 62 },
            new { Number = 5, Text = "eyes.", Type = WordType.Noun, ExerciseId = 62 },

            new { Number = 1, Text = "You", Type = WordType.Pronoun, ExerciseId = 63 },
            new { Number = 2, Text = "are", Type = WordType.PrimaryVerb, ExerciseId = 63 },
            new { Number = 3, Text = "healthy.", Type = WordType.Adjective, ExerciseId = 63 },

            new { Number = 1, Text = "It", Type = WordType.Pronoun, ExerciseId = 64 },
            new { Number = 2, Text = "was", Type = WordType.PrimaryVerb, ExerciseId = 64 },
            new { Number = 3, Text = "hot", Type = WordType.Adjective, ExerciseId = 64 },
            new { Number = 4, Text = "yesterday.", Type = WordType.Adverb, ExerciseId = 64 },

            new { Number = 1, Text = "She", Type = WordType.Pronoun, ExerciseId = 65 },
            new { Number = 2, Text = "is", Type = WordType.PrimaryVerb, ExerciseId = 65 },
            new { Number = 3, Text = "adult.", Type = WordType.Adjective, ExerciseId = 65 },

            #endregion

            #region Lesson 14

            new { Number = 1, Text = "Run", Type = WordType.Verb, ExerciseId = 66 },
            new { Number = 2, Text = "to", Type = WordType.Preposition, ExerciseId = 66 },
            new { Number = 3, Text = "her.", Type = WordType.Pronoun, ExerciseId = 66 },

            new { Number = 1, Text = "Don't", Type = WordType.PrimaryVerb, ExerciseId = 67 },
            new { Number = 2, Text = "turn", Type = WordType.Verb, ExerciseId = 67 },
            new { Number = 3, Text = "his", Type = WordType.Pronoun, ExerciseId = 67 },
            new { Number = 4, Text = "nightstand.", Type = WordType.Noun, ExerciseId = 67 },

            new { Number = 1, Text = "Don't", Type = WordType.PrimaryVerb, ExerciseId = 68 },
            new { Number = 2, Text = "take", Type = WordType.Verb, ExerciseId = 68 },
            new { Number = 3, Text = "my", Type = WordType.Pronoun, ExerciseId = 68 },
            new { Number = 4, Text = "tablet.", Type = WordType.Noun, ExerciseId = 68 },

            new { Number = 1, Text = "Remember", Type = WordType.Verb, ExerciseId = 69 },
            new { Number = 2, Text = "about", Type = WordType.Preposition, ExerciseId = 69 },
            new { Number = 3, Text = "us.", Type = WordType.Pronoun, ExerciseId = 69 },

            new { Number = 1, Text = "Let", Type = WordType.Verb, ExerciseId = 70 },
            new { Number = 2, Text = "him", Type = WordType.Pronoun, ExerciseId = 70 },
            new { Number = 3, Text = "answer.", Type = WordType.Verb, ExerciseId = 70 },

            #endregion

            #region Lesson 15

            new { Number = 1, Text = "He", Type = WordType.Pronoun, ExerciseId = 71 },
            new { Number = 2, Text = "took", Type = WordType.Verb, ExerciseId = 71 },
            new { Number = 3, Text = "off", Type = WordType.Preposition, ExerciseId = 71 },
            new { Number = 4, Text = "weight.", Type = WordType.Noun, ExerciseId = 71 },

            new { Number = 1, Text = "Your", Type = WordType.Pronoun, ExerciseId = 72 },
            new { Number = 2, Text = "son", Type = WordType.Noun, ExerciseId = 72 },
            new { Number = 3, Text = "asks", Type = WordType.Verb, ExerciseId = 72 },
            new { Number = 4, Text = "to", Type = WordType.Preposition, ExerciseId = 72 },
            new { Number = 5, Text = "turn", Type = WordType.Verb, ExerciseId = 72 },
            new { Number = 6, Text = "on", Type = WordType.Preposition, ExerciseId = 72 },
            new { Number = 7, Text = "the", Type = WordType.Determiner, ExerciseId = 72 },
            new { Number = 8, Text = "light.", Type = WordType.Noun, ExerciseId = 72 },

            new { Number = 1, Text = "He", Type = WordType.Pronoun, ExerciseId = 73 },
            new { Number = 2, Text = "went", Type = WordType.Verb, ExerciseId = 73 },
            new { Number = 3, Text = "down", Type = WordType.Preposition, ExerciseId = 73 },
            new { Number = 4, Text = "with", Type = WordType.Preposition, ExerciseId = 73 },
            new { Number = 5, Text = "pneumonia.", Type = WordType.Noun, ExerciseId = 73 },

            new { Number = 1, Text = "He", Type = WordType.Pronoun, ExerciseId = 74 },
            new { Number = 2, Text = "broke", Type = WordType.Verb, ExerciseId = 74 },
            new { Number = 3, Text = "down", Type = WordType.Preposition, ExerciseId = 74 },
            new { Number = 4, Text = "the", Type = WordType.Determiner, ExerciseId = 74 },
            new { Number = 5, Text = "door.", Type = WordType.Noun, ExerciseId = 74 },

            new { Number = 1, Text = "The", Type = WordType.Determiner, ExerciseId = 75 },
            new { Number = 2, Text = "prices", Type = WordType.Noun, ExerciseId = 75 },
            new { Number = 3, Text = "never", Type = WordType.Adverb, ExerciseId = 75 },
            new { Number = 4, Text = "go", Type = WordType.Verb, ExerciseId = 75 },
            new { Number = 5, Text = "down.", Type = WordType.Preposition, ExerciseId = 75 },

            #endregion

            #region Lesson 16

            new { Number = 1, Text = "He", Type = WordType.Pronoun, ExerciseId = 76 },
            new { Number = 2, Text = "has", Type = WordType.PrimaryVerb, ExerciseId = 76 },
            new { Number = 3, Text = "just", Type = WordType.Adverb, ExerciseId = 76 },
            new { Number = 4, Text = "gone", Type = WordType.Verb, ExerciseId = 76 },
            new { Number = 5, Text = "out.", Type = WordType.Adverb, ExerciseId = 76 },

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 77 },
            new { Number = 2, Text = "think", Type = WordType.Verb, ExerciseId = 77 },
            new { Number = 3, Text = "I", Type = WordType.Pronoun, ExerciseId = 77 },
            new { Number = 4, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 77 },
            new { Number = 5, Text = "seen", Type = WordType.Verb, ExerciseId = 77 },
            new { Number = 6, Text = "you", Type = WordType.Pronoun, ExerciseId = 77 },
            new { Number = 7, Text = "somewhere.", Type = WordType.Compound, ExerciseId = 77 },

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 78 },
            new { Number = 2, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 78 },
            new { Number = 3, Text = "done", Type = WordType.Verb, ExerciseId = 78 },
            new { Number = 4, Text = "the", Type = WordType.Determiner, ExerciseId = 78 },
            new { Number = 5, Text = "work.", Type = WordType.Verb, ExerciseId = 78 },

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 79 },
            new { Number = 2, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 79 },
            new { Number = 3, Text = "already", Type = WordType.Adverb, ExerciseId = 79 },
            new { Number = 4, Text = "written", Type = WordType.Verb, ExerciseId = 79 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 79 },
            new { Number = 6, Text = "letter", Type = WordType.Noun, ExerciseId = 79 },
            new { Number = 7, Text = "to", Type = WordType.Preposition, ExerciseId = 79 },
            new { Number = 8, Text = "my", Type = WordType.Pronoun, ExerciseId = 79 },
            new { Number = 9, Text = "friend.", Type = WordType.Noun, ExerciseId = 79 },

            new { Number = 1, Text = "He", Type = WordType.Pronoun, ExerciseId = 80 },
            new { Number = 2, Text = "has", Type = WordType.PrimaryVerb, ExerciseId = 80 },
            new { Number = 3, Text = "just", Type = WordType.Adverb, ExerciseId = 80 },
            new { Number = 4, Text = "visited", Type = WordType.Verb, ExerciseId = 80 },
            new { Number = 5, Text = "this", Type = WordType.Pronoun, ExerciseId = 80 },
            new { Number = 6, Text = "supermarket.", Type = WordType.Noun, ExerciseId = 80 },

            #endregion

            #region Lesson 17

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 81 },
            new { Number = 2, Text = "had not", Type = WordType.PrimaryVerb, ExerciseId = 81 },
            new { Number = 3, Text = "finished", Type = WordType.Verb, ExerciseId = 81 },
            new { Number = 4, Text = "the", Type = WordType.Determiner, ExerciseId = 81 },
            new { Number = 5, Text = "project", Type = WordType.Noun, ExerciseId = 81 },
            new { Number = 6, Text = "by", Type = WordType.Preposition, ExerciseId = 81 },
            new { Number = 7, Text = "the", Type = WordType.Determiner, ExerciseId = 81 },
            new { Number = 8, Text = "beginning", Type = WordType.Verb, ExerciseId = 81 },
            new { Number = 9, Text = "of", Type = WordType.Preposition, ExerciseId = 81 },
            new { Number = 10, Text = "that", Type = WordType.Pronoun, ExerciseId = 81 },
            new { Number = 11, Text = "week.", Type = WordType.Noun, ExerciseId = 81 },

            new { Number = 1, Text = "Had", Type = WordType.PrimaryVerb, ExerciseId = 82 },
            new { Number = 2, Text = "he", Type = WordType.Pronoun, ExerciseId = 82 },
            new { Number = 3, Text = "done", Type = WordType.Verb, ExerciseId = 82 },
            new { Number = 4, Text = "his", Type = WordType.Pronoun, ExerciseId = 82 },
            new { Number = 5, Text = "homework", Type = WordType.Noun, ExerciseId = 82 },
            new { Number = 6, Text = "before", Type = WordType.Preposition, ExerciseId = 82 },
            new { Number = 7, Text = "his", Type = WordType.PrimaryVerb, ExerciseId = 82 },
            new { Number = 8, Text = "parents", Type = WordType.Noun, ExerciseId = 82 },
            new { Number = 9, Text = "returned", Type = WordType.Verb, ExerciseId = 82 },
            new { Number = 10, Text = "home?", Type = WordType.Noun, ExerciseId = 82 },

            new { Number = 1, Text = "Had", Type = WordType.PrimaryVerb, ExerciseId = 83 },
            new { Number = 2, Text = "he", Type = WordType.Pronoun, ExerciseId = 83 },
            new { Number = 3, Text = "written", Type = WordType.Verb, ExerciseId = 83 },
            new { Number = 4, Text = "a", Type = WordType.Determiner, ExerciseId = 83 },
            new { Number = 5, Text = "letter,", Type = WordType.Noun, ExerciseId = 83 },
            new { Number = 6, Text = "when", Type = WordType.QuestionWord, ExerciseId = 83 },
            new { Number = 7, Text = "you", Type = WordType.Pronoun, ExerciseId = 83 },
            new { Number = 8, Text = "came", Type = WordType.Verb, ExerciseId = 83 },
            new { Number = 9, Text = "in?", Type = WordType.Preposition, ExerciseId = 83 },

            new { Number = 1, Text = "You", Type = WordType.Pronoun, ExerciseId = 84 },
            new { Number = 2, Text = "had", Type = WordType.PrimaryVerb, ExerciseId = 84 },
            new { Number = 3, Text = "returned", Type = WordType.Verb, ExerciseId = 84 },
            new { Number = 4, Text = "home", Type = WordType.Noun, ExerciseId = 84 },
            new { Number = 5, Text = "before", Type = WordType.Preposition, ExerciseId = 84 },
            new { Number = 6, Text = "the", Type = WordType.Determiner, ExerciseId = 84 },
            new { Number = 7, Text = "rain", Type = WordType.Noun, ExerciseId = 84 },
            new { Number = 8, Text = "began.", Type = WordType.Verb, ExerciseId = 84 },

            new { Number = 1, Text = "When", Type = WordType.QuestionWord, ExerciseId = 85 },
            new { Number = 2, Text = "we", Type = WordType.Pronoun, ExerciseId = 85 },
            new { Number = 3, Text = "came", Type = WordType.Verb, ExerciseId = 85 },
            new { Number = 4, Text = "to", Type = WordType.Preposition, ExerciseId = 85 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 85 },
            new { Number = 6, Text = "station", Type = WordType.Noun, ExerciseId = 85 },
            new { Number = 7, Text = "the", Type = WordType.Determiner, ExerciseId = 85 },
            new { Number = 8, Text = "train", Type = WordType.Noun, ExerciseId = 85 },
            new { Number = 9, Text = "had", Type = WordType.PrimaryVerb, ExerciseId = 85 },
            new { Number = 10, Text = "already", Type = WordType.Adverb, ExerciseId = 85 },
            new { Number = 11, Text = "gone.", Type = WordType.Verb, ExerciseId = 85 },

            #endregion

            #region Lesson 18

            new { Number = 1, Text = "The", Type = WordType.Determiner, ExerciseId = 86 },
            new { Number = 2, Text = "pupils", Type = WordType.Noun, ExerciseId = 86 },
            new { Number = 3, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 86 },
            new { Number = 4, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 86 },
            new { Number = 5, Text = "taken", Type = WordType.Verb, ExerciseId = 86 },
            new { Number = 6, Text = "their", Type = WordType.Pronoun, ExerciseId = 86 },
            new { Number = 7, Text = "seats", Type = WordType.Noun, ExerciseId = 86 },
            new { Number = 8, Text = "before", Type = WordType.Preposition, ExerciseId = 86 },
            new { Number = 9, Text = "the", Type = WordType.Determiner, ExerciseId = 86 },
            new { Number = 10, Text = "lesson", Type = WordType.Noun, ExerciseId = 86 },
            new { Number = 11, Text = "starts.", Type = WordType.Verb, ExerciseId = 86 },

            new { Number = 1, Text = "They", Type = WordType.Pronoun, ExerciseId = 87 },
            new { Number = 2, Text = "will not", Type = WordType.PrimaryVerb, ExerciseId = 87 },
            new { Number = 3, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 87 },
            new { Number = 4, Text = "won", Type = WordType.Verb, ExerciseId = 87 },
            new { Number = 5, Text = "three", Type = WordType.LetterNumber, ExerciseId = 87 },
            new { Number = 6, Text = "games", Type = WordType.Noun, ExerciseId = 87 },
            new { Number = 7, Text = "by", Type = WordType.Preposition, ExerciseId = 87 },
            new { Number = 8, Text = "the", Type = WordType.Determiner, ExerciseId = 87 },
            new { Number = 9, Text = "end", Type = WordType.Noun, ExerciseId = 87 },
            new { Number = 10, Text = "of", Type = WordType.Preposition, ExerciseId = 87 },
            new { Number = 11, Text = "the", Type = WordType.Determiner, ExerciseId = 87 },
            new { Number = 12, Text = "month.", Type = WordType.Noun, ExerciseId = 87 },

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 88 },
            new { Number = 2, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 88 },
            new { Number = 3, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 88 },
            new { Number = 4, Text = "finished", Type = WordType.Verb, ExerciseId = 88 },
            new { Number = 5, Text = "this", Type = WordType.Pronoun, ExerciseId = 88 },
            new { Number = 6, Text = "work,", Type = WordType.Verb, ExerciseId = 88 },
            new { Number = 7, Text = "before", Type = WordType.Preposition, ExerciseId = 88 },
            new { Number = 8, Text = "you", Type = WordType.Pronoun, ExerciseId = 88 },
            new { Number = 9, Text = "return.", Type = WordType.Verb, ExerciseId = 88 },

            new { Number = 1, Text = "They", Type = WordType.Pronoun, ExerciseId = 89 },
            new { Number = 2, Text = "will not", Type = WordType.PrimaryVerb, ExerciseId = 89 },
            new { Number = 3, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 89 },
            new { Number = 4, Text = "shipped", Type = WordType.Verb, ExerciseId = 89 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 89 },
            new { Number = 6, Text = "goods", Type = WordType.Noun, ExerciseId = 89 },
            new { Number = 7, Text = "when", Type = WordType.QuestionWord, ExerciseId = 89 },
            new { Number = 8, Text = "your", Type = WordType.Pronoun, ExerciseId = 89 },
            new { Number = 9, Text = "telegram", Type = WordType.Noun, ExerciseId = 89 },
            new { Number = 10, Text = "arrives.", Type = WordType.Verb, ExerciseId = 89 },

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 90 },
            new { Number = 2, Text = "will not", Type = WordType.PrimaryVerb, ExerciseId = 90 },
            new { Number = 3, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 90 },
            new { Number = 4, Text = "finished", Type = WordType.Verb, ExerciseId = 90 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 90 },
            new { Number = 6, Text = "report", Type = WordType.Noun, ExerciseId = 90 },
            new { Number = 7, Text = "by", Type = WordType.Preposition, ExerciseId = 90 },
            new { Number = 8, Text = "tonight.", Type = WordType.Adverb, ExerciseId = 90 },

            #endregion

            #region Lesson 20

            new { Number = 1, Text = "She", Type = WordType.Pronoun, ExerciseId = 91 },
            new { Number = 2, Text = "has", Type = WordType.PrimaryVerb, ExerciseId = 91 },
            new { Number = 3, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 91 },
            new { Number = 4, Text = "cooking", Type = WordType.Verb, ExerciseId = 91 },
            new { Number = 5, Text = "dinner", Type = WordType.Noun, ExerciseId = 91 },
            new { Number = 6, Text = "for", Type = WordType.Preposition, ExerciseId = 91 },
            new { Number = 7, Text = "three", Type = WordType.LetterNumber, ExerciseId = 91 },
            new { Number = 8, Text = "hours.", Type = WordType.Noun, ExerciseId = 91 },

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 92 },
            new { Number = 2, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 92 },
            new { Number = 3, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 92 },
            new { Number = 4, Text = "baking", Type = WordType.Verb, ExerciseId = 92 },
            new { Number = 5, Text = "this", Type = WordType.Pronoun, ExerciseId = 92 },
            new { Number = 6, Text = "cake", Type = WordType.Noun, ExerciseId = 92 },
            new { Number = 7, Text = "since", Type = WordType.Preposition, ExerciseId = 92 },
            new { Number = 8, Text = "morning.", Type = WordType.Noun, ExerciseId = 92 },

            new { Number = 1, Text = "The", Type = WordType.Determiner, ExerciseId = 93 },
            new { Number = 2, Text = "workers", Type = WordType.Noun, ExerciseId = 93 },
            new { Number = 3, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 93 },
            new { Number = 4, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 93 },
            new { Number = 5, Text = "trying", Type = WordType.Verb, ExerciseId = 93 },
            new { Number = 6, Text = "to", Type = WordType.Preposition, ExerciseId = 93 },
            new { Number = 7, Text = "move", Type = WordType.Verb, ExerciseId = 93 },
            new { Number = 8, Text = "our", Type = WordType.Pronoun, ExerciseId = 93 },
            new { Number = 9, Text = "cupboard", Type = WordType.Noun, ExerciseId = 93 },
            new { Number = 10, Text = "for", Type = WordType.Preposition, ExerciseId = 93 },
            new { Number = 11, Text = "half", Type = WordType.Noun, ExerciseId = 93 },
            new { Number = 12, Text = "an", Type = WordType.Determiner, ExerciseId = 93 },
            new { Number = 13, Text = "hour.", Type = WordType.Noun, ExerciseId = 93 },

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 94 },
            new { Number = 2, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 94 },
            new { Number = 3, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 94 },
            new { Number = 4, Text = "reading", Type = WordType.Verb, ExerciseId = 94 },
            new { Number = 5, Text = "this", Type = WordType.Pronoun, ExerciseId = 94 },
            new { Number = 6, Text = "magazine", Type = WordType.Noun, ExerciseId = 94 },
            new { Number = 7, Text = "since", Type = WordType.Preposition, ExerciseId = 94 },
            new { Number = 8, Text = "I", Type = WordType.Pronoun, ExerciseId = 94 },
            new { Number = 9, Text = "bought", Type = WordType.Verb, ExerciseId = 94 },
            new { Number = 10, Text = "it", Type = WordType.Pronoun, ExerciseId = 94 },
            new { Number = 11, Text = "a", Type = WordType.Determiner, ExerciseId = 94 },
            new { Number = 12, Text = "week", Type = WordType.Noun, ExerciseId = 94 },
            new { Number = 13, Text = "ago.", Type = WordType.Preposition, ExerciseId = 94 },

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 95 },
            new { Number = 2, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 95 },
            new { Number = 3, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 95 },
            new { Number = 4, Text = "waiting", Type = WordType.Verb, ExerciseId = 95 },
            new { Number = 5, Text = "for", Type = WordType.Preposition, ExerciseId = 95 },
            new { Number = 6, Text = "my", Type = WordType.Pronoun, ExerciseId = 95 },
            new { Number = 7, Text = "mother", Type = WordType.Noun, ExerciseId = 95 },
            new { Number = 8, Text = "for", Type = WordType.Preposition, ExerciseId = 95 },
            new { Number = 9, Text = "a", Type = WordType.Determiner, ExerciseId = 95 },
            new { Number = 10, Text = "long", Type = WordType.Adjective, ExerciseId = 95 },
            new { Number = 11, Text = "time.", Type = WordType.Noun, ExerciseId = 95 },

            #endregion

            #region Lesson 21

            new { Number = 1, Text = "Since", Type = WordType.Preposition, ExerciseId = 96 },
            new { Number = 2, Text = "then", Type = WordType.Preposition, ExerciseId = 96 },
            new { Number = 3, Text = "the", Type = WordType.Determiner, ExerciseId = 96 },
            new { Number = 4, Text = "index", Type = WordType.Noun, ExerciseId = 96 },
            new { Number = 5, Text = "had", Type = WordType.PrimaryVerb, ExerciseId = 96 },
            new { Number = 6, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 96 },
            new { Number = 7, Text = "rising", Type = WordType.Verb, ExerciseId = 96 },
            new { Number = 8, Text = "fast.", Type = WordType.Adjective, ExerciseId = 96 },

            new { Number = 1, Text = "His", Type = WordType.Pronoun, ExerciseId = 97 },
            new { Number = 2, Text = "hands", Type = WordType.Noun, ExerciseId = 97 },
            new { Number = 3, Text = "were", Type = WordType.PrimaryVerb, ExerciseId = 97 },
            new { Number = 4, Text = "dirty", Type = WordType.Adjective, ExerciseId = 97 },
            new { Number = 5, Text = "he", Type = WordType.Pronoun, ExerciseId = 97 },
            new { Number = 6, Text = "had", Type = WordType.PrimaryVerb, ExerciseId = 97 },
            new { Number = 7, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 97 },
            new { Number = 8, Text = "digging.", Type = WordType.Verb, ExerciseId = 97 },

            new { Number = 1, Text = "They", Type = WordType.Pronoun, ExerciseId = 98 },
            new { Number = 2, Text = "had", Type = WordType.PrimaryVerb, ExerciseId = 98 },
            new { Number = 3, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 98 },
            new { Number = 4, Text = "talking", Type = WordType.Verb, ExerciseId = 98 },
            new { Number = 5, Text = "for", Type = WordType.Preposition, ExerciseId = 98 },
            new { Number = 6, Text = "over", Type = WordType.Preposition, ExerciseId = 98 },
            new { Number = 7, Text = "an", Type = WordType.Determiner, ExerciseId = 98 },
            new { Number = 8, Text = "hour", Type = WordType.Noun, ExerciseId = 98 },
            new { Number = 9, Text = "before", Type = WordType.Preposition, ExerciseId = 98 },
            new { Number = 10, Text = "he", Type = WordType.Pronoun, ExerciseId = 98 },
            new { Number = 11, Text = "arrived.", Type = WordType.Verb, ExerciseId = 98 },

            new { Number = 1, Text = "It", Type = WordType.Pronoun, ExerciseId = 99 },
            new { Number = 2, Text = "was", Type = WordType.PrimaryVerb, ExerciseId = 99 },
            new { Number = 3, Text = "one", Type = WordType.Noun, ExerciseId = 99 },
            new { Number = 4, Text = "o'clock", Type = WordType.Adverb, ExerciseId = 99 },
            new { Number = 5, Text = "and", Type = WordType.Preposition, ExerciseId = 99 },
            new { Number = 6, Text = "the", Type = WordType.Determiner, ExerciseId = 99 },
            new { Number = 7, Text = "dog", Type = WordType.Noun, ExerciseId = 99 },
            new { Number = 8, Text = "from", Type = WordType.Preposition, ExerciseId = 99 },
            new { Number = 9, Text = "next", Type = WordType.Adjective, ExerciseId = 99 },
            new { Number = 10, Text = "door", Type = WordType.Noun, ExerciseId = 99 },
            new { Number = 11, Text = "had", Type = WordType.PrimaryVerb, ExerciseId = 99 },
            new { Number = 12, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 99 },
            new { Number = 13, Text = "barking", Type = WordType.Verb, ExerciseId = 99 },
            new { Number = 14, Text = "for", Type = WordType.Preposition, ExerciseId = 99 },
            new { Number = 15, Text = "two", Type = WordType.LetterNumber, ExerciseId = 99 },
            new { Number = 16, Text = "hours.", Type = WordType.Noun, ExerciseId = 99 },

            new { Number = 1, Text = "My", Type = WordType.Pronoun, ExerciseId = 100 },
            new { Number = 2, Text = "dog", Type = WordType.Noun, ExerciseId = 100 },
            new { Number = 3, Text = "had", Type = WordType.PrimaryVerb, ExerciseId = 100 },
            new { Number = 4, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 100 },
            new { Number = 5, Text = "playing", Type = WordType.Verb, ExerciseId = 100 },
            new { Number = 6, Text = "for", Type = WordType.Preposition, ExerciseId = 100 },
            new { Number = 7, Text = "half", Type = WordType.Noun, ExerciseId = 100 },
            new { Number = 8, Text = "an", Type = WordType.Determiner, ExerciseId = 100 },
            new { Number = 9, Text = "hour", Type = WordType.Noun, ExerciseId = 100 },
            new { Number = 10, Text = "before", Type = WordType.Preposition, ExerciseId = 100 },
            new { Number = 11, Text = "we", Type = WordType.Pronoun, ExerciseId = 100 },
            new { Number = 12, Text = "went", Type = WordType.Verb, ExerciseId = 100 },
            new { Number = 13, Text = "for", Type = WordType.Preposition, ExerciseId = 100 },
            new { Number = 14, Text = "a", Type = WordType.Determiner, ExerciseId = 100 },
            new { Number = 15, Text = "walk.", Type = WordType.Verb, ExerciseId = 100 },

            #endregion

            #region Lesson 22

            new { Number = 1, Text = "They", Type = WordType.Pronoun, ExerciseId = 101 },
            new { Number = 2, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 101 },
            new { Number = 3, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 101 },
            new { Number = 4, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 101 },
            new { Number = 5, Text = "talking", Type = WordType.Verb, ExerciseId = 101 },
            new { Number = 6, Text = "for", Type = WordType.Preposition, ExerciseId = 101 },
            new { Number = 7, Text = "over", Type = WordType.Preposition, ExerciseId = 101 },
            new { Number = 8, Text = "an", Type = WordType.Determiner, ExerciseId = 101 },
            new { Number = 9, Text = "hour,", Type = WordType.Noun, ExerciseId = 101 },
            new { Number = 10, Text = "by", Type = WordType.Preposition, ExerciseId = 101 },
            new { Number = 11, Text = "the", Type = WordType.Determiner, ExerciseId = 101 },
            new { Number = 12, Text = "time,", Type = WordType.Noun, ExerciseId = 101 },
            new { Number = 13, Text = "he", Type = WordType.Pronoun, ExerciseId = 101 },
            new { Number = 14, Text = "arrives.", Type = WordType.Verb, ExerciseId = 101 },

            new { Number = 1, Text = "By", Type = WordType.Preposition, ExerciseId = 102 },
            new { Number = 2, Text = "the", Type = WordType.Determiner, ExerciseId = 102 },
            new { Number = 3, Text = "first", Type = WordType.Adverb, ExerciseId = 102 },
            new { Number = 4, Text = "of", Type = WordType.Preposition, ExerciseId = 102 },
            new { Number = 5, Text = "June", Type = WordType.Noun, ExerciseId = 102 },
            new { Number = 6, Text = "he", Type = WordType.Pronoun, ExerciseId = 102 },
            new { Number = 7, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 102 },
            new { Number = 8, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 102 },
            new { Number = 9, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 102 },
            new { Number = 10, Text = "working", Type = WordType.Verb, ExerciseId = 102 },
            new { Number = 11, Text = "at", Type = WordType.Preposition, ExerciseId = 102 },
            new { Number = 12, Text = "this", Type = WordType.Pronoun, ExerciseId = 102 },
            new { Number = 13, Text = "plant", Type = WordType.Noun, ExerciseId = 102 },
            new { Number = 14, Text = "for", Type = WordType.Preposition, ExerciseId = 102 },
            new { Number = 15, Text = "twenty", Type = WordType.LetterNumber, ExerciseId = 102 },
            new { Number = 16, Text = "years.", Type = WordType.Noun, ExerciseId = 102 },

            new { Number = 1, Text = "Next", Type = WordType.Adjective, ExerciseId = 103 },
            new { Number = 2, Text = "Christmas", Type = WordType.Noun, ExerciseId = 103 },
            new { Number = 3, Text = "I", Type = WordType.Pronoun, ExerciseId = 103 },
            new { Number = 4, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 103 },
            new { Number = 5, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 103 },
            new { Number = 6, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 103 },
            new { Number = 7, Text = "teaching", Type = WordType.Verb, ExerciseId = 103 },
            new { Number = 8, Text = "for", Type = WordType.Preposition, ExerciseId = 103 },
            new { Number = 9, Text = "ten", Type = WordType.LetterNumber, ExerciseId = 103 },
            new { Number = 10, Text = "years.", Type = WordType.Noun, ExerciseId = 103 },

            new { Number = 1, Text = "Will", Type = WordType.PrimaryVerb, ExerciseId = 104 },
            new { Number = 2, Text = "you", Type = WordType.Pronoun, ExerciseId = 104 },
            new { Number = 3, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 104 },
            new { Number = 4, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 104 },
            new { Number = 5, Text = "waiting", Type = WordType.Verb, ExerciseId = 104 },
            new { Number = 6, Text = "for", Type = WordType.Preposition, ExerciseId = 104 },
            new { Number = 7, Text = "more", Type = WordType.Adverb, ExerciseId = 104 },
            new { Number = 8, Text = "than", Type = WordType.Preposition, ExerciseId = 104 },
            new { Number = 9, Text = "two", Type = WordType.LetterNumber, ExerciseId = 104 },
            new { Number = 10, Text = "hours,", Type = WordType.Noun, ExerciseId = 104 },
            new { Number = 11, Text = "when", Type = WordType.QuestionWord, ExerciseId = 104 },
            new { Number = 12, Text = "her", Type = WordType.Pronoun, ExerciseId = 104 },
            new { Number = 13, Text = "plane", Type = WordType.Noun, ExerciseId = 104 },
            new { Number = 14, Text = "finally", Type = WordType.Adverb, ExerciseId = 104 },
            new { Number = 15, Text = "arrives?", Type = WordType.Verb, ExerciseId = 104 },

            new { Number = 1, Text = "Next", Type = WordType.Adjective, ExerciseId = 105 },
            new { Number = 2, Text = "month", Type = WordType.Noun, ExerciseId = 105 },
            new { Number = 3, Text = "we", Type = WordType.Pronoun, ExerciseId = 105 },
            new { Number = 4, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 105 },
            new { Number = 5, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 105 },
            new { Number = 6, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 105 },
            new { Number = 7, Text = "living", Type = WordType.Verb, ExerciseId = 105 },
            new { Number = 8, Text = "together", Type = WordType.Preposition, ExerciseId = 105 },
            new { Number = 9, Text = "for", Type = WordType.Preposition, ExerciseId = 105 },
            new { Number = 10, Text = "fifteen", Type = WordType.LetterNumber, ExerciseId = 105 },
            new { Number = 11, Text = "years.", Type = WordType.Noun, ExerciseId = 105 },

            #endregion

            #region Lesson 24

            new { Number = 1, Text = "They", Type = WordType.Pronoun, ExerciseId = 106 },
            new { Number = 2, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 106 },
            new { Number = 3, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 106 },
            new { Number = 4, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 106 },
            new { Number = 5, Text = "talking", Type = WordType.Verb, ExerciseId = 106 },
            new { Number = 6, Text = "for", Type = WordType.Preposition, ExerciseId = 106 },
            new { Number = 7, Text = "over", Type = WordType.Preposition, ExerciseId = 106 },
            new { Number = 8, Text = "an", Type = WordType.Determiner, ExerciseId = 106 },
            new { Number = 9, Text = "hour,", Type = WordType.Noun, ExerciseId = 106 },
            new { Number = 10, Text = "by", Type = WordType.Preposition, ExerciseId = 106 },
            new { Number = 11, Text = "the", Type = WordType.Determiner, ExerciseId = 106 },
            new { Number = 12, Text = "time,", Type = WordType.Noun, ExerciseId = 106 },
            new { Number = 13, Text = "he", Type = WordType.Pronoun, ExerciseId = 106 },
            new { Number = 14, Text = "arrives.", Type = WordType.Verb, ExerciseId = 106 },

            new { Number = 1, Text = "By", Type = WordType.Preposition, ExerciseId = 107 },
            new { Number = 2, Text = "the", Type = WordType.Determiner, ExerciseId = 107 },
            new { Number = 3, Text = "first", Type = WordType.Adverb, ExerciseId = 107 },
            new { Number = 4, Text = "of", Type = WordType.Preposition, ExerciseId = 107 },
            new { Number = 5, Text = "June", Type = WordType.Noun, ExerciseId = 107 },
            new { Number = 6, Text = "he", Type = WordType.Pronoun, ExerciseId = 107 },
            new { Number = 7, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 107 },
            new { Number = 8, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 107 },
            new { Number = 9, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 107 },
            new { Number = 10, Text = "working", Type = WordType.Verb, ExerciseId = 107 },
            new { Number = 11, Text = "at", Type = WordType.Preposition, ExerciseId = 107 },
            new { Number = 12, Text = "this", Type = WordType.Pronoun, ExerciseId = 107 },
            new { Number = 13, Text = "plant", Type = WordType.Noun, ExerciseId = 107 },
            new { Number = 14, Text = "for", Type = WordType.Preposition, ExerciseId = 107 },
            new { Number = 15, Text = "twenty", Type = WordType.LetterNumber, ExerciseId = 107 },
            new { Number = 16, Text = "years.", Type = WordType.Noun, ExerciseId = 107 },

            new { Number = 1, Text = "Next", Type = WordType.Adjective, ExerciseId = 108 },
            new { Number = 2, Text = "Christmas", Type = WordType.Noun, ExerciseId = 108 },
            new { Number = 3, Text = "I", Type = WordType.Pronoun, ExerciseId = 108 },
            new { Number = 4, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 108 },
            new { Number = 5, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 108 },
            new { Number = 6, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 108 },
            new { Number = 7, Text = "teaching", Type = WordType.Verb, ExerciseId = 108 },
            new { Number = 8, Text = "for", Type = WordType.Preposition, ExerciseId = 108 },
            new { Number = 9, Text = "ten", Type = WordType.LetterNumber, ExerciseId = 108 },
            new { Number = 10, Text = "years.", Type = WordType.Noun, ExerciseId = 108 },

            new { Number = 1, Text = "Will", Type = WordType.PrimaryVerb, ExerciseId = 109 },
            new { Number = 2, Text = "you", Type = WordType.Pronoun, ExerciseId = 109 },
            new { Number = 3, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 109 },
            new { Number = 4, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 109 },
            new { Number = 5, Text = "waiting", Type = WordType.Verb, ExerciseId = 109 },
            new { Number = 6, Text = "for", Type = WordType.Preposition, ExerciseId = 109 },
            new { Number = 7, Text = "more", Type = WordType.Adverb, ExerciseId = 109 },
            new { Number = 8, Text = "than", Type = WordType.Preposition, ExerciseId = 109 },
            new { Number = 9, Text = "two", Type = WordType.LetterNumber, ExerciseId = 109 },
            new { Number = 10, Text = "hours,", Type = WordType.Noun, ExerciseId = 109 },
            new { Number = 11, Text = "when", Type = WordType.QuestionWord, ExerciseId = 109 },
            new { Number = 12, Text = "her", Type = WordType.Pronoun, ExerciseId = 109 },
            new { Number = 13, Text = "plane", Type = WordType.Noun, ExerciseId = 109 },
            new { Number = 14, Text = "finally", Type = WordType.Adverb, ExerciseId = 109 },
            new { Number = 15, Text = "arrives?", Type = WordType.Verb, ExerciseId = 109 },

            new { Number = 1, Text = "Next", Type = WordType.Adjective, ExerciseId = 110 },
            new { Number = 2, Text = "month", Type = WordType.Noun, ExerciseId = 110 },
            new { Number = 3, Text = "we", Type = WordType.Pronoun, ExerciseId = 110 },
            new { Number = 4, Text = "will", Type = WordType.PrimaryVerb, ExerciseId = 110 },
            new { Number = 5, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 110 },
            new { Number = 6, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 110 },
            new { Number = 7, Text = "living", Type = WordType.Verb, ExerciseId = 110 },
            new { Number = 8, Text = "together", Type = WordType.Preposition, ExerciseId = 110 },
            new { Number = 9, Text = "for", Type = WordType.Preposition, ExerciseId = 110 },
            new { Number = 10, Text = "fifteen", Type = WordType.LetterNumber, ExerciseId = 110 },
            new { Number = 11, Text = "years.", Type = WordType.Noun, ExerciseId = 110 },

            #endregion

            #region Lesson 25

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 111 },
            new { Number = 2, Text = "was", Type = WordType.PrimaryVerb, ExerciseId = 111 },
            new { Number = 3, Text = "disappointed", Type = WordType.Verb, ExerciseId = 111 },
            new { Number = 4, Text = "to", Type = WordType.Preposition, ExerciseId = 111 },
            new { Number = 5, Text = "hear", Type = WordType.Verb, ExerciseId = 111 },
            new { Number = 6, Text = "that", Type = WordType.Pronoun, ExerciseId = 111 },
            new { Number = 7, Text = "more", Type = WordType.Adverb, ExerciseId = 111 },
            new { Number = 8, Text = "and", Type = WordType.Preposition, ExerciseId = 111 },
            new { Number = 9, Text = "more", Type = WordType.Adverb, ExerciseId = 111 },
            new { Number = 10, Text = "people", Type = WordType.Noun, ExerciseId = 111 },
            new { Number = 11, Text = "lose", Type = WordType.Verb, ExerciseId = 111 },
            new { Number = 12, Text = "their", Type = WordType.Pronoun, ExerciseId = 111 },
            new { Number = 13, Text = "jobs.", Type = WordType.Noun, ExerciseId = 111 },

            new { Number = 1, Text = "Exhausted,", Type = WordType.Verb, ExerciseId = 112 },
            new { Number = 2, Text = "he", Type = WordType.Pronoun, ExerciseId = 112 },
            new { Number = 3, Text = "fell", Type = WordType.Verb, ExerciseId = 112 },
            new { Number = 4, Text = "asleep.", Type = WordType.Adjective, ExerciseId = 112 },

            new { Number = 1, Text = "The", Type = WordType.Determiner, ExerciseId = 113 },
            new { Number = 2, Text = "appliance", Type = WordType.Noun, ExerciseId = 113 },
            new { Number = 3, Text = "bought", Type = WordType.Verb, ExerciseId = 113 },
            new { Number = 4, Text = "from", Type = WordType.Preposition, ExerciseId = 113 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 113 },
            new { Number = 6, Text = "specialized", Type = WordType.Adjective, ExerciseId = 113 },
            new { Number = 7, Text = "shop", Type = WordType.Noun, ExerciseId = 113 },
            new { Number = 8, Text = "has", Type = WordType.PrimaryVerb, ExerciseId = 113 },
            new { Number = 9, Text = "a", Type = WordType.Determiner, ExerciseId = 113 },
            new { Number = 10, Text = "guarantee.", Type = WordType.Noun, ExerciseId = 113 },

            new { Number = 1, Text = "They", Type = WordType.Pronoun, ExerciseId = 114 },
            new { Number = 2, Text = "could not", Type = WordType.ModalVerb, ExerciseId = 114 },
            new { Number = 3, Text = "recover", Type = WordType.Verb, ExerciseId = 114 },
            new { Number = 4, Text = "from", Type = WordType.Preposition, ExerciseId = 114 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 114 },
            new { Number = 6, Text = "lost", Type = WordType.Verb, ExerciseId = 114 },
            new { Number = 7, Text = "war.", Type = WordType.Noun, ExerciseId = 114 },

            new { Number = 1, Text = "After", Type = WordType.Preposition, ExerciseId = 115 },
            new { Number = 2, Text = "computer", Type = WordType.Noun, ExerciseId = 115 },
            new { Number = 3, Text = "breaking", Type = WordType.Verb, ExerciseId = 115 },
            new { Number = 4, Text = "down", Type = WordType.Preposition, ExerciseId = 115 },
            new { Number = 5, Text = "we", Type = WordType.Pronoun, ExerciseId = 115 },
            new { Number = 6, Text = "could not", Type = WordType.ModalVerb, ExerciseId = 115 },
            new { Number = 7, Text = "restore", Type = WordType.Verb, ExerciseId = 115 },
            new { Number = 8, Text = "the", Type = WordType.Determiner, ExerciseId = 115 },
            new { Number = 9, Text = "lost", Type = WordType.Verb, ExerciseId = 115 },
            new { Number = 10, Text = "data.", Type = WordType.Noun, ExerciseId = 115 },

            #endregion

            #region Lesson 26

            new { Number = 1, Text = "Having", Type = WordType.PrimaryVerb, ExerciseId = 116 },
            new { Number = 2, Text = "bought", Type = WordType.Verb, ExerciseId = 116 },
            new { Number = 3, Text = "some", Type = WordType.Adverb, ExerciseId = 116 },
            new { Number = 4, Text = "new", Type = WordType.Adjective, ExerciseId = 116 },
            new { Number = 5, Text = "clothes", Type = WordType.Noun, ExerciseId = 116 },
            new { Number = 6, Text = "she", Type = WordType.Pronoun, ExerciseId = 116 },
            new { Number = 7, Text = "felt", Type = WordType.Verb, ExerciseId = 116 },
            new { Number = 8, Text = "much", Type = WordType.Adverb, ExerciseId = 116 },
            new { Number = 9, Text = "better.", Type = WordType.ComparisonAdjective, ExerciseId = 116 },

            new { Number = 1, Text = "Having", Type = WordType.PrimaryVerb, ExerciseId = 117 },
            new { Number = 2, Text = "looked", Type = WordType.Verb, ExerciseId = 117 },
            new { Number = 3, Text = "through", Type = WordType.Preposition, ExerciseId = 117 },
            new { Number = 4, Text = "a", Type = WordType.Determiner, ExerciseId = 117 },
            new { Number = 5, Text = "lot", Type = WordType.Adverb, ExerciseId = 117 },
            new { Number = 6, Text = "of", Type = WordType.Preposition, ExerciseId = 117 },
            new { Number = 7, Text = "journals", Type = WordType.Noun, ExerciseId = 117 },
            new { Number = 8, Text = "and", Type = WordType.Preposition, ExerciseId = 117 },
            new { Number = 9, Text = "papers", Type = WordType.Noun, ExerciseId = 117 },
            new { Number = 10, Text = "he", Type = WordType.Pronoun, ExerciseId = 117 },
            new { Number = 11, Text = "began", Type = WordType.Verb, ExerciseId = 117 },
            new { Number = 12, Text = "to", Type = WordType.Preposition, ExerciseId = 117 },
            new { Number = 13, Text = "write", Type = WordType.Verb, ExerciseId = 117 },
            new { Number = 14, Text = "his", Type = WordType.Pronoun, ExerciseId = 117 },
            new { Number = 15, Text = "report.", Type = WordType.Noun, ExerciseId = 117 },

            new { Number = 1, Text = "Having", Type = WordType.PrimaryVerb, ExerciseId = 118 },
            new { Number = 2, Text = "taken", Type = WordType.Verb, ExerciseId = 118 },
            new { Number = 3, Text = "my", Type = WordType.Pronoun, ExerciseId = 118 },
            new { Number = 4, Text = "advice", Type = WordType.Noun, ExerciseId = 118 },
            new { Number = 5, Text = "she", Type = WordType.Pronoun, ExerciseId = 118 },
            new { Number = 6, Text = "followed", Type = WordType.Verb, ExerciseId = 118 },
            new { Number = 7, Text = "it.", Type = WordType.Pronoun, ExerciseId = 118 },

            new { Number = 1, Text = "Having", Type = WordType.PrimaryVerb, ExerciseId = 119 },
            new { Number = 2, Text = "paid", Type = WordType.Verb, ExerciseId = 119 },
            new { Number = 3, Text = "the", Type = WordType.Determiner, ExerciseId = 119 },
            new { Number = 4, Text = "fine", Type = WordType.Noun, ExerciseId = 119 },
            new { Number = 5, Text = "he", Type = WordType.Pronoun, ExerciseId = 119 },
            new { Number = 6, Text = "did not", Type = WordType.PrimaryVerb, ExerciseId = 119 },
            new { Number = 7, Text = "break", Type = WordType.Verb, ExerciseId = 119 },
            new { Number = 8, Text = "the", Type = WordType.Determiner, ExerciseId = 119 },
            new { Number = 9, Text = "law", Type = WordType.Noun, ExerciseId = 119 },
            new { Number = 10, Text = "again.", Type = WordType.Adverb, ExerciseId = 119 },

            new { Number = 1, Text = "Having", Type = WordType.PrimaryVerb, ExerciseId = 120 },
            new { Number = 2, Text = "sought", Type = WordType.Verb, ExerciseId = 120 },
            new { Number = 3, Text = "the", Type = WordType.Determiner, ExerciseId = 120 },
            new { Number = 4, Text = "flat", Type = WordType.Noun, ExerciseId = 120 },
            new { Number = 5, Text = "they", Type = WordType.Pronoun, ExerciseId = 120 },
            new { Number = 6, Text = "found", Type = WordType.Verb, ExerciseId = 120 },
            new { Number = 7, Text = "no", Type = WordType.Adverb, ExerciseId = 120 },
            new { Number = 8, Text = "evidence.", Type = WordType.Noun, ExerciseId = 120 },

            #endregion

            #region Lesson 28

            new { Number = 1, Text = "Is", Type = WordType.PrimaryVerb, ExerciseId = 121 },
            new { Number = 2, Text = "the", Type = WordType.Determiner, ExerciseId = 121 },
            new { Number = 3, Text = "office", Type = WordType.Noun, ExerciseId = 121 },
            new { Number = 4, Text = "cleaned", Type = WordType.Verb, ExerciseId = 121 },
            new { Number = 5, Text = "every", Type = WordType.Adverb, ExerciseId = 121 },
            new { Number = 6, Text = "day?", Type = WordType.Noun, ExerciseId = 121 },

            new { Number = 1, Text = "I", Type = WordType.Pronoun, ExerciseId = 122 },
            new { Number = 2, Text = "am", Type = WordType.PrimaryVerb, ExerciseId = 122 },
            new { Number = 3, Text = "invited", Type = WordType.Verb, ExerciseId = 122 },
            new { Number = 4, Text = "to", Type = WordType.Preposition, ExerciseId = 122 },
            new { Number = 5, Text = "a", Type = WordType.Determiner, ExerciseId = 122 },
            new { Number = 6, Text = "party.", Type = WordType.Noun, ExerciseId = 122 },

            new { Number = 1, Text = "He", Type = WordType.Pronoun, ExerciseId = 123 },
            new { Number = 2, Text = "was", Type = WordType.PrimaryVerb, ExerciseId = 123 },
            new { Number = 3, Text = "offered", Type = WordType.Verb, ExerciseId = 123 },
            new { Number = 4, Text = "a", Type = WordType.Determiner, ExerciseId = 123 },
            new { Number = 5, Text = "good", Type = WordType.Adjective, ExerciseId = 123 },
            new { Number = 6, Text = "job", Type = WordType.Noun, ExerciseId = 123 },
            new { Number = 7, Text = "at", Type = WordType.Preposition, ExerciseId = 123 },
            new { Number = 8, Text = "a", Type = WordType.Determiner, ExerciseId = 123 },
            new { Number = 9, Text = "large", Type = WordType.Adjective, ExerciseId = 123 },
            new { Number = 10, Text = "construction", Type = WordType.Adjective, ExerciseId = 123 },
            new { Number = 11, Text = "company.", Type = WordType.Noun, ExerciseId = 123 },

            new { Number = 1, Text = "Dinner", Type = WordType.Noun, ExerciseId = 124 },
            new { Number = 2, Text = "is", Type = WordType.PrimaryVerb, ExerciseId = 124 },
            new { Number = 3, Text = "served", Type = WordType.Verb, ExerciseId = 124 },
            new { Number = 4, Text = "after", Type = WordType.Preposition, ExerciseId = 124 },
            new { Number = 5, Text = "seven.", Type = WordType.LetterNumber, ExerciseId = 124 },

            new { Number = 1, Text = "He", Type = WordType.Pronoun, ExerciseId = 125 },
            new { Number = 2, Text = "was", Type = WordType.PrimaryVerb, ExerciseId = 125 },
            new { Number = 3, Text = "followed", Type = WordType.Verb, ExerciseId = 125 },
            new { Number = 4, Text = "by", Type = WordType.Preposition, ExerciseId = 125 },
            new { Number = 5, Text = "the", Type = WordType.Determiner, ExerciseId = 125 },
            new { Number = 6, Text = "police.", Type = WordType.Noun, ExerciseId = 125 },

            #endregion

            #region Lesson 29

            new { Number = 1, Text = "Was", Type = WordType.PrimaryVerb, ExerciseId = 126 },
            new { Number = 2, Text = "the", Type = WordType.Determiner, ExerciseId = 126 },
            new { Number = 3, Text = "question", Type = WordType.Noun, ExerciseId = 126 },
            new { Number = 4, Text = "being", Type = WordType.PrimaryVerb, ExerciseId = 126 },
            new { Number = 5, Text = "discussed", Type = WordType.Verb, ExerciseId = 126 },
            new { Number = 6, Text = "at", Type = WordType.Preposition, ExerciseId = 126 },
            new { Number = 7, Text = "seven", Type = WordType.LetterNumber, ExerciseId = 126 },
            new { Number = 8, Text = "o'clock?", Type = WordType.Adverb, ExerciseId = 126 },

            new { Number = 1, Text = "The", Type = WordType.Determiner, ExerciseId = 127 },
            new { Number = 2, Text = "room", Type = WordType.Noun, ExerciseId = 127 },
            new { Number = 3, Text = "is", Type = WordType.PrimaryVerb, ExerciseId = 127 },
            new { Number = 4, Text = "being", Type = WordType.PrimaryVerb, ExerciseId = 127 },
            new { Number = 5, Text = "cleaned", Type = WordType.Verb, ExerciseId = 127 },
            new { Number = 6, Text = "at", Type = WordType.Preposition, ExerciseId = 127 },
            new { Number = 7, Text = "this", Type = WordType.Pronoun, ExerciseId = 127 },
            new { Number = 8, Text = "moment.", Type = WordType.Noun, ExerciseId = 127 },

            new { Number = 1, Text = "He", Type = WordType.Pronoun, ExerciseId = 128 },
            new { Number = 2, Text = "is", Type = WordType.PrimaryVerb, ExerciseId = 128 },
            new { Number = 3, Text = "being", Type = WordType.PrimaryVerb, ExerciseId = 128 },
            new { Number = 4, Text = "examined", Type = WordType.Verb, ExerciseId = 128 },
            new { Number = 5, Text = "by", Type = WordType.Preposition, ExerciseId = 128 },
            new { Number = 6, Text = "the", Type = WordType.Determiner, ExerciseId = 128 },
            new { Number = 7, Text = "doctor", Type = WordType.Noun, ExerciseId = 128 },
            new { Number = 8, Text = "at", Type = WordType.Preposition, ExerciseId = 128 },
            new { Number = 9, Text = "the", Type = WordType.Determiner, ExerciseId = 128 },
            new { Number = 10, Text = "moment.", Type = WordType.Noun, ExerciseId = 128 },

            new { Number = 1, Text = "He", Type = WordType.Pronoun, ExerciseId = 129 },
            new { Number = 2, Text = "is not", Type = WordType.PrimaryVerb, ExerciseId = 129 },
            new { Number = 3, Text = "being", Type = WordType.PrimaryVerb, ExerciseId = 129 },
            new { Number = 4, Text = "followed", Type = WordType.Verb, ExerciseId = 129 },
            new { Number = 5, Text = "by", Type = WordType.Preposition, ExerciseId = 129 },
            new { Number = 6, Text = "the", Type = WordType.Determiner, ExerciseId = 129 },
            new { Number = 7, Text = "police", Type = WordType.Noun, ExerciseId = 129 },
            new { Number = 8, Text = "at", Type = WordType.Preposition, ExerciseId = 129 },
            new { Number = 9, Text = "the", Type = WordType.Determiner, ExerciseId = 129 },
            new { Number = 10, Text = "moment.", Type = WordType.Noun, ExerciseId = 129 },

            new { Number = 1, Text = "Is", Type = WordType.PrimaryVerb, ExerciseId = 130 },
            new { Number = 2, Text = "his", Type = WordType.Pronoun, ExerciseId = 130 },
            new { Number = 3, Text = "house", Type = WordType.Noun, ExerciseId = 130 },
            new { Number = 4, Text = "being", Type = WordType.PrimaryVerb, ExerciseId = 130 },
            new { Number = 5, Text = "built", Type = WordType.Verb, ExerciseId = 130 },
            new { Number = 6, Text = "now?", Type = WordType.Adverb, ExerciseId = 130 },

            #endregion

            #region Lesson 30

            new { Number = 1, Text = "Will", Type = WordType.PrimaryVerb, ExerciseId = 131 },
            new { Number = 2, Text = "this", Type = WordType.Pronoun, ExerciseId = 131 },
            new { Number = 3, Text = "book", Type = WordType.Noun, ExerciseId = 131 },
            new { Number = 4, Text = "have", Type = WordType.PrimaryVerb, ExerciseId = 131 },
            new { Number = 5, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 131 },
            new { Number = 6, Text = "read", Type = WordType.Verb, ExerciseId = 131 },
            new { Number = 7, Text = "by", Type = WordType.Preposition, ExerciseId = 131 },
            new { Number = 8, Text = "two", Type = WordType.LetterNumber, ExerciseId = 131 },
            new { Number = 9, Text = "o'clock", Type = WordType.Adverb, ExerciseId = 131 },
            new { Number = 10, Text = "tomorrow?", Type = WordType.Adverb, ExerciseId = 131 },

            new { Number = 1, Text = "This", Type = WordType.Pronoun, ExerciseId = 132 },
            new { Number = 2, Text = "book", Type = WordType.Noun, ExerciseId = 132 },
            new { Number = 3, Text = "has", Type = WordType.PrimaryVerb, ExerciseId = 132 },
            new { Number = 4, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 132 },
            new { Number = 5, Text = "read.", Type = WordType.Verb, ExerciseId = 132 },

            new { Number = 1, Text = "The", Type = WordType.Determiner, ExerciseId = 133 },
            new { Number = 2, Text = "message", Type = WordType.Noun, ExerciseId = 133 },
            new { Number = 3, Text = "had not", Type = WordType.PrimaryVerb, ExerciseId = 133 },
            new { Number = 4, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 133 },
            new { Number = 5, Text = "read", Type = WordType.Verb, ExerciseId = 133 },
            new { Number = 6, Text = "by", Type = WordType.Preposition, ExerciseId = 133 },
            new { Number = 7, Text = "two", Type = WordType.LetterNumber, ExerciseId = 133 },
            new { Number = 8, Text = "o'clock.", Type = WordType.Adverb, ExerciseId = 133 },

            new { Number = 1, Text = "She", Type = WordType.Pronoun, ExerciseId = 134 },
            new { Number = 2, Text = "has", Type = WordType.PrimaryVerb, ExerciseId = 134 },
            new { Number = 3, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 134 },
            new { Number = 4, Text = "invited", Type = WordType.Verb, ExerciseId = 134 },
            new { Number = 5, Text = "to", Type = WordType.Preposition, ExerciseId = 134 },
            new { Number = 6, Text = "the", Type = WordType.Determiner, ExerciseId = 134 },
            new { Number = 7, Text = "restaurant.", Type = WordType.Noun, ExerciseId = 134 },

            new { Number = 1, Text = "Have", Type = WordType.PrimaryVerb, ExerciseId = 135 },
            new { Number = 2, Text = "the", Type = WordType.Determiner, ExerciseId = 135 },
            new { Number = 3, Text = "books", Type = WordType.Noun, ExerciseId = 135 },
            new { Number = 4, Text = "been", Type = WordType.PrimaryVerb, ExerciseId = 135 },
            new { Number = 5, Text = "sold?", Type = WordType.Verb, ExerciseId = 135 },

            #endregion

        ];

        return words;
    }

    private static object[] GetLessonExercises()
    {
        object[] lessonExercises =
        [
            new { LessonId = 1, ExerciseId = 1 },
            new { LessonId = 1, ExerciseId = 2 },
            new { LessonId = 1, ExerciseId = 3 },
            new { LessonId = 1, ExerciseId = 4 },
            new { LessonId = 1, ExerciseId = 5 },
            new { LessonId = 2, ExerciseId = 6 },
            new { LessonId = 2, ExerciseId = 7 },
            new { LessonId = 2, ExerciseId = 8 },
            new { LessonId = 2, ExerciseId = 9 },
            new { LessonId = 2, ExerciseId = 10 },
            new { LessonId = 3, ExerciseId = 11 },
            new { LessonId = 3, ExerciseId = 12 },
            new { LessonId = 3, ExerciseId = 13 },
            new { LessonId = 3, ExerciseId = 14 },
            new { LessonId = 3, ExerciseId = 15 },
            new { LessonId = 4, ExerciseId = 16 },
            new { LessonId = 4, ExerciseId = 17 },
            new { LessonId = 4, ExerciseId = 18 },
            new { LessonId = 4, ExerciseId = 19 },
            new { LessonId = 4, ExerciseId = 20 },
            new { LessonId = 5, ExerciseId = 21 },
            new { LessonId = 5, ExerciseId = 22 },
            new { LessonId = 5, ExerciseId = 23 },
            new { LessonId = 5, ExerciseId = 24 },
            new { LessonId = 5, ExerciseId = 25 },
            new { LessonId = 6, ExerciseId = 26 },
            new { LessonId = 6, ExerciseId = 27 },
            new { LessonId = 6, ExerciseId = 28 },
            new { LessonId = 6, ExerciseId = 29 },
            new { LessonId = 6, ExerciseId = 30 },
            new { LessonId = 7, ExerciseId = 31 },
            new { LessonId = 7, ExerciseId = 32 },
            new { LessonId = 7, ExerciseId = 33 },
            new { LessonId = 7, ExerciseId = 34 },
            new { LessonId = 7, ExerciseId = 35 },
            new { LessonId = 8, ExerciseId = 36 },
            new { LessonId = 8, ExerciseId = 37 },
            new { LessonId = 8, ExerciseId = 38 },
            new { LessonId = 8, ExerciseId = 39 },
            new { LessonId = 8, ExerciseId = 40 },
            new { LessonId = 9, ExerciseId = 41 },
            new { LessonId = 9, ExerciseId = 42 },
            new { LessonId = 9, ExerciseId = 43 },
            new { LessonId = 9, ExerciseId = 44 },
            new { LessonId = 9, ExerciseId = 45 },
            new { LessonId = 10, ExerciseId = 46 },
            new { LessonId = 10, ExerciseId = 47 },
            new { LessonId = 10, ExerciseId = 48 },
            new { LessonId = 10, ExerciseId = 49 },
            new { LessonId = 10, ExerciseId = 50 },
            new { LessonId = 11, ExerciseId = 51 },
            new { LessonId = 11, ExerciseId = 52 },
            new { LessonId = 11, ExerciseId = 53 },
            new { LessonId = 11, ExerciseId = 54 },
            new { LessonId = 11, ExerciseId = 55 },
            new { LessonId = 12, ExerciseId = 56 },
            new { LessonId = 12, ExerciseId = 57 },
            new { LessonId = 12, ExerciseId = 58 },
            new { LessonId = 12, ExerciseId = 59 },
            new { LessonId = 12, ExerciseId = 60 },
            new { LessonId = 13, ExerciseId = 61 },
            new { LessonId = 13, ExerciseId = 62 },
            new { LessonId = 13, ExerciseId = 63 },
            new { LessonId = 13, ExerciseId = 64 },
            new { LessonId = 13, ExerciseId = 65 },
            new { LessonId = 14, ExerciseId = 66 },
            new { LessonId = 14, ExerciseId = 67 },
            new { LessonId = 14, ExerciseId = 68 },
            new { LessonId = 14, ExerciseId = 69 },
            new { LessonId = 14, ExerciseId = 70 },
            new { LessonId = 15, ExerciseId = 71 },
            new { LessonId = 15, ExerciseId = 72 },
            new { LessonId = 15, ExerciseId = 73 },
            new { LessonId = 15, ExerciseId = 74 },
            new { LessonId = 15, ExerciseId = 75 },
            new { LessonId = 16, ExerciseId = 76 },
            new { LessonId = 16, ExerciseId = 77 },
            new { LessonId = 16, ExerciseId = 78 },
            new { LessonId = 16, ExerciseId = 79 },
            new { LessonId = 16, ExerciseId = 80 },
            new { LessonId = 17, ExerciseId = 81 },
            new { LessonId = 17, ExerciseId = 82 },
            new { LessonId = 17, ExerciseId = 83 },
            new { LessonId = 17, ExerciseId = 84 },
            new { LessonId = 17, ExerciseId = 85 },
            new { LessonId = 18, ExerciseId = 86 },
            new { LessonId = 18, ExerciseId = 87 },
            new { LessonId = 18, ExerciseId = 88 },
            new { LessonId = 18, ExerciseId = 89 },
            new { LessonId = 18, ExerciseId = 90 },
            new { LessonId = 19, ExerciseId = 76 },
            new { LessonId = 19, ExerciseId = 77 },
            new { LessonId = 19, ExerciseId = 78 },
            new { LessonId = 19, ExerciseId = 79 },
            new { LessonId = 19, ExerciseId = 80 },
            new { LessonId = 19, ExerciseId = 81 },
            new { LessonId = 19, ExerciseId = 82 },
            new { LessonId = 19, ExerciseId = 83 },
            new { LessonId = 19, ExerciseId = 84 },
            new { LessonId = 19, ExerciseId = 85 },
            new { LessonId = 19, ExerciseId = 86 },
            new { LessonId = 19, ExerciseId = 87 },
            new { LessonId = 19, ExerciseId = 88 },
            new { LessonId = 19, ExerciseId = 89 },
            new { LessonId = 19, ExerciseId = 90 },
            new { LessonId = 20, ExerciseId = 91 },
            new { LessonId = 20, ExerciseId = 92 },
            new { LessonId = 20, ExerciseId = 93 },
            new { LessonId = 20, ExerciseId = 94 },
            new { LessonId = 20, ExerciseId = 95 },
            new { LessonId = 21, ExerciseId = 96 },
            new { LessonId = 21, ExerciseId = 97 },
            new { LessonId = 21, ExerciseId = 98 },
            new { LessonId = 21, ExerciseId = 99 },
            new { LessonId = 21, ExerciseId = 100 },
            new { LessonId = 22, ExerciseId = 101 },
            new { LessonId = 22, ExerciseId = 102 },
            new { LessonId = 22, ExerciseId = 103 },
            new { LessonId = 22, ExerciseId = 104 },
            new { LessonId = 22, ExerciseId = 105 },
            new { LessonId = 23, ExerciseId = 91 },
            new { LessonId = 23, ExerciseId = 92 },
            new { LessonId = 23, ExerciseId = 93 },
            new { LessonId = 23, ExerciseId = 94 },
            new { LessonId = 23, ExerciseId = 95 },
            new { LessonId = 23, ExerciseId = 96 },
            new { LessonId = 23, ExerciseId = 97 },
            new { LessonId = 23, ExerciseId = 98 },
            new { LessonId = 23, ExerciseId = 99 },
            new { LessonId = 23, ExerciseId = 100 },
            new { LessonId = 23, ExerciseId = 101 },
            new { LessonId = 23, ExerciseId = 102 },
            new { LessonId = 23, ExerciseId = 103 },
            new { LessonId = 23, ExerciseId = 104 },
            new { LessonId = 23, ExerciseId = 105 },
            new { LessonId = 24, ExerciseId = 106 },
            new { LessonId = 24, ExerciseId = 107 },
            new { LessonId = 24, ExerciseId = 108 },
            new { LessonId = 24, ExerciseId = 109 },
            new { LessonId = 24, ExerciseId = 110 },
            new { LessonId = 25, ExerciseId = 111 },
            new { LessonId = 25, ExerciseId = 112 },
            new { LessonId = 25, ExerciseId = 113 },
            new { LessonId = 25, ExerciseId = 114 },
            new { LessonId = 25, ExerciseId = 115 },
            new { LessonId = 26, ExerciseId = 116 },
            new { LessonId = 26, ExerciseId = 117 },
            new { LessonId = 26, ExerciseId = 118 },
            new { LessonId = 26, ExerciseId = 119 },
            new { LessonId = 26, ExerciseId = 120 },
            new { LessonId = 27, ExerciseId = 106 },
            new { LessonId = 27, ExerciseId = 107 },
            new { LessonId = 27, ExerciseId = 108 },
            new { LessonId = 27, ExerciseId = 109 },
            new { LessonId = 27, ExerciseId = 110 },
            new { LessonId = 27, ExerciseId = 111 },
            new { LessonId = 27, ExerciseId = 112 },
            new { LessonId = 27, ExerciseId = 113 },
            new { LessonId = 27, ExerciseId = 114 },
            new { LessonId = 27, ExerciseId = 115 },
            new { LessonId = 27, ExerciseId = 116 },
            new { LessonId = 27, ExerciseId = 117 },
            new { LessonId = 27, ExerciseId = 118 },
            new { LessonId = 27, ExerciseId = 119 },
            new { LessonId = 27, ExerciseId = 120 },
            new { LessonId = 28, ExerciseId = 121 },
            new { LessonId = 28, ExerciseId = 122 },
            new { LessonId = 28, ExerciseId = 123 },
            new { LessonId = 28, ExerciseId = 124 },
            new { LessonId = 28, ExerciseId = 125 },
            new { LessonId = 29, ExerciseId = 126 },
            new { LessonId = 29, ExerciseId = 127 },
            new { LessonId = 29, ExerciseId = 128 },
            new { LessonId = 29, ExerciseId = 129 },
            new { LessonId = 29, ExerciseId = 130 },
            new { LessonId = 30, ExerciseId = 131 },
            new { LessonId = 30, ExerciseId = 132 },
            new { LessonId = 30, ExerciseId = 133 },
            new { LessonId = 30, ExerciseId = 134 },
            new { LessonId = 30, ExerciseId = 135 },
            new { LessonId = 31, ExerciseId = 121 },
            new { LessonId = 31, ExerciseId = 122 },
            new { LessonId = 31, ExerciseId = 123 },
            new { LessonId = 31, ExerciseId = 124 },
            new { LessonId = 31, ExerciseId = 125 },
            new { LessonId = 31, ExerciseId = 126 },
            new { LessonId = 31, ExerciseId = 127 },
            new { LessonId = 31, ExerciseId = 128 },
            new { LessonId = 31, ExerciseId = 129 },
            new { LessonId = 31, ExerciseId = 130 },
            new { LessonId = 31, ExerciseId = 131 },
            new { LessonId = 31, ExerciseId = 132 },
            new { LessonId = 31, ExerciseId = 133 },
            new { LessonId = 31, ExerciseId = 134 },
            new { LessonId = 31, ExerciseId = 135 }
        ];

        return lessonExercises;
    }

    private static object[] GetExercises()
    {
        object[] exercises =
        [
            new { Id = 1, RusPhrase = "Ты не увидишь." },
            new { Id = 2, RusPhrase = "Мы покажем?" },
            new { Id = 3, RusPhrase = "Она работала?" },
            new { Id = 4, RusPhrase = "Ты не думал." },
            new { Id = 5, RusPhrase = "Я посмотрю?" },
            new { Id = 6, RusPhrase = "Мы не оставили его." },
            new { Id = 7, RusPhrase = "Он поймёт тебя." },
            new { Id = 8, RusPhrase = "Ты открываешь ей." },
            new { Id = 9, RusPhrase = "Я сломаю?" },
            new { Id = 10, RusPhrase = "Я показал им?" },
            new { Id = 11, RusPhrase = "Тебе хочется пить?" },
            new { Id = 12, RusPhrase = "Ей хотелось забывать?" },
            new { Id = 13, RusPhrase = "Я был в музее." },
            new { Id = 14, RusPhrase = "Ей не нравилось показывать." },
            new { Id = 15, RusPhrase = "Она в лифте?" },
            new { Id = 16, RusPhrase = "Он будет их актёром?" },
            new { Id = 17, RusPhrase = "Мы не их бухгалтеры." },
            new { Id = 18, RusPhrase = "Мы были его историками." },
            new { Id = 19, RusPhrase = "Он будет её писателем." },
            new { Id = 20, RusPhrase = "Мы не будем их гидами." },
            new { Id = 21, RusPhrase = "Они учатся на гидов?" },
            new { Id = 22, RusPhrase = "Я не буду менеджером." },
            new { Id = 23, RusPhrase = "Мы учились на менеджеров." },
            new { Id = 24, RusPhrase = "Они работали в компании дизайнерами?" },
            new { Id = 25, RusPhrase = "Ты историк." },
            new { Id = 26, RusPhrase = "Эта ручка не больше той." },
            new { Id = 27, RusPhrase = "Этот телевизор не дорогой." },
            new { Id = 28, RusPhrase = "Этот телефон дешевле того?" },
            new { Id = 29, RusPhrase = "Эта ручка длиннее той." },
            new { Id = 30, RusPhrase = "Эти апельсины самые маленькие?" },
            new { Id = 31, RusPhrase = "Мы будем читать кому-нибудь." },
            new { Id = 32, RusPhrase = "Они чувствуют везде?" },
            new { Id = 33, RusPhrase = "Ты встречаешь везде?" },
            new { Id = 34, RusPhrase = "Он будет знать всех?" },
            new { Id = 35, RusPhrase = "Он никогда не видит." },
            new { Id = 36, RusPhrase = "Она не повернула нас 6 месяцев назад." },
            new { Id = 37, RusPhrase = "Он будет расти через 2 месяца?" },
            new { Id = 38, RusPhrase = "Я расскажу тебе через 6 месяцев." },
            new { Id = 39, RusPhrase = "Ты будешь там через 6 месяцев?" },
            new { Id = 40, RusPhrase = "Она любила их в выходные?" },
            new { Id = 41, RusPhrase = "На полу не было ручек." },
            new { Id = 42, RusPhrase = "Под столом есть ножи." },
            new { Id = 43, RusPhrase = "Под креслом будет мяч." },
            new { Id = 44, RusPhrase = "На столе нет ручки." },
            new { Id = 45, RusPhrase = "Под креслом был стакан?" },
            new { Id = 46, RusPhrase = "Он идёт на станцию?" },
            new { Id = 47, RusPhrase = "Ты не выйдешь из сада." },
            new { Id = 48, RusPhrase = "В комнате не будет шкафов." },
            new { Id = 49, RusPhrase = "На подоконнике будет чашка." },
            new { Id = 50, RusPhrase = "Под столом были стаканы?" },
            new { Id = 51, RusPhrase = "Мы не должны чувствовать." },
            new { Id = 52, RusPhrase = "Нужно мне стоять?" },
            new { Id = 53, RusPhrase = "Мы можем закрыть." },
            new { Id = 54, RusPhrase = "Мы не показали." },
            new { Id = 55, RusPhrase = "Она не должна ответить." },
            new { Id = 56, RusPhrase = "Он читал письмо с 4 до 10 вчера." },
            new { Id = 57, RusPhrase = "Мы отвечали на письмо в 4 вчера." },
            new { Id = 58, RusPhrase = "Ты чувствуешь себя плохо целый день сегодня." },
            new { Id = 59, RusPhrase = "Мы изучали французский целый день вчера." },
            new { Id = 60, RusPhrase = "Ты будешь читать книгу целый день завтра." },
            new { Id = 61, RusPhrase = "Мне холодно?" },
            new { Id = 62, RusPhrase = "У меня не голубые глаза." },
            new { Id = 63, RusPhrase = "Ты здоров." },
            new { Id = 64, RusPhrase = "Вчера было жарко." },
            new { Id = 65, RusPhrase = "Она взрослая." },
            new { Id = 66, RusPhrase = "Беги к ней." },
            new { Id = 67, RusPhrase = "Не поворачивай его тумбочку." },
            new { Id = 68, RusPhrase = "Не бери мой планшет." },
            new { Id = 69, RusPhrase = "Помни про нас." },
            new { Id = 70, RusPhrase = "Пусть он ответит." },
            new { Id = 71, RusPhrase = "Он сбросил вес." },
            new { Id = 72, RusPhrase = "Твой сын просит выключить свет." },
            new { Id = 73, RusPhrase = "Он свалился с пневмонией." },
            new { Id = 74, RusPhrase = "Он взломал дверь." },
            new { Id = 75, RusPhrase = "Цены никогда не падают." },
            new { Id = 76, RusPhrase = "Он только что вышел." },
            new { Id = 77, RusPhrase = "Думаю, что я видел вас где-то." },
            new { Id = 78, RusPhrase = "Я выполнил работу." },
            new { Id = 79, RusPhrase = "Я уже написал письмо своему другу." },
            new { Id = 80, RusPhrase = "Он только что посетил этот супермаркет." },
            new { Id = 81, RusPhrase = "Я не успел закончить проект к началу той недели." },
            new { Id = 82, RusPhrase = "Он сделал домашнее задание до того, как его родители вернулись домой?" },
            new { Id = 83, RusPhrase = "Он уже написал письмо, когда ты вошел?" },
            new { Id = 84, RusPhrase = "Вы вернулись домой до того, как начался дождь." },
            new { Id = 85, RusPhrase = "Когда мы приехали на станцию, поезд уже ушел." },
            new { Id = 86, RusPhrase = "Ученики займут свои места до того, как начнется урок." },
            new { Id = 87, RusPhrase = "Они не успеют выиграть три игры к концу месяца." },
            new { Id = 88, RusPhrase = "Я уже окончу эту работу до того, как вы возвратитесь." },
            new { Id = 89, RusPhrase = "Они еще не отгрузят товар, когда придет ваша телеграмма." },
            new { Id = 90, RusPhrase = "Я не закончу писать доклад к вечеру." },
            new { Id = 91, RusPhrase = "Она готовит ужин уже три часа." },
            new { Id = 92, RusPhrase = "Я пекла этот пирог с самого утра." },
            new { Id = 93, RusPhrase = "Рабочие пытаются сдвинуть наш шкаф с места вот уже полчаса." },
            new { Id = 94, RusPhrase = "Я читаю этот журнал с тех пор, как купил его неделю назад." },
            new { Id = 95, RusPhrase = "Я жду свою маму уже давно." },
            new { Id = 96, RusPhrase = "С теп пор показатель быстро рос." },
            new { Id = 97, RusPhrase = "Его руки были грязные, он копал." },
            new { Id = 98, RusPhrase = "Они разговаривали больше часа, до того, как он пришел." },
            new { Id = 99, RusPhrase = "Был час ночи, а соседская собака лаяла уже 2 часа." },
            new { Id = 100, RusPhrase = "Моя собака играла уже полчаса перед тем, как мы пошли гулять." },
            new { Id = 101, RusPhrase = "Они будут разговаривать уже свыше часа, к тому моменту, когда приедет он." },
            new { Id = 102, RusPhrase = "К первому июня он будет работать на этом заводе уже двадцать лет." },
            new { Id = 103, RusPhrase = "К следующему рождеству я уже буду преподавать 10 лет." },
            new { Id = 104, RusPhrase = "Ты будешь ждать свыше двух часов, прежде чем ее самолет, наконец, приземлится?" },
            new { Id = 105, RusPhrase = "В следующем месяце мы будем жить вместе уже 15 лет." },
            new { Id = 106, RusPhrase = "Они будут разговаривать уже свыше часа, к тому моменту, когда приедет он." },
            new { Id = 107, RusPhrase = "К первому июня он будет работать на этом заводе уже двадцать лет." },
            new { Id = 108, RusPhrase = "К следующему рождеству я уже буду преподавать 10 лет." },
            new { Id = 109, RusPhrase = "Ты будешь ждать свыше двух часов, прежде чем ее самолет, наконец, приземлится?" },
            new { Id = 110, RusPhrase = "В следующем месяце мы будем жить вместе уже 15 лет." },
            new { Id = 111, RusPhrase = "Я был разочарован услышать, что все больше и больше людей теряют свою работу." },
            new { Id = 112, RusPhrase = "Измученный, он провалился в сон." },
            new { Id = 113, RusPhrase = "Прибор, купленный в специализированном магазине, имеет гарантию." },
            new { Id = 114, RusPhrase = "Они не смогли оправиться от проигранной войны." },
            new { Id = 115, RusPhrase = "После компьютерного сбоя мы не смогли восстановить потерянные данные." },
            new { Id = 116, RusPhrase = "Купив немного новой одежды, она почувствовала себя намного лучше." },
            new { Id = 117, RusPhrase = "Посмотрев много журналов и газет, он начал писать свой доклад." },
            new { Id = 118, RusPhrase = "Приняв мой совет, она последовала ему." },
            new { Id = 119, RusPhrase = "Заплатив штраф, он больше не нарушал закон." },
            new { Id = 120, RusPhrase = "Обыскав квартиру, они не не нашли никаких доказательств." },
            new { Id = 121, RusPhrase = "Офис убирают каждый день?" },
            new { Id = 122, RusPhrase = "Я приглашён на вечеринку." },
            new { Id = 123, RusPhrase = "Ему предложили хорошую работу в большой строительной компании." },
            new { Id = 124, RusPhrase = "Ужин подается после семи." },
            new { Id = 125, RusPhrase = "Его преследовала полиция." },
            new { Id = 126, RusPhrase = "Вопрос обсуждался в семь часов?" },
            new { Id = 127, RusPhrase = "Комнату в этот момент моют." },
            new { Id = 128, RusPhrase = "Его осматривает доктор в настоящий момент." },
            new { Id = 129, RusPhrase = "Его не преследует полиция в данный момент." },
            new { Id = 130, RusPhrase = "Его дом строится сейчас?" },
            new { Id = 131, RusPhrase = "Эта книга уже будет прочитана завтра к 2 часам?" },
            new { Id = 132, RusPhrase = "Эта книга уже прочитана." },
            new { Id = 133, RusPhrase = "Сообщение еще не было прочитано к двум часам." },
            new { Id = 134, RusPhrase = "Ее уже пригласили в ресторан." },
            new { Id = 135, RusPhrase = "Книги уже распроданы?" }
        ];

        return exercises;
    }

    private static object[] GetLessons()
    {
        object[] lessons =
        [
            new { Id = 1, Name = "Базовая форма глагола" },
            new { Id = 2, Name = "Местоимения. Вопросительные слова" },
            new { Id = 3, Name = "Глагол to be. Предлоги места. Like/Want" },
            new { Id = 4, Name = "Притяжательные местоимения" },
            new { Id = 5, Name = "Профессии. Этикет" },
            new { Id = 6, Name = "Степени сравнения прилагательных. Указательные местоимения" },
            new { Id = 7, Name = "Слова-параметры. Употребление muck и many, little и few" },
            new { Id = 8, Name = "Предлоги и параметры времени" },
            new { Id = 9, Name = "There is / There are" },
            new { Id = 10, Name = "Предлоги направления и движения" },
            new { Id = 11, Name = "Модальные глаголы can, must, should" },
            new { Id = 12, Name = "Continuous" },
            new { Id = 13, Name = "Описание людей. Погода" },
            new { Id = 14, Name = "Повелительное наклонение" },
            new { Id = 15, Name = "Фразовые глаголы" },
            new { Id = 16, Name = "Present Perfect" },
            new { Id = 17, Name = "Past Perfect" },
            new { Id = 18, Name = "Future Perfect" },
            new { Id = 19, Name = "Perfect Tenses" },
            new { Id = 20, Name = "Present Perfect Continuous" },
            new { Id = 21, Name = "Past Perfect Continuous" },
            new { Id = 22, Name = "Future Perfect Continuous" },
            new { Id = 23, Name = "Perfect Continuous Tenses" },
            new { Id = 24, Name = "Present Participle Simple" },
            new { Id = 25, Name = "Past Participle" },
            new { Id = 26, Name = "Present Participle Perfect" },
            new { Id = 27, Name = "The Participle" },
            new { Id = 28, Name = "Simple Passive" },
            new { Id = 29, Name = "Continuous Passive" },
            new { Id = 30, Name = "Perfect Passive" },
            new { Id = 31, Name = "Passive Voice" },
        ];

        return lessons;
    }
}
