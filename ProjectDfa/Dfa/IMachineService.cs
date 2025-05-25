using ProjectDfa.Custom;
using ProjectDfa.Dfa.VendingMachine;

namespace ProjectDfa.Dfa;

public interface IMachineService
{
    public Task<bool> ExecuteInsertCoin();

    public Task<bool> ExecuteSelectProduct();

    public Task<bool> ExecuteRequestChange();

    public Task<bool> ExecuteDispense();
}