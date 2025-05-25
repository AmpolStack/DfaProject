using ProjectDfa.Custom;
using ProjectDfa.Dfa;
using ProjectDfa.Dfa.EmailValidator;
using ProjectDfa.Dfa.RegexValidator;

namespace ProjectDfa.Services;

public class ValidatorService(
    IDfa<ValidateInputRequest, char, RegexValidatorStates> regexDfa,
    IDfa<EmailValidatorStates, char> emailDfa
    ) : IValidatorService
{
    public bool Validate(ValidateInputRequest request)
    {
        return request.AllowEmail ? UseEmailDfa(request.Input) : UseRegexDfa(request);
    }

    private bool UseEmailDfa(string input)
    {
        var dfa = emailDfa.BuildDfa();
        var currentState = dfa.StartState;
        
        foreach (var c in input)
        {
            if (!dfa.Transitions.TryGetValue((currentState, c), out var transition))
            {
                return false;
            }

            currentState = transition;
        }
        
        return currentState == EmailValidatorStates.Accepted;
    }

    private bool UseRegexDfa(ValidateInputRequest request)
    {
        var dfa = regexDfa.BuildDfa(request);
        var currentState = dfa.StartState;
        
        foreach (var c in request.Input)
        {
            if (!dfa.Transitions.TryGetValue((currentState, c), out var transition))
            {
                return false;
            }

            currentState = transition;
        }

        return currentState == RegexValidatorStates.Accepted;
    }
    
    
    
    
}