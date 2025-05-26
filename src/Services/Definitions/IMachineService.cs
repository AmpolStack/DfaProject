using src.Dfa.States;

namespace src.Services.Definitions;

public interface IMachineService
{
    public Task<bool> ExecuteInsertCoin(VendingMachineStates currentState,out VendingMachineStates newState);

    public Task<bool> ExecuteSelectProduct(VendingMachineStates currentState,out VendingMachineStates newState);

    public Task<bool> ExecuteRequestChange(VendingMachineStates currentState,out VendingMachineStates newState);

    public Task<bool> ExecuteDispense(VendingMachineStates currentState,out VendingMachineStates newState);
}