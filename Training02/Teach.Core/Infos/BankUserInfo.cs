using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teach.Core.Infos
{
    public class BankUserInfo
    {
        public Guid BankUserId { set; get; }
        public string UserName { set; get; }
        public DateTime? LastLoginDate { set; get; }
    }
}
