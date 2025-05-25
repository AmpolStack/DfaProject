using ProjectDfa.Dfa.Inputs;
using ProjectDfa.Dfa.States;
using ProjectDfa.Services;

namespace ProjectDfa.Dfa.VendingMachine;

public class VendingMachineDfa : IDfa<VendingMachineStates, VendingMachineInputs>
{
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

    private static void DispenseInputTransitions(DfaBase<VendingMachineStates, VendingMachineInputs> dfa)
    {
        const VendingMachineInputs input = VendingMachineInputs.Dispense;
        dfa.Transitions.Add((VendingMachineStates.ProductSelected, input), VendingMachineStates.ProductDelivered);
    }
    
    private static void InsertCoinInputTransitions(DfaBase<VendingMachineStates, VendingMachineInputs> dfa)
    {
        const VendingMachineInputs input = VendingMachineInputs.InsertCoin;
        dfa.Transitions.Add((VendingMachineStates.WaitingForCoin, input), VendingMachineStates.CoinInserted);
        dfa.Transitions.Add((VendingMachineStates.CoinInserted, input), VendingMachineStates.CoinInserted);
    }
    
    private static void SelectProductInputTransitions(DfaBase<VendingMachineStates, VendingMachineInputs> dfa)
    {
        const VendingMachineInputs input = VendingMachineInputs.SelectProduct;
        dfa.Transitions.Add((VendingMachineStates.CoinInserted, input), VendingMachineStates.ProductSelected);
        dfa.Transitions.Add((VendingMachineStates.ProductSelected, input), VendingMachineStates.ProductSelected);
    }
    
    private static void RequestChangeInputTransitions(DfaBase<VendingMachineStates, VendingMachineInputs> dfa)
    {
        const VendingMachineInputs input = VendingMachineInputs.RequestChange;
        dfa.Transitions.Add((VendingMachineStates.CoinInserted, input), VendingMachineStates.WaitingForCoin);
        dfa.Transitions.Add((VendingMachineStates.ProductSelected, input), VendingMachineStates.WaitingForCoin);
        dfa.Transitions.Add((VendingMachineStates.ProductDelivered, input), VendingMachineStates.WaitingForCoin);
        dfa.Transitions.Add((VendingMachineStates.WaitingForCoin, input), VendingMachineStates.WaitingForCoin);
    }
    
    
}