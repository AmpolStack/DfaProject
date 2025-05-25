using ProjectDfa.Dfa;

namespace ProjectDfa.Services;

public interface IDfa<in TData, TInput, TStates> where TStates : Enum
{
    public DfaBase<TStates, TInput> BuildDfa(TData data);
}
public interface IDfa<TStates, TInput> where TStates : Enum
{
    public DfaBase<TStates, TInput> BuildDfa();
}