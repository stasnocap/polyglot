using MediatR;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;

namespace Polyglot.Application.Exercises.CompleteExercise;

public record CompleteExerciseCommand(int ExerciseId, int LessonId, string Answer) : ICommand<bool>;
