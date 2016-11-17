using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teach.Adapter.Entites;

namespace Teach.Adapter.Database
{
    public interface IBankUserDb
    {
        List<BankUserEntity> getBankUsers();
        void addBankUser(BankUserEntity bankUserEntity);
        void updateLastLoginDate(Guid useId, DateTime lastLoginDate);
    }
}
