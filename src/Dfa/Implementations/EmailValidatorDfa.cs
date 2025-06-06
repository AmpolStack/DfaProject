﻿using src.Dfa.States;

namespace src.Dfa.Implementations;

/// <summary>
/// Implementation of a DFA for validating email addresses
/// Implementación de un DFA para validar direcciones de correo electrónico
/// </summary>
public class EmailValidatorDfa : IDfa<EmailValidatorStates, char>
{
    /// <summary>
    /// Builds the DFA with all transitions for email validation
    /// Construye el DFA con todas las transiciones para validación de correos
    /// </summary>
    /// <returns>A configured DFA instance / Una instancia de DFA configurada</returns>
    public DfaBase<EmailValidatorStates,char> BuildDfa()
    {
        var dfa = new DfaBase<EmailValidatorStates, char>()
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

    private static void BuildBaseCharsTransitions(DfaBase<EmailValidatorStates, char> dfa)
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

    private static void BuildSpecialCharsTransitions(DfaBase<EmailValidatorStates, char> dfa)
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

    private static void BuildAtSignTransitions(DfaBase<EmailValidatorStates, char> dfa)
    => dfa.Transitions.Add((EmailValidatorStates.LocalBaseChar, '@'), EmailValidatorStates.DomainBaseChar);

    private static void BuildDotTransitions(DfaBase<EmailValidatorStates, char> dfa)
    {
        dfa.Transitions.Add((EmailValidatorStates.DomainBaseChar, '.'), EmailValidatorStates.DomainDot);
        dfa.Transitions.Add((EmailValidatorStates.Accepted, '.'), EmailValidatorStates.DomainDot);
    }
    

}