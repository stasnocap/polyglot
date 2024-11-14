namespace EngQuest.Domain.Vocabulary.PrimaryVerbs;

public sealed record AdditionalForm(string Value)
{
    public static implicit operator string(AdditionalForm additionalForm) => additionalForm.Value;
};
