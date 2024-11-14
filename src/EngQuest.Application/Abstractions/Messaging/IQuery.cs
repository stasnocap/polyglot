using MediatR;
using EngQuest.Domain.Abstractions;

namespace EngQuest.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
