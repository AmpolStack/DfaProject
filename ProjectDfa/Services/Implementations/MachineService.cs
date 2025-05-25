using ProjectDfa.Dfa;
using ProjectDfa.Dfa.VendingMachine;

namespace ProjectDfa.Services;

public class MachineService : IMachineService
{
    private static VendingMachineStates _currentState= VendingMachineStates.WaitingForCoin;
    private readonly IDfa<VendingMachineStates, VendingMachineInputs> _machineDfa;
    
    public MachineService(IDfa<VendingMachineStates, VendingMachineInputs> machineDfa)
    {
        _machineDfa = machineDfa;
    }
    private bool ExecuteTransition(VendingMachineInputs input)
    {
        var dfa = _machineDfa.BuildDfa();
        Console.WriteLine("Current State: " +  _currentState);
        var contains = dfa.Transitions.TryGetValue((_currentState, input), out var transition);
        if (contains)
        {
            _currentState = transition;
            Console.WriteLine("Now Current State: " + _currentState);

        }
        else
        {
            Console.WriteLine("Transition not found");
        }
        return contains;
    }

    public Task<bool> ExecuteInsertCoin()
        => Task.FromResult(ExecuteTransition(VendingMachineInputs.InsertCoin));
    
    public Task<bool> ExecuteSelectProduct()
        => Task.FromResult(ExecuteTransition(VendingMachineInputs.SelectProduct));
    
    public Task<bool> ExecuteRequestChange()
        => Task.FromResult(ExecuteTransition(VendingMachineInputs.RequestChange));
    
    public Task<bool> ExecuteDispense()
        => Task.FromResult(ExecuteTransition(VendingMachineInputs.Dispense));
    
}