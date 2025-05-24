using ProjectDfa.Custom;

namespace ProjectDfa.Dfa.RegexValidator;

public class RegexValidatorService(IDfa<ValidateInputRequest, RegexValidatorStates> regexDfa) : IRegexValidatorService
{
    public bool Validate(ValidateInputRequest request)
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