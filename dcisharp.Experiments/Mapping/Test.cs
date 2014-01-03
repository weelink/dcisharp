using System;
using System.Collections.Generic;

namespace dcisharp.Experiments.Mapping
{
    public class Test
    {
        public static void Main()
        {
            var sourceAccount = new Account
            {
                AccountNumber = new AccountNumber("S1234"),
                LedgerEntries = new List<LedgerEntry>
                {
                    new LedgerEntry("Initial deposit", 1000)
                }
            };

            var destinationAccount = new Account
            {
                AccountNumber = new AccountNumber("D4321"),
                LedgerEntries = new List<LedgerEntry>
                {
                    new LedgerEntry("Initial deposit", 500)
                }
            };

            var sourceMapping = new ContextMapping<Account, TransferMoneySource>();
            sourceAccount.MapContext(sourceMapping);

            var destinationMapping = new ContextMapping<Account, TransferMoneyDestination>();
            destinationAccount.MapContext(destinationMapping);

            AccountToTransferMoneySourceAdapter adaptedSource = sourceAccount;
            AccountToTransferMoneyDestinationAdapter adaptedDestination = destinationAccount;

            TransferMoney(adaptedSource, adaptedDestination);

            var proxiedSource = sourceAccount.Proxy(sourceMapping);
            var proxiedDestination = destinationAccount.Proxy(destinationMapping);

            TransferMoney(proxiedSource, proxiedDestination);

            Console.ReadKey();
        }

        private static void TransferMoney(TransferMoneySource s, TransferMoneyDestination d)
        {
            var transfer = new MoneyTransferContext
            {
                Source = s,
                Destination = d
            };

            Console.WriteLine("Before");
            Console.WriteLine("======");
            Console.WriteLine("    Source = {0}", s);
            Console.WriteLine("    Destination = {0}", d);

            transfer.Transfer(50);

            Console.WriteLine("After");
            Console.WriteLine("======");
            Console.WriteLine("    Source = {0}", s);
            Console.WriteLine("    Destination = {0}", d);

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}