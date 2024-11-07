using MediatR;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;

namespace Polyglot.Application.Exercises.GetExercise;

public record GetExerciseQuery(Guid ExerciseId, Guid LessonId) : IQuery<ExerciseResponse>;
