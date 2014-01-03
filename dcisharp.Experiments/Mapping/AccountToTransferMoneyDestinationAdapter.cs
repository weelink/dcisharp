namespace dcisharp.Experiments.Mapping
{
    public class AccountToTransferMoneyDestinationAdapter : TransferMoneyDestination
    {
        public AccountToTransferMoneyDestinationAdapter(Account account)
        {
            Account = account;
        }

        public int DestinationBalance
        {
            get
            {
                return Account.Balance;
            }
        }

        public void Deposit(int amount)
        {
            Account.IncreaseBalance(amount);
        }

        public override string ToString()
        {
            return Account.ToString();
        }

        private Account Account { get; set; }

        public static implicit operator AccountToTransferMoneyDestinationAdapter(Account account)
        {
            return new AccountToTransferMoneyDestinationAdapter(account);
        }
    }
}