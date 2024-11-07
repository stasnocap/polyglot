using MediatR;
using Polyglot.Application.Abstractions.Messaging;

namespace Polyglot.Application.Lessons.GetLessons;

public record GetLessonsQuery(string? SearchTerm) : IQuery<IReadOnlyList<LessonResponse>>;
