using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teach.Adapter;

namespace Teach.Core
{
    public static class UIDataConfig
    {
        private static Lazy<DataAdapterFactory> sqlServerDataAdapterFactoryLazy;
        private static Lazy<DataAdapterFactory> oracleDataAdapterFactoryLazy;
        static UIDataConfig()
        {
            UIDataConfig.sqlServerDataAdapterFactoryLazy = new Lazy<DataAdapterFactory>(() => new DataAdapterFactory(Util.Enums.DataSources.SqlServer));
            UIDataConfig.oracleDataAdapterFactoryLazy = new Lazy<DataAdapterFactory>(() => new DataAdapterFactory(Util.Enums.DataSources.Oracle));
        }
        internal static DataAdapterFactory DefaultDataAdapterFactory
        {
            get
            {
                return UIDataConfig.sqlServerDataAdapterFactoryLazy.Value;
            }
        }
        internal static DataAdapterFactory SecondaryDataAdapterFactory
        {
            get
            {
                return UIDataConfig.oracleDataAdapterFactoryLazy.Value;
            }
        }
    }
}
