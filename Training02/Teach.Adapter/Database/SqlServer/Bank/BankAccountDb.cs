using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teach.Adapter.Entites;

namespace Teach.Adapter.Database.SqlServer.Bank
{
    internal class BankAccountDb : SqlDataBase, IBankAccountDb
    {
        public void addBankAccount(BankAccountEntity bankAccountEntity)
        {
            base.executeNonQueryCommand(@"INSERT INTO [dbo].[BankAccount] ([BA_ID],[BU_ID],[BU_Amount]) VALUES (@BA_ID,@BU_ID,@BU_Amount)",
                    //new SqlParameter[] {  ↓↓↓↓↓↓
                    new[] {
                    new SqlParameter("BA_ID",bankAccountEntity.BankAccountId),
                    new SqlParameter("BU_ID",bankAccountEntity.BankUserId),
                    new SqlParameter("BU_Amount",bankAccountEntity.Amount)
                });
        }

        public List<BankAccountEntity> getBankAccounts()
        {
            #region Version 1
            //using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnectionString"].ConnectionString))
            //{
            //    List<BankAccountEntity> bankAccountInfoList = new List<BankAccountEntity>();
            //    using (SqlCommand sqlCommand2 = new SqlCommand("SELECT * FROM BANKAccount", sqlConnection))
            //    {
            //        sqlConnection.Open();
            //        using (SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader())
            //        {
            //            while (sqlDataReader.Read())
            //            {
            //                bankAccountInfoList.Add(new BankAccountEntity()
            //                {
            //                    BankUserId = (Guid)sqlDataReader["BU_ID"],
            //                    BankAccountId = (Guid)sqlDataReader["BA_ID"],
            //                    Amount = (decimal)sqlDataReader["BU_Amount"]
            //                });
            //            }
            //        }
            //    }
            //    sqlConnection.Close();
            //    return bankAccountInfoList;
            //}
            #endregion
            return base.executeQueryCommand(@"SELECT [BA_ID],[BU_ID],[BU_Amount] FROM [BankAccount]",
                  new SqlParameter[] { }, (sqlDataReader) => new BankAccountEntity()
                  {
                      BankUserId = (Guid)sqlDataReader["BU_ID"],
                      BankAccountId = (Guid)sqlDataReader["BA_ID"],
                      Amount = (decimal)sqlDataReader["BU_Amount"]
                  });
        }
        public List<BankAccountEntity> getBankAccounts(decimal minAmount, decimal maxAmount)
        {
            #region Version 1
            //          using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnectionString"].ConnectionString))
            //          {
            //              List<BankAccountEntity> bankAccountInfoList = new List<BankAccountEntity>();
            //              using (SqlCommand sqlCommand2 = new SqlCommand(@"SELECT [BA_ID]
            //    ,[BU_ID]
            //    ,[BU_Amount]
            //FROM [BankAccount]
            //WHERE [BU_Amount] Between @minAmount AND @maxAmount ", sqlConnection))
            //              {
            //                  sqlCommand2.Parameters.AddWithValue("minAmount", minAmount);
            //                  sqlCommand2.Parameters.AddWithValue("maxAmount", maxAmount);
            //                  sqlConnection.Open();
            //                  using (SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader())
            //                  {
            //                      while (sqlDataReader.Read())
            //                      {
            //                          bankAccountInfoList.Add(new BankAccountEntity()
            //                          {
            //                              BankUserId = (Guid)sqlDataReader["BU_ID"],
            //                              BankAccountId = (Guid)sqlDataReader["BA_ID"],
            //                              Amount = (decimal)sqlDataReader["BU_Amount"]
            //                          });
            //                      }
            //                  }
            //              }
            //              sqlConnection.Close();
            //              return bankAccountInfoList;
            //          }
            #endregion

            return base.executeQueryCommand(@"SELECT [BA_ID],[BU_ID],[BU_Amount] FROM [BankAccount]
                                              WHERE [BU_Amount] Between @minAmount AND @maxAmount",
                  new SqlParameter[] {
                      new SqlParameter("minAmount",minAmount),
                      new SqlParameter("maxAmount",maxAmount)
                  }, (sqlDataReader) => new BankAccountEntity()
                  {
                      BankUserId = (Guid)sqlDataReader["BU_ID"],
                      BankAccountId = (Guid)sqlDataReader["BA_ID"],
                      Amount = (decimal)sqlDataReader["BU_Amount"]
                  });
        }

     
    }
}
