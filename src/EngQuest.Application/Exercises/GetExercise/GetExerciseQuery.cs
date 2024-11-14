using EngQuest.Application.Abstractions.Messaging;

namespace EngQuest.Application.Exercises.GetExercise;

public record GetExerciseQuery(int ExerciseId, int LessonId) : IQuery<ExerciseResponse>;
