namespace ProjectDfa.Dfa.States;

public enum EmailValidatorStates
{
    Init,
    LocalBaseChar,
    LocalSpecialChar,
    AtSign,
    DomainBaseChar,
    DomainDot,
    Accepted
}