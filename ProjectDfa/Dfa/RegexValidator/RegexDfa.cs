using ProjectDfa.Custom;

namespace ProjectDfa.Dfa.RegexValidator;

public class RegexDfa : IDfa<ValidateInputRequest, RegexStates> 
{
    public DfaBase<RegexStates> BuildDfa(ValidateInputRequest data)
    {
        var dfa = new DfaBase<RegexStates>()
        {
            StartState = RegexStates.Start,
            AcceptStates = [RegexStates.Accepted]
        };
        
        var allowedChars = new HashSet<char>();

        if (data.AllowNumbers)
        {
            // Represents all numbers in Unicode character
            for (var c = '0'; c <= '9'; c++)
                allowedChars.Add(c);
        }
        
        if (data.AllowLetters)
        {
            // Represents all lowercase letters in Unicode Characters
            for (var c = 'a'; c <= 'z'; c++) allowedChars.Add(c);
            // Represents all uppercase letters in Unicode Characters
            for (var c = 'A'; c <= 'Z'; c++) allowedChars.Add(c);
        }
        
        if (data.AllowSpecials)
        {
            // Represents specials characters in Unicode
            // !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~ (and the space)
            var specials = Enumerable.Range(32, 95)
                .Select(i => (char)i)
                .Where(c => !char.IsLetterOrDigit(c));
            foreach (var c in specials)
                allowedChars.Add(c);
        }
        
        foreach (var c in allowedChars)
        {
            // Define all transitions in DFA
            dfa.Transitions[(RegexStates.Start, c)] = RegexStates.Accepted;
            dfa.Transitions[(RegexStates.Accepted, c)] = RegexStates.Accepted;
        }
        
        return dfa;
    }
}