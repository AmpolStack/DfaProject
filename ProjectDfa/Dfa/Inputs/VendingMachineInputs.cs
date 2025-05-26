namespace ProjectDfa.Dfa.Inputs;

/// <summary>
/// Input events for the Vending Machine DFA
/// Eventos de entrada para el Autómata de la Máquina Expendedora
/// </summary>
public enum VendingMachineInputs
{
    /// <summary>Coin insertion event / Evento de inserción de moneda</summary>
    InsertCoin,
    
    /// <summary>Product selection event / Evento de selección de producto</summary>
    SelectProduct,
    
    /// <summary>Product dispensing event / Evento de entrega de producto</summary>
    Dispense,
    
    /// <summary>Change request event / Evento de solicitud de cambio</summary>
    RequestChange
}