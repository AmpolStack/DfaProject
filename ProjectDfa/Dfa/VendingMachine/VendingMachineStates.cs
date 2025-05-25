namespace ProjectDfa.Dfa.VendingMachine;

public enum VendingMachineStates
{
    WaitingForCoin,
    CoinInserted,
    ProductSelected,
    ProductDelivered,
    WaitingForRestart
}