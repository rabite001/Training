using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teach.Adapter.Entites;

namespace Teach.Adapter.Database.Oracle.Bank
{
    public class BankUserDb : IBankUserDb
    {
        public void addBankUser(BankUserEntity bankUserEntity)
        {
            throw new NotImplementedException();
        }

        public List<BankUserEntity> getBankUsers()
        {
            throw new NotImplementedException();
        }
        public void updateLastLoginDate(Guid useId, DateTime lastLoginDate)
        {
            throw new NotImplementedException();
        }
    }
}
