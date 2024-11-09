using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.Adjectives;

namespace Polyglot.Application.Vocabulary.Adjectives.UpdateAdjective;

public class UpdateAdjectiveCommandHandler(IAdjectiveRepository _repository, IUnitOfWork _unitOfWork) : ICommandHandler<UpdateAdjectiveCommand>
{
    public async Task<Result> Handle(UpdateAdjectiveCommand request, CancellationToken cancellationToken)
    {
        Adjective? adjective = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (adjective is null)
        {
            return Result.Failure(AdjectiveErrors.NotFound);
        }

        var text = new Text(request.Text);
        
        if (await _repository.ExistsAsync(text, cancellationToken))
        {
            return Result.Failure(AdjectiveErrors.AlreadyExists);
        }
        
        adjective.SetText(text);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}
