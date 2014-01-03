using System.Collections.Generic;
using System.Linq;

namespace dcisharp.Experiments.Mapping
{
    public class Account : Role<TransferMoneySource>, Role<TransferMoneyDestination>
    {
        public Account()
        {
            LedgerEntries = new List<LedgerEntry>();
        }

        public AccountNumber AccountNumber { get; set; }
        public IList<LedgerEntry> LedgerEntries { get; set; }

        public int Balance
        {
            get { return LedgerEntries.Sum(x => x.Amount); }
        }

        public void IncreaseBalance(int amount)
        {
            LedgerEntries.Add(new LedgerEntry("Depositing", amount));
        }

        public void DecreaseBalance(int amount)
        {
            LedgerEntries.Add(new LedgerEntry("Withdrawing", -amount));
        }

        public void MapContext(ContextMapping<TransferMoneySource> mapping)
        {
            mapping
                .Map(x => x.Withdraw(0), () => DecreaseBalance(0))
                .Map(x => x.SourceBalance, () => Balance);
        }

        public void MapContext(ContextMapping<TransferMoneyDestination> mapping)
        {
            mapping
                .Map(x => x.Deposit(0), () => IncreaseBalance(0))
                .Map(x => x.DestinationBalance, () => Balance);
        }

        public override string ToString()
        {
            return string.Format("{0}. Balance {1}", AccountNumber, Balance);
        }
    }
}