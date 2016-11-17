using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teach.Adapter.Entites
{
    public class BankAccountEntity
    {
        public Guid BankAccountId { set; get; }
        public Guid BankUserId { set; get; }
        public decimal Amount { set; get; }
    }
}
