using ProjectDfa.Custom;
using ProjectDfa.Dfa.States;

namespace ProjectDfa.Dfa.Implementations;

/// <summary>
/// Implementation of a configurable DFA for validating strings against regex-like patterns
/// Implementación de un DFA configurable para validar cadenas contra patrones tipo regex
/// </summary>
public class RegexValidatorDfa : IDfa<ValidateInputBase, char, RegexValidatorStates> 
{
    /// <summary>
    /// Builds the DFA with transitions based on the validation configuration
    /// Construye el DFA con transiciones basadas en la configuración de validación
    /// </summary>
    /// <param name="data">Configuration for allowed characters and patterns
    /// Configuración para caracteres y patrones permitidos</param>
    /// <returns>A configured DFA instance / Una instancia de DFA configurada</returns>
    public DfaBase<RegexValidatorStates, char> BuildDfa(ValidateInputBase data)
    {
        var dfa = new DfaBase<RegexValidatorStates, char>()
        {
            StartState = RegexValidatorStates.Start,
            AcceptStates = [RegexValidatorStates.Accepted]
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
            dfa.Transitions[(RegexValidatorStates.Start, c)] = RegexValidatorStates.Accepted;
            dfa.Transitions[(RegexValidatorStates.Accepted, c)] = RegexValidatorStates.Accepted;
        }
        
        return dfa;
    }
}