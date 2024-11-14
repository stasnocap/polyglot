using EngQuest.Application.Abstractions.Messaging;
using EngQuest.Application.Exercises.GetExercise;

namespace EngQuest.Application.Exercises.GetRandomExercise;

public record GetRandomExerciseQuery(int LessonId) : IQuery<ExerciseResponse>;
