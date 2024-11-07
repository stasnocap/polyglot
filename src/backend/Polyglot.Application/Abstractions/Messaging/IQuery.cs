using MediatR;
using Polyglot.Domain.Abstractions;

namespace Polyglot.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
