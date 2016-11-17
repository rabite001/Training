using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.Collections;

namespace ConsoleApplication6
{
    public class Bank
    {
        /// <summary>
        /// 初始化銀行
        /// </summary>
        /// <param name="bankName"></param>
        public Bank(string bankName)
        {
            this.BankName = bankName;
            this.BankAccountCollection = new ThreadSafeObservableCollection<BankAccount>();
        }
        /// <summary>
        /// 加入利息
        /// </summary>
        /// <param name="guid">誰要收利息</param>
        /// <param name="amount">收多少錢</param>
        public void addInterest(Guid guid, decimal amount, Func<BankAccount, DateTime, bool> shoudAddInterestFunc) //輸入BankAccount與DATETIME 回傳TRUE
        {
            if (shoudAddInterestFunc(this.BankAccountCollection.First(t => t.Id == guid), DateTime.Now))
            {
                this.BankAccountCollection.First(t => t.Id == guid).Amount =
                    this.BankAccountCollection.First(t => t.Id == guid).Amount + amount;
            }
        }
        /// <summary>
        /// 設定或取得銀行名稱
        /// </summary>
        public string BankName { private set; get; }
        public ThreadSafeObservableCollection<BankAccount> BankAccountCollection { private set; get; }
    }
}
