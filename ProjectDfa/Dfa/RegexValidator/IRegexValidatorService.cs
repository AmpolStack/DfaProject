using ProjectDfa.Custom;

namespace ProjectDfa.Dfa.RegexValidator;

public interface IRegexValidatorService
{
    public bool Validate(ValidateInputRequest request);
}