namespace dcisharp.Experiments.Mapping
{
    public class LedgerEntry
    {
        public LedgerEntry(string message, int amount)
        {
            Message = message;
            Amount = amount;
        }

        public string Message { get; private set; }
        public int Amount { get; private set; }
    }
}
