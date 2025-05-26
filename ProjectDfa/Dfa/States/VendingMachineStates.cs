namespace ProjectDfa.Dfa.States;

/// <summary>
/// States for the Vending Machine DFA
/// Estados para el Autómata de la Máquina Expendedora
/// </summary>
public enum VendingMachineStates
{
    /// <summary>Waiting for coin insertion / Esperando inserción de moneda</summary>
    WaitingForCoin,
    
    /// <summary>Coin has been inserted / Moneda insertada</summary>
    CoinInserted,
    
    /// <summary>Product has been selected / Producto seleccionado</summary>
    ProductSelected,
    
    /// <summary>Product has been delivered / Producto entregado</summary>
    ProductDelivered
}