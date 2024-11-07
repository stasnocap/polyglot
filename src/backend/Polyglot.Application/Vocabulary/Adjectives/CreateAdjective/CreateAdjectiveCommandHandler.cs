using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary;
using Polyglot.Domain.Vocabulary.Adjectives;

namespace Polyglot.Application.Vocabulary.Adjectives.CreateAdjective;

public class CreateAdjectiveCommandHandler(IAdjectiveRepository _adjectiveRepository,
    IUnitOfWork _unitOfWork) : ICommandHandler<CreateAdjectiveCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateAdjectiveCommand request, CancellationToken cancellationToken)
    {
        var text = new Text(request.Text);

        if (await _adjectiveRepository.ExistsAsync(text, cancellationToken))
        {
            return Result.Failure<Guid>(AdjectiveErrors.AlreadyExists);
        }
        
        var adjective = new Adjective(Guid.NewGuid(), text);

        _adjectiveRepository.Add(adjective);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return adjective.Id;
    }
}
