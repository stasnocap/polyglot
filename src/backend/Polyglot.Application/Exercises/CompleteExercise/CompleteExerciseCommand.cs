using MediatR;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;

namespace Polyglot.Application.Exercises.CompleteExercise;

public record CompleteExerciseCommand(Guid ExerciseId, Guid LessonId, string Answer) : ICommand<CompleteExerciseResponse>;
