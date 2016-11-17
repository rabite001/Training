using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class TransactionHistory
    {
        public string Source { set; get; }
        public string Target { set; get; }
        public DateTime TransactionTime { set; get; }
        public decimal Amount { set; get; }
        public decimal OriginalSourceAmount { set; get; }
        public decimal OriginalTargetAmount { set; get; }
        public decimal ResultSourceAmount { set; get; }
        public decimal ResultTargetAmount { set; get; }
    }
}
