namespace ProjectDfa.Dfa;

public class DfaBase<T, TInput> where T : Enum
{
    public required T StartState { get; init; }
    public HashSet<T> AcceptStates { get; set; } = [];
    public Dictionary<(T, TInput), T> Transitions { get; set; } = new();
    
}