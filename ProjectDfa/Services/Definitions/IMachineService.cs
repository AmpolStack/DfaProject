namespace ProjectDfa.Services.Definitions;

public interface IMachineService
{
    public Task<bool> ExecuteInsertCoin();

    public Task<bool> ExecuteSelectProduct();

    public Task<bool> ExecuteRequestChange();

    public Task<bool> ExecuteDispense();
}