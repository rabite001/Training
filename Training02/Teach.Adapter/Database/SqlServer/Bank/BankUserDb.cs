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
    public class BankUserDb : SqlDataBase, IBankUserDb
    {
        public void addBankUser(BankUserEntity bankUserEntity)
        {
            base.executeNonQueryCommand(@"INSERT INTO [dbo].[BankUser]
           ([BU_ID]
           ,[BU_Name])
     VALUES
           (@BU_ID
           ,@BU_Name)",
                  //new SqlParameter[] {  ↓↓↓↓↓↓
                  new[] {
                    new SqlParameter("BU_ID",bankUserEntity.BankUserId),
                    new SqlParameter("BU_Name",bankUserEntity.UserName)
              });
        }
        public void updateLastLoginDate(Guid useId, DateTime lastLoginDate)
        {
            base.executeNonQueryCommand(@"UPDATE [dbo].[BankUser]
   SET [BU_LastLoginDate] = @BU_LastLoginDate
 WHERE [BU_ID] = @BU_ID",
                 new[] {
                    new SqlParameter("BU_ID",useId),
                    new SqlParameter("BU_LastLoginDate",lastLoginDate)
             });
        }
        public List<BankUserEntity> getBankUsers()
        {
            return base.executeQueryCommand("SELECT * FROM BANKUser", new SqlParameter[0], dataReader => new BankUserEntity()
            {
                BankUserId = (Guid)dataReader["BU_ID"],
                UserName = dataReader["BU_Name"].ToString(),
                LastLoginDate = dataReader["BU_LastLoginDate"] == DBNull.Value ? null : (DateTime?)dataReader["BU_LastLoginDate"]
            });
            //SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnectionString"].ConnectionString);
            //List<BankUserEntity> bankUserInfoList = new List<BankUserEntity>();
            //SqlCommand sqlCommand2 = new SqlCommand("SELECT * FROM BANKUser", sqlConnection);
            //sqlConnection.Open();
            //SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
            //while (sqlDataReader.Read())
            //{
            //    bankUserInfoList.Add(new BankUserEntity()
            //    {
            //        BankUserId = (Guid)sqlDataReader["BU_ID"],
            //        UserName = sqlDataReader["BU_Name"].ToString()
            //    });
            //}
            //sqlConnection.Close();
            //return bankUserInfoList;
        }
    }
}
