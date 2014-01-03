namespace dcisharp.Experiments.Mapping
{
    public interface TransferMoneySource
    {
        int SourceBalance { get; }
        void Withdraw(int amount);
    }
}