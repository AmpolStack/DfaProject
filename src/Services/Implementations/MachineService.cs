using src.Dfa;
using src.Dfa.Inputs;
using src.Dfa.States;
using src.Services.Definitions;

namespace src.Services.Implementations;

public class MachineService : IMachineService
{
    private readonly IDfa<VendingMachineStates, VendingMachineInputs> _machineDfa;
    
    public MachineService(IDfa<VendingMachineStates, VendingMachineInputs> machineDfa)
    {
        _machineDfa = machineDfa;
    }
    private bool ExecuteTransition(Tuple<VendingMachineStates, VendingMachineInputs> tuple ,out VendingMachineStates newState)
    {
        var dfa = _machineDfa.BuildDfa();
        Console.WriteLine("Current State: " + tuple.Item2);
        var contains = dfa.Transitions.TryGetValue((tuple.Item1, tuple.Item2), out var transition);
        if (contains)
        {
            newState = transition;
            Console.WriteLine("Now Current State: " + tuple.Item2);

        }
        else
        {
            newState = tuple.Item1;
            Console.WriteLine("Transition not found");
        }
        
        return contains;
    }

    public Task<bool> ExecuteInsertCoin(VendingMachineStates currentState,out VendingMachineStates newState)
        => Task.FromResult(ExecuteTransition(new Tuple<VendingMachineStates, VendingMachineInputs>(currentState, VendingMachineInputs.InsertCoin), out newState));
    
    public Task<bool> ExecuteSelectProduct(VendingMachineStates currentState,out VendingMachineStates newState)
        => Task.FromResult(ExecuteTransition(new Tuple<VendingMachineStates, VendingMachineInputs>(currentState, VendingMachineInputs.SelectProduct), out newState));
    
    public Task<bool> ExecuteRequestChange(VendingMachineStates currentState,out VendingMachineStates newState)
        => Task.FromResult(ExecuteTransition(new Tuple<VendingMachineStates, VendingMachineInputs>(currentState, VendingMachineInputs.RequestChange), out newState));
    
    public Task<bool> ExecuteDispense(VendingMachineStates currentState,out VendingMachineStates newState)
        => Task.FromResult(ExecuteTransition(new Tuple<VendingMachineStates, VendingMachineInputs>(currentState, VendingMachineInputs.Dispense), out newState));
}