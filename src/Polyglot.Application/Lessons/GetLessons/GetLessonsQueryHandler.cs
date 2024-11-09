using Polyglot.Application.Abstractions.Authentication;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Lessons;

namespace Polyglot.Application.Lessons.GetLessons;

public class GetLessonsQueryHandler(ILessonRepository _lessonRepository, IUserContext _userContext) : IQueryHandler<GetLessonsQuery, IReadOnlyList<LessonResponse>>
{
    public async Task<Result<IReadOnlyList<LessonResponse>>> Handle(GetLessonsQuery request, CancellationToken cancellationToken)
    {
        int? currentUserId = _userContext.UserId;

        List<Lesson> lessons = await _lessonRepository.GetRangeAsync(currentUserId, request.SearchTerm, cancellationToken);

        return Result.Success<IReadOnlyList<LessonResponse>>(lessons.Select(l => new LessonResponse
        {
            Name = l.Name.Value,
            LessonId = l.Id
        }).ToList());
    }
}
