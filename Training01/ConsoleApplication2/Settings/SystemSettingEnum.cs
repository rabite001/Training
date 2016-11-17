using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Settings
{
    public enum SystemSettingEnum
    {
        /// <summary>
        /// 歡迎訊息，屬於<see cref="System.String"/>
        /// </summary>
        WelcomeMessage,
        /// <summary>
        /// 系統最低支援版本，屬於<see cref="System.Int32"/>
        /// </summary>
        SupportedVersion
    }
}
