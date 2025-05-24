namespace ProjectDfa.Custom;

public class RegexRequest
{
    public required string Input { get; set; }
    public bool AllowNumbers { get; set; }
    public bool AllowLetters { get; set; }
    public bool AllowSpecials { get; set; }
}