using Polyglot.Application.Abstractions.Messaging;

namespace Polyglot.Application.Exercises.GetExercise;

public record GetExerciseQuery(int ExerciseId, int LessonId) : IQuery<ExerciseResponse>;
