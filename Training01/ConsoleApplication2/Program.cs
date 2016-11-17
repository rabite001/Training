using ConsoleApplication2.Settings;
using ConsoleApplication2.Settings.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.Settings.Providers;

namespace ConsoleApplication2
{
    class Program
    {
        //private static Dictionary<SystemSettingEnum, object> systemSettingDictionary = new Dictionary<SystemSettingEnum, object>();
        static void Main(string[] args)
        {
            //systemSettingDictionary.Add(SystemSettingEnum.WelcomeMessage,
            //    System.Configuration.ConfigurationManager.AppSettings[SystemSettingEnum.WelcomeMessage.ToString()]);
            //systemSettingDictionary.Add(SystemSettingEnum.SupportedVersion,
            //   Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings[SystemSettingEnum.SupportedVersion.ToString()]));
            //Console.WriteLine(Program.systemSettingDictionary[SystemSettingEnum.WelcomeMessage]);
            //Console.WriteLine("最低支援版本:{0}", Program.systemSettingDictionary[SystemSettingEnum.SupportedVersion]);




            //FileSettingProvider<SystemSettingCollection, SystemSettingEnum, object, string> fileSettingProvider =
            //    new FileSettingProvider<SystemSettingCollection, SystemSettingEnum, object, string>(new FileInfo("D:\\123.dat"));
            //SystemSettingCollection systemSettingCollection = fileSettingProvider.load();
            //SqlServerSettingProvider<SystemSettingEnum, object, string> sqlServerSettingProvider = 
            //    new SqlServerSettingProvider<SystemSettingEnum, object, string>();
            //sqlServerSettingProvider.save(systemSettingCollection);
            //SystemSettingCollection cloned = sqlServerSettingProvider.load() as SystemSettingCollection;




            SystemSettingCollection systemSettingCollection = SettingCollectionFactory.SystemSettingCollection;
            systemSettingCollection[SystemSettingEnum.SupportedVersion] = 3;
            SettingCollectionFactory.refreshSystemSettingCollection();
            Console.WriteLine((string)systemSettingCollection[SystemSettingEnum.WelcomeMessage]);
            Console.WriteLine("最低支援版本:{0}", (int)systemSettingCollection[SystemSettingEnum.SupportedVersion]);
            Console.ReadKey();
        }
    }
}
