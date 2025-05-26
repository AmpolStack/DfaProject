namespace src.Dfa.States;

/// <summary>
/// States for the Email Validator DFA
/// Estados para el Autómata Validador de Correos Electrónicos
/// </summary>
public enum EmailValidatorStates
{
    /// <summary>Initial state / Estado inicial</summary>
    Init,
    
    /// <summary>Valid local part character state / Estado de carácter válido en parte local</summary>
    LocalBaseChar,
    
    /// <summary>Special character in local part state / Estado de carácter especial en parte local</summary>
    LocalSpecialChar,
    
    /// <summary>@ symbol state / Estado del símbolo @</summary>
    AtSign,
    
    /// <summary>Valid domain part character state / Estado de carácter válido en parte de dominio</summary>
    DomainBaseChar,
    
    /// <summary>Domain dot state / Estado de punto en dominio</summary>
    DomainDot,
    
    /// <summary>Final acceptance state / Estado final de aceptación</summary>
    Accepted
}