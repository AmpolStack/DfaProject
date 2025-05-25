namespace ProjectDfa.Dfa.EmailValidator;

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