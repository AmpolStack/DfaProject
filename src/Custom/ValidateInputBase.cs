namespace src.Custom;

/// <summary>
/// Base configuration class for the RegexValidator DFA
/// Clase base de configuración para el DFA RegexValidator
/// </summary>
public class ValidateInputBase
{
    /// <summary>
    /// Allows numeric characters (0-9) in the validation
    /// Permite caracteres numéricos (0-9) en la validación
    /// </summary>
    public bool AllowNumbers { get; init; }

    /// <summary>
    /// Allows letter characters (a-z, A-Z) in the validation
    /// Permite caracteres de letras (a-z, A-Z) en la validación
    /// </summary>
    public bool AllowLetters { get; init; }

    /// <summary>
    /// Allows special characters in the validation
    /// Permite caracteres especiales en la validación
    /// </summary>
    public bool AllowSpecials { get; init; }
}