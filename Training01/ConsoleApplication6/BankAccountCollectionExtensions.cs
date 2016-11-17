using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.Collections;

namespace ConsoleApplication6
{
    /// <summary>
    /// 針對<see cref="BankAccount"/>集合的靜態擴充類別
    /// </summary>
    public static class BankAccountCollectionExtensions//BankAccountCollection的擴充方法
    {
        public static IEnumerable<BankAccount> getMaxAmountAccounts(this ThreadSafeObservableCollection<BankAccount> bankAccountCollection)
        {
            decimal maxAmount = bankAccountCollection.Max(t => t.Amount);
            return bankAccountCollection.Where(t => t.Amount == maxAmount);
        }
        public static BankAccount getMaxAmountAccount(this ThreadSafeObservableCollection<BankAccount> bankAccountCollection)
        {
            return bankAccountCollection.OrderByDescending(t => t.Amount).FirstOrDefault();
        }
        public static BankAccount getMaxAmountAccount(this ThreadSafeObservableCollection<BankAccount> bankAccountCollection, decimal minAmount)
        {
            return bankAccountCollection
                .Where(t => t.Amount >= minAmount)
                .OrderByDescending(t => t.Amount).FirstOrDefault();
        }
        public static BankAccount getMaxAmountAccount(this ThreadSafeObservableCollection<BankAccount> bankAccountCollection, Func<BankAccount, decimal> minAmountFunc)
        {
            return bankAccountCollection
                .Where(t => t.Amount >= minAmountFunc(t))
                .OrderByDescending(t => t.Amount).FirstOrDefault();
        }
    }
}
