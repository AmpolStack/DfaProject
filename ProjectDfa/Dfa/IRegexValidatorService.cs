using ProjectDfa.Custom;

namespace ProjectDfa.Dfa;

public interface IRegexValidatorService
{
    public bool Validate(ValidateInputRequest request);
}