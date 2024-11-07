using MediatR;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Application.Exercises.GetExercise;
using Polyglot.Domain.Abstractions;

namespace Polyglot.Application.Exercises.GetRandomExercise;

public record GetRandomExerciseQuery(Guid LessonId) : IQuery<ExerciseResponse>;
