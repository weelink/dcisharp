namespace dcisharp.Experiments.Mapping
{
    public class AccountToTransferMoneySourceAdapter : TransferMoneySource
    {
        public AccountToTransferMoneySourceAdapter(Account account)
        {
            Account = account;
        }

        public int SourceBalance
        {
            get
            {
                return Account.Balance;
            }
        }

        public void Withdraw(int amount)
        {
            Account.DecreaseBalance(amount);
        }

        public override string ToString()
        {
            return Account.ToString();
        }

        private Account Account { get; set; }

        public static implicit operator AccountToTransferMoneySourceAdapter(Account account)
        {
            return new AccountToTransferMoneySourceAdapter(account);
        }
    }
}