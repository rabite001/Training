using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7.Infos
{
    public class BankAccountInfo
    {
        public Guid BankAccountId { set; get; }
        public Guid BankUserId { set; get; }
        public decimal Amount { set; get; }
    }
}
