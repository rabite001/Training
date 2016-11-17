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
    internal class BankAccountDb : IBankAccountDb
    {
        public void addBankAccount(BankAccountEntity bankAccountEntity)
        {
            throw new NotImplementedException();
        }

        public List<BankAccountEntity> getBankAccounts()
        {
            throw new NotImplementedException();
        }

        public List<BankAccountEntity> getBankAccounts(decimal minAmount, decimal maxAmount)
        {
            throw new NotImplementedException();
        }
    }
}
