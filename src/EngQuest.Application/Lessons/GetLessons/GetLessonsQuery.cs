using EngQuest.Application.Abstractions.Messaging;
using MediatR;

namespace EngQuest.Application.Lessons.GetLessons;

public record GetLessonsQuery(string? SearchTerm) : IQuery<IReadOnlyList<LessonResponse>>;
