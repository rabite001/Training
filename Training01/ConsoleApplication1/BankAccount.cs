using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    [Serializable]
    public class BankAccount
    {
        public string Person { set; get; }
        public decimal Amount { get; set; }

    }
}
