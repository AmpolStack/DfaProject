namespace ProjectDfa.Dfa;

/// <summary>
/// Interface for constructing Deterministic Finite Automata with custom input data
/// Interfaz para construir Autómatas Finitos Deterministas con datos de entrada personalizados
/// </summary>
/// <typeparam name="TData">Type of input data / Tipo de datos de entrada</typeparam>
/// <typeparam name="TInput">Type of automaton input / Tipo de entrada del autómata</typeparam>
/// <typeparam name="TStates">Type of automaton states / Tipo de estados del autómata</typeparam>
public interface IDfa<in TData, TInput, TStates> where TStates : Enum
{
    /// <summary>
    /// Builds a DFA instance with the provided input data
    /// Construye una instancia de DFA con los datos de entrada proporcionados
    /// </summary>
    /// <param name="data">Configuration data / Datos de configuración</param>
    /// <returns>A configured DFA instance / Una instancia de DFA configurada</returns>
    public DfaBase<TStates, TInput> BuildDfa(TData data);
}

/// <summary>
/// Interface for constructing Deterministic Finite Automata
/// Interfaz para construir Autómatas Finitos Deterministas
/// </summary>
/// <typeparam name="TStates">Type of automaton states / Tipo de estados del autómata</typeparam>
/// <typeparam name="TInput">Type of automaton input / Tipo de entrada del autómata</typeparam>
public interface IDfa<TStates, TInput> where TStates : Enum
{
    /// <summary>
    /// Builds a DFA instance
    /// Construye una instancia de DFA
    /// </summary>
    /// <returns>A configured DFA instance / Una instancia de DFA configurada</returns>
    public DfaBase<TStates, TInput> BuildDfa();
}