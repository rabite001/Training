using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    /// <summary>
    /// 銀行帳戶
    /// </summary>
    [Serializable]
    public class BankAccount
    {
        /// <summary>
        /// 設定或取得 ID
        /// </summary>
        public Guid Id { set; get; }
        public string Person { set; get; }
        public decimal Amount { get; set; }

    }
}
