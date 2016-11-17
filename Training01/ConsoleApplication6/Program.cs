using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.Bank = new Bank("TEC 銀行");
            Program.Bank.BankAccountCollection.Add(new BankAccount()
            {
                Amount = 400,
                Id = new Guid("727375BA-2633-4D9C-92F4-6ED18FD422F4"),
                Person = "Antony"
            });
            Program.Bank.BankAccountCollection.Add(new BankAccount()
            {
                Amount = 50,
                Id = new Guid("727375BA-2633-4D9C-92F4-6ED18FD422F5"),
                Person = "Yumin"
            });
            Program.Bank.BankAccountCollection.Add(new BankAccount()
            {
                Amount = 5,
                Id = new Guid("727375BA-2633-4D9C-92F4-6ED18FD422F6"),
                Person = "Norman"
            });
            Program.Bank.BankAccountCollection.Add(new BankAccount()
            {
                Amount = 3,
                Id = new Guid("727375BA-2633-4D9C-92F4-6ED18FD422F7"),
                Person = "Lorence"
            });
            //Program.Bank.addInterest(new Guid("727375BA-2633-4D9C-92F4-6ED18FD422F7"), 3m, Program.getShouldAddInterest);
            //Program.Bank.addInterest(new Guid("727375BA-2633-4D9C-92F4-6ED18FD422F7"), 3m,
            //    (bankAccount, dateTime) =>
            //    {
            //        return bankAccount.Person.StartsWith("A");
            //    });
            //Program.Bank.BankAccountCollection.getMaxAmountAccount(bankAccount => 50);
            Dictionary<Guid, BankAccount> dic = Program.Bank.BankAccountCollection.
                ToDictionary(
                    (bankAccount) => bankAccount.Id, //輸入bankAccount 就 return bankAccount.ID  t=>t.Id
                    (bankAccount) => bankAccount);
            Console.ReadKey();
        }
        //public static bool getShouldAddInterest()
        //{
        //    return true;
        //}
        private static Bank Bank { set; get; }
    }
}
