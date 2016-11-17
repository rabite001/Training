using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teach.Adapter.Database.SqlServer
{
    public abstract class SqlDataBase
    {
        /// <summary>
        /// 以指定的 SQL 參數集合，執行 SQL 查詢陳述式，並回傳指定型別的結果清單。
        /// </summary>
        /// <typeparam name="T">回傳資料的型別</typeparam>
        /// <param name="sqlCommand">用於與 SQL 建立連線後，執行指定的查詢字串</param>
        /// <param name="parameters">執行 SQL 查詢陳述式時，SQL 所需的參數</param>
        /// <param name="getResultFunc">用於將查詢結果轉換為回傳型別的方法封裝</param>
        /// <returns></returns>
        protected List<T> executeQueryCommand<T>(string sqlCommand, SqlParameter[] parameters, Func<SqlDataReader, T> getResultFunc)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnectionString"].ConnectionString))
            {
                List<T> resultList = new List<T>();
                using (SqlCommand sqlCommand2 = new SqlCommand(sqlCommand, sqlConnection))
                {
                    parameters.ToList().ForEach(paramter => sqlCommand2.Parameters.Add(paramter));
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            resultList.Add(getResultFunc(sqlDataReader));
                        }
                    }
                }
                sqlConnection.Close();
                return resultList;
            }
        }
        /// <summary>
        /// 以 SQL 參數集合，執行 SQL 非查詢類型陳述式(Non Query Command)，例: Insert, Update, Delete
        /// </summary>
        /// <param name="sqlCommand">用於與 SQL 建立連線後，執行指定的非查詢類型陳述式</param>
        /// <param name="parameters">執行 SQL 非查詢類型陳述式時，SQL 所需的參數</param>
        /// <returns>針對連接執行 Transact-SQL 陳述式，並傳回受影響的資料列數目</returns>
        protected int executeNonQueryCommand(string sqlCommand, SqlParameter[] parameters)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnectionString"].ConnectionString))
            {
                using (SqlCommand sqlCommand2 = new SqlCommand(sqlCommand, sqlConnection))
                {
                    parameters.ToList().ForEach(paramter => sqlCommand2.Parameters.Add(paramter));
                    sqlConnection.Open();
                    int result = sqlCommand2.ExecuteNonQuery();
                    sqlConnection.Close();
                    return result;
                }
            }
        }
    }
}
