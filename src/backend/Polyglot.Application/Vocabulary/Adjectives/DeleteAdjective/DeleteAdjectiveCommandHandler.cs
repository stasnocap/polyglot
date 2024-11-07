using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Vocabulary;
using Polyglot.Domain.Vocabulary.Adjectives;

namespace Polyglot.Application.Vocabulary.Adjectives.DeleteAdjective;

public class DeleteAdjectiveCommandHandler(IAdjectiveRepository _repository, IUnitOfWork _unitOfWork) : ICommandHandler<DeleteAdjectiveCommand>
{
    public async Task<Result> Handle(DeleteAdjectiveCommand request, CancellationToken cancellationToken)
    {
        Adjective? adjective = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (adjective is null)
        {
            return Result.Failure(AdjectiveErrors.NotFound);
        }

        _repository.Delete(adjective);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}
