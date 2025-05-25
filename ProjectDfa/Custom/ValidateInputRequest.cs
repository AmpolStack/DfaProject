namespace ProjectDfa.Custom;

public class ValidateInputRequest : ValidateInputBase
{
    public required string Input { get; init; }
    public bool AllowEmail { get; init; }
}