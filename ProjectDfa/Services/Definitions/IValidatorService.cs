using ProjectDfa.Custom;

namespace ProjectDfa.Services.Definitions;

public interface IValidatorService
{
    public bool Validate(ValidateInputRequest request);
}