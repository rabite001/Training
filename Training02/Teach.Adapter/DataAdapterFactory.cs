using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Teach.Adapter.Database;
using Teach.Util.Enums;

namespace Teach.Adapter
{
    public class DataAdapterFactory
    {
        private static readonly string dbNamespaceTemplate = "Teach.Adapter.Database.{0}.{1}.{2}";
        public DataAdapterFactory(DataSources dataSources)
        {
            this.DataSource = dataSources;
        }
        //public static IBankAccountDb getBankAccountDb(DataSources dataSources)
        //{
        //    return new BankAccountData();
        //}
        /// <summary>
        /// 取得 BankAccount DB
        /// </summary>
        public IBankAccountDb BankAccountDb
        {
            get
            {
                return (IBankAccountDb)Assembly.GetAssembly(typeof(DataAdapterFactory)).CreateInstance(
                    String.Format(DataAdapterFactory.dbNamespaceTemplate, this.DataSource.ToString(), "Bank", nameof(BankAccountDb)));

                //switch (this.DataSource)
                //{
                //    case DataSources.Oracle:
                //        return new Database.Oracle.Bank.BankAccountDb();
                //    case DataSources.SqlServer:
                //        return new Database.SqlServer.Bank.BankAccountDb();
                //    default:
                //        throw new NotImplementedException();
                //}
            }
        }
        /// <summary>
        /// 取得 BankUser DB
        /// </summary>
        public IBankUserDb BankUserDb
        {
            get
            {
                return (IBankUserDb)Assembly.GetAssembly(typeof(DataAdapterFactory)).CreateInstance(
                    String.Format(DataAdapterFactory.dbNamespaceTemplate, this.DataSource.ToString(), "Bank", nameof(BankUserDb)));
                //switch (this.DataSource)
                //{
                //    case DataSources.Oracle:
                //        return new Database.Oracle.Bank.BankUserDb();
                //    case DataSources.SqlServer:
                //        return new Database.SqlServer.Bank.BankUserDb();
                //    default:
                //        throw new NotImplementedException();
                //}
            }
        }
        private DataSources DataSource { set; get; }
    }
}
