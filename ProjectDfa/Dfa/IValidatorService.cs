using ProjectDfa.Custom;

namespace ProjectDfa.Dfa;

public interface IValidatorService
{
    public bool Validate(ValidateInputRequest request);
}