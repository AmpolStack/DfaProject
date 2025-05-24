namespace ProjectDfa.Custom;

public class ValidateInputRequest
{
    public required string Input { get; init; }
    public bool AllowNumbers { get; init; }
    public bool AllowLetters { get; init; }
    public bool AllowSpecials { get; init; }
}