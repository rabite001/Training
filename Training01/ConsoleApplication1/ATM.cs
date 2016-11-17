using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ATM
    {
        /// <summary>
        /// 初始化 ATM 
        /// </summary>
        /// <param name="bank">與 ATM 相關的 銀行</param>
        public ATM(Bank bank)
        {
            this.Bank = bank;
            this.TransactionHistoryList = new List<TransactionHistory>();
        }
        public void transferAmount(string source, string target, decimal amount)
        {
            TransactionHistory transactionHistory = new TransactionHistory()
            {
                Amount = amount,
                Source = source,
                Target = target,
                TransactionTime = DateTime.Now,
                OriginalSourceAmount = this.Bank.getBankAccount(source).Amount,
                OriginalTargetAmount = this.Bank.getBankAccount(target).Amount,
            };
            
            if (this.Bank.transferAmount(source, target, amount))
            {
                transactionHistory.ResultSourceAmount = this.Bank.getBankAccount(source).Amount;
                transactionHistory.ResultTargetAmount = this.Bank.getBankAccount(target).Amount;
                this.TransactionHistoryList.Add(transactionHistory);
            }
        }
        private Bank Bank { set; get; }
        private List<TransactionHistory> TransactionHistoryList { set; get; }
    }
}
