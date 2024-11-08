using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Application.Exercises.GetExercise;

namespace Polyglot.Application.Exercises.GetRandomExercise;

public record GetRandomExerciseQuery(int LessonId) : IQuery<ExerciseResponse>;
