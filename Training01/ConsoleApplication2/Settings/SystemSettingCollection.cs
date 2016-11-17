using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.Settings.Collections;

namespace ConsoleApplication2.Settings
{
    [Serializable]
    public class SystemSettingCollection : SettingCollectionBase<SystemSettingEnum, object, string>
    {
        public SystemSettingCollection()
            : base("SystemSettingCollection")
        {
        }

        public override object getDefaultValue(SystemSettingEnum key)
        {
            switch (key)
            {
                case SystemSettingEnum.SupportedVersion:
                    return 1;
                case SystemSettingEnum.WelcomeMessage:
                    return "歡迎使用";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
