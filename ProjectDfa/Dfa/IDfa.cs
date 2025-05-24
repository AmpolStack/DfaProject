namespace ProjectDfa.Dfa;

public interface IDfa<in TData, TStates> where TStates : Enum
{
    public DfaDefinition<TStates> BuildDfa(TData data);
}