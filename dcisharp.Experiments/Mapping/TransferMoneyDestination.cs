namespace dcisharp.Experiments.Mapping
{
    public interface TransferMoneyDestination
    {
        int DestinationBalance { get; }
        void Deposit(int amount);
    }
}