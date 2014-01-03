using System;

namespace dcisharp.Experiments.Mapping
{
    public class MoneyTransferContext
    {
        public TransferMoneySource Source { get; set; }
        public TransferMoneyDestination Destination { get; set; }

        public void Transfer(int amount)
        {
            Console.WriteLine();
            Console.WriteLine("MoneyTransferContext");
            Console.WriteLine("====================");

            Console.WriteLine("Source balance: {0}", Source.SourceBalance);
            Console.WriteLine("Destination balance: {0}", Destination.DestinationBalance);

            Console.WriteLine("    > Transferring money");

            Source.Withdraw(amount);
            Destination.Deposit(amount);

            Console.WriteLine("    > Money transferred");

            Console.WriteLine("Source balance: {0}", Source.SourceBalance);
            Console.WriteLine("Destination balance: {0}", Destination.DestinationBalance);

            Console.WriteLine("=================");

            Console.WriteLine();
        }
    }
}