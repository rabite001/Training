using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teach.Adapter.Entites;

namespace Teach.Adapter.Database
{
    public interface IBankAccountDb
    {
        /// <summary>
        /// 取得所有帳戶資料
        /// </summary>
        /// <returns></returns>
        List<BankAccountEntity> getBankAccounts();
        /// <summary>
        /// 依照最低及最高的金額篩選帳戶
        /// </summary>
        /// <param name="minAmount">低(別學!)</param>
        /// <param name="maxAmount">高(別學!)</param>
        /// <returns></returns>
        List<BankAccountEntity> getBankAccounts(decimal minAmount, decimal maxAmount);
        void addBankAccount(BankAccountEntity bankAccountEntity);
    }
}
