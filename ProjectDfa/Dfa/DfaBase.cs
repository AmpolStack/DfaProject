namespace ProjectDfa.Dfa;

/// <summary>
/// Base class for implementing Deterministic Finite Automata
/// Clase base para implementar Autómatas Finitos Deterministas
/// </summary>
/// <typeparam name="T">Type of automaton states / Tipo de estados del autómata</typeparam>
/// <typeparam name="TInput">Type of automaton input / Tipo de entrada del autómata</typeparam>
public class DfaBase<T, TInput> where T : Enum
{
    /// <summary>
    /// Initial state of the automaton
    /// Estado inicial del autómata
    /// </summary>
    public required T StartState { get; init; }

    /// <summary>
    /// Set of accepting/final states
    /// Conjunto de estados de aceptación/finales
    /// </summary>
    public HashSet<T> AcceptStates { get; set; } = [];

    /// <summary>
    /// Transition function mapping (current state, input) to next state
    /// Función de transición que mapea (estado actual, entrada) al siguiente estado
    /// </summary>
    public Dictionary<(T, TInput), T> Transitions { get; set; } = new();
}