using ProjectDfa.Custom;

namespace ProjectDfa.Services;

public interface IValidatorService
{
    public bool Validate(ValidateInputRequest request);
}