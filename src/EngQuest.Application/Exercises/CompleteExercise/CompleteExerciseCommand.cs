using EngQuest.Application.Abstractions.Messaging;
using EngQuest.Domain.Lessons;

namespace EngQuest.Application.Exercises.CompleteExercise;

public record CompleteExerciseCommand(int ExerciseId, int LessonId, string Answer) : ICommand<CompleteExerciseResult>;
