namespace ProjectDfa.Dfa;

public interface IDfa<in TData, TStates> where TStates : Enum
{
    public DfaBase<TStates> BuildDfa(TData data);
}
public interface IDfa<TStates> where TStates : Enum
{
    public DfaBase<TStates> BuildDfa();
}