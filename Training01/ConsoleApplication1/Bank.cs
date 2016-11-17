using ConsoleApplication1.Employee;
using ConsoleApplication1.Subsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Bank
    {
        public Bank()
        {
            this.BankAccountList = new List<ConsoleApplication1.BankAccount>();
            this.BankAccountList.Add(new ConsoleApplication1.BankAccount()
            {
                Amount = 50,
                Person = "Yumi"
            });
            this.BankAccountList.Add(new ConsoleApplication1.BankAccount()
            {
                Amount = 440,
                Person = "Antony"
            });
            this.BankAccountList.Add(new ConsoleApplication1.BankAccount()
            {
                Amount = 2,
                Person = "Max"
            });
            this.BankAccountList.Add(new ConsoleApplication1.BankAccount()
            {
                Amount = 3,
                Person = "Norman"
            });
            this.BankAccountList.Add(new ConsoleApplication1.BankAccount()
            {
                Amount = 5,
                Person = "Lorence"
            });
            this.BankEmployeeList = new List<BankEmployeeBase>()
            {
                new E100001()
            };
            this.SubsystemList = new List<SubsystemBase>()
            {
                new AlipaySubsystem()
            };
        }
        /// <summary>
        /// 執行交易金額轉讓，並傳回轉讓是否成功
        /// </summary>
        /// <param name="sourcePerson">來源帳號</param>
        /// <param name="targetPerson">目標帳號</param>
        /// <param name="amount">轉讓金額</param>
        /// <returns>是否轉讓完成</returns>
        public bool transferAmount(string sourcePerson, string targetPerson, decimal amount)
        {
            BankAccount sourceBankAccount = this.BankAccountList.First(t => t.Person == sourcePerson);
            BankAccount targetBankAccount = this.BankAccountList.First(t => t.Person == targetPerson);
            TransactionInfo transactionInfo = new TransactionInfo();
            transactionInfo.Amount = amount;
            transactionInfo.SourceBankAccount = sourceBankAccount;
            transactionInfo.TargetBankAccount = targetBankAccount;
            if (!this.TransactionVerifier.Any(t => t.verifyAmount(transactionInfo) == false))
            {
                return false;
            }
            sourceBankAccount.Amount -= amount;
            targetBankAccount.Amount += amount;
            return true;
        }
        public BankAccount getBankAccount(string person)
        {
            return this.BankAccountList.FirstOrDefault(t => t.Person == person);
        }
        private List<BankAccount> BankAccountList { set; get; }
        private List<BankEmployeeBase> BankEmployeeList { set; get; }
        private List<SubsystemBase> SubsystemList { set; get; }
        /// <summary>
        /// 取得交易審核角色
        /// </summary>
        private List<IVerifyTransaction> TransactionVerifier
        {
            get
            {
                //return this.BankEmployeeList.Where(t => t is IVerifyTransaction)
                //    .Select(t => (IVerifyTransaction)t)
                //    .ToList();
                return this.BankEmployeeList.OfType<IVerifyTransaction>()
                    .Concat(this.SubsystemList.OfType<IVerifyTransaction>()).ToList();
            }
        }
    }
}
