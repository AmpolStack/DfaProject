using ProjectDfa.Dfa.Inputs;
using ProjectDfa.Dfa.States;

namespace ProjectDfa.Dfa.Implementations;

/// <summary>
/// Implementation of a DFA for controlling a vending machine's state transitions
/// Implementación de un DFA para controlar las transiciones de estado de una máquina expendedora
/// </summary>
public class VendingMachineDfa : IDfa<VendingMachineStates, VendingMachineInputs>
{
    /// <summary>
    /// Builds the DFA with all transitions for vending machine operation
    /// Construye el DFA con todas las transiciones para la operación de la máquina expendedora
    /// </summary>
    /// <returns>A configured DFA instance / Una instancia de DFA configurada</returns>
    public DfaBase<VendingMachineStates, VendingMachineInputs> BuildDfa()
    {
        var dfa = new DfaBase<VendingMachineStates, VendingMachineInputs>()
        {
            StartState = VendingMachineStates.WaitingForCoin,
            AcceptStates = [VendingMachineStates.ProductDelivered]
        };

        DispenseInputTransitions(dfa);
        InsertCoinInputTransitions(dfa);
        SelectProductInputTransitions(dfa);
        RequestChangeInputTransitions(dfa);
        
        return dfa;
    }

    /// <summary>
    /// Configures transitions for the Dispense operation
    /// Configura las transiciones para la operación de dispensar producto
    /// </summary>
    /// <param name="dfa">DFA instance to configure / Instancia del DFA a configurar</param>
    private static void DispenseInputTransitions(DfaBase<VendingMachineStates, VendingMachineInputs> dfa)
    {
        const VendingMachineInputs input = VendingMachineInputs.Dispense;
        dfa.Transitions.Add((VendingMachineStates.ProductSelected, input), VendingMachineStates.ProductDelivered);
    }
    
    /// <summary>
    /// Configures transitions for the InsertCoin operation
    /// Configura las transiciones para la operación de insertar moneda
    /// </summary>
    /// <param name="dfa">DFA instance to configure / Instancia del DFA a configurar</param>
    private static void InsertCoinInputTransitions(DfaBase<VendingMachineStates, VendingMachineInputs> dfa)
    {
        const VendingMachineInputs input = VendingMachineInputs.InsertCoin;
        dfa.Transitions.Add((VendingMachineStates.WaitingForCoin, input), VendingMachineStates.CoinInserted);
        dfa.Transitions.Add((VendingMachineStates.CoinInserted, input), VendingMachineStates.CoinInserted);
    }
    
    /// <summary>
    /// Configures transitions for the SelectProduct operation
    /// Configura las transiciones para la operación de seleccionar producto
    /// </summary>
    /// <param name="dfa">DFA instance to configure / Instancia del DFA a configurar</param>
    private static void SelectProductInputTransitions(DfaBase<VendingMachineStates, VendingMachineInputs> dfa)
    {
        const VendingMachineInputs input = VendingMachineInputs.SelectProduct;
        dfa.Transitions.Add((VendingMachineStates.CoinInserted, input), VendingMachineStates.ProductSelected);
        dfa.Transitions.Add((VendingMachineStates.ProductSelected, input), VendingMachineStates.ProductSelected);
    }
    
    /// <summary>
    /// Configures transitions for the RequestChange operation
    /// Configura las transiciones para la operación de solicitar cambio
    /// </summary>
    /// <param name="dfa">DFA instance to configure / Instancia del DFA a configurar</param>
    private static void RequestChangeInputTransitions(DfaBase<VendingMachineStates, VendingMachineInputs> dfa)
    {
        const VendingMachineInputs input = VendingMachineInputs.RequestChange;
        dfa.Transitions.Add((VendingMachineStates.CoinInserted, input), VendingMachineStates.WaitingForCoin);
        dfa.Transitions.Add((VendingMachineStates.ProductSelected, input), VendingMachineStates.WaitingForCoin);
        dfa.Transitions.Add((VendingMachineStates.ProductDelivered, input), VendingMachineStates.WaitingForCoin);
        dfa.Transitions.Add((VendingMachineStates.WaitingForCoin, input), VendingMachineStates.WaitingForCoin);
    }
    
    
}