using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class TransactionInfo
    {
        public BankAccount SourceBankAccount { set; get; }
        public BankAccount TargetBankAccount { set; get; }
        public decimal Amount { set; get; }
    }
}
