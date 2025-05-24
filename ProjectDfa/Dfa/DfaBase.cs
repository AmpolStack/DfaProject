namespace ProjectDfa.Dfa;

public class DfaBase<T> where T : Enum
{
    public required T StartState { get; set; }
    public HashSet<T> AcceptStates { get; set; } = [];
    public Dictionary<(T, char), T> Transitions { get; set; } = new();
    
}