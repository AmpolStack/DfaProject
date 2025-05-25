using Microsoft.AspNetCore.Http.HttpResults;
using ProjectDfa.Custom;
using ProjectDfa.Dfa.RegexValidator;

namespace ProjectDfa.Dfa.EmailValidator;

public class EmailValidatorDfa : IDfa<EmailValidatorStates>
{
    public DfaBase<EmailValidatorStates> BuildDfa()
    {
        var dfa = new DfaBase<EmailValidatorStates>()
        {
            StartState = EmailValidatorStates.Init,
            AcceptStates = [EmailValidatorStates.Accepted]
        };
        
        BuildBaseCharsTransitions(dfa);
        BuildSpecialCharsTransitions(dfa);
        BuildAtSignTransitions(dfa);
        BuildDotTransitions(dfa);
        return dfa;
    }

    private static void BuildBaseCharsTransitions(DfaBase<EmailValidatorStates> dfa)
    {
        var allowedBaseChars = new HashSet<char>();
        
        for (var c = '0'; c <= '9'; c++)
            allowedBaseChars.Add(c);
        
        for (var c = 'a'; c <= 'z'; c++) allowedBaseChars.Add(c);

        foreach (var c in allowedBaseChars)
        {
            dfa.Transitions.Add((EmailValidatorStates.Init, c), EmailValidatorStates.LocalBaseChar);
            dfa.Transitions.Add((EmailValidatorStates.LocalBaseChar, c), EmailValidatorStates.LocalBaseChar);
            dfa.Transitions.Add((EmailValidatorStates.LocalSpecialChar, c), EmailValidatorStates.LocalBaseChar);
            dfa.Transitions.Add((EmailValidatorStates.AtSign, c), EmailValidatorStates.DomainBaseChar);
            dfa.Transitions.Add((EmailValidatorStates.DomainBaseChar, c), EmailValidatorStates.DomainBaseChar);
            dfa.Transitions.Add((EmailValidatorStates.DomainDot, c), EmailValidatorStates.Accepted);
            dfa.Transitions.Add((EmailValidatorStates.Accepted, c), EmailValidatorStates.Accepted);
        }
    }

    private static void BuildSpecialCharsTransitions(DfaBase<EmailValidatorStates> dfa)
    {
        var allowedSpecialChars = new HashSet<char>()
        {
            '.', '_', '-', '%', '+'
        };

        foreach (var c in allowedSpecialChars)
        {
            dfa.Transitions.Add((EmailValidatorStates.LocalBaseChar, c), EmailValidatorStates.LocalSpecialChar);
        }
    }

    private static void BuildAtSignTransitions(DfaBase<EmailValidatorStates> dfa)
    => dfa.Transitions.Add((EmailValidatorStates.LocalBaseChar, '@'), EmailValidatorStates.DomainBaseChar);

    private static void BuildDotTransitions(DfaBase<EmailValidatorStates> dfa)
        => dfa.Transitions.Add((EmailValidatorStates.DomainBaseChar, '.'), EmailValidatorStates.DomainDot);




}