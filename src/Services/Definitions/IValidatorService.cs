using src.Custom;

namespace src.Services.Definitions;

public interface IValidatorService
{
    public bool Validate(ValidateInputRequest request);
}