using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class IndexModel
    {
        public List<BankAccountInfo> BankAccountInfoList { set; get; }
    }
    public class BankAccountInfo
    {
        public string Name { set; get; }
        public decimal Amount { get; set; }

    }
}