using ConsoleApplication7.Infos;
using ConsoleApplication7.UIData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    List<BankUserInfo> bankUserInfoList = new List<BankUserInfo>();
        //    SqlConnection sqlConnection = new SqlConnection(@"Data Source=localhost;Initial Catalog=Teach20161001;Integrated Security=False;User Id=Teach20161001;Password=Teach20161001;");
        //    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM BANKUSER", sqlConnection);
        //    sqlConnection.Open();
        //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        //    while (sqlDataReader.Read())
        //    {
        //        bankUserInfoList.Add(new BankUserInfo()
        //        {
        //            BankUserId = (Guid)sqlDataReader["BU_ID"],
        //            UserName = sqlDataReader["BU_Name"].ToString()
        //        });
        //    }
        //    sqlConnection.Close();

        //    List<BankAccountInfo> bankAccountInfoList = new List<BankAccountInfo>();
        //    SqlCommand sqlCommand2 = new SqlCommand("SELECT * FROM BANKAccount", sqlConnection);
        //    sqlConnection.Open();
        //    sqlDataReader = sqlCommand2.ExecuteReader();
        //    while (sqlDataReader.Read())
        //    {
        //        bankAccountInfoList.Add(new BankAccountInfo()
        //        {
        //            BankUserId = (Guid)sqlDataReader["BU_ID"],
        //            BankAccountId = (Guid)sqlDataReader["BA_ID"],
        //            Amount = (decimal)sqlDataReader["BU_Amount"]
        //        });
        //    }
        //    sqlConnection.Close();
        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {
            BankUIData bankUIData = new BankUIData();
            var temp = bankUIData.getBankUserInfo();
            var temp2 = bankUIData.getBankUserInfo2();
            foreach (BankUserInfo bankUserInfo in temp)
            {
                Console.WriteLine(bankUserInfo.UserName);
            }
            int j = 0;
            foreach (BankUserInfo bankUserInfo in temp2)
            {
                Console.WriteLine(bankUserInfo.UserName);
            }
            temp2.ToList();
        }
    }
}
