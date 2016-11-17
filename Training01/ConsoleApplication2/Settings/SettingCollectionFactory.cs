using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.Settings.Providers;

namespace ConsoleApplication2.Settings
{
    public class SettingCollectionFactory
    {
        private static readonly object syncObject = new object();
        private static SystemSettingCollection systemSettingCollection;
        //private static Lazy<SystemSettingCollection> systemSettingCollectionLazy;
        static SettingCollectionFactory()
        {
            //SettingCollectionFactory.systemSettingCollectionLazy = new Lazy<SystemSettingCollection>(() =>
            //    new FileSettingProvider<SystemSettingCollection, SystemSettingEnum, object, string>(new FileInfo("D:\\123.dat")).load() as SystemSettingCollection);
            //FileSettingProvider<SystemSettingCollection, SystemSettingEnum, object, string> fileSettingProvider =
            //               new FileSettingProvider<SystemSettingCollection, SystemSettingEnum, object, string>(new FileInfo("D:\\123.dat"));
            //SettingCollectionFactory.systemSettingCollection = fileSettingProvider.load() as SystemSettingCollection;
        }
        public static void refreshSystemSettingCollection()
        {
            lock (SettingCollectionFactory.syncObject)
            {
                FileSettingProvider<SystemSettingCollection, SystemSettingEnum, object, string> fileSettingProvider =
                         new FileSettingProvider<SystemSettingCollection, SystemSettingEnum, object, string>(new FileInfo("D:\\123.dat"));
                SystemSettingCollection newSystemSettingCollection = fileSettingProvider.load() as SystemSettingCollection;
                SystemSettingObjectEqualityComparer systemSettingObjectEqualityComparer = new SystemSettingObjectEqualityComparer();
                IList<KeyValuePair<SystemSettingEnum, object>> difSettings = SettingCollectionFactory.SystemSettingCollection.getDifferentSettings(newSystemSettingCollection, systemSettingObjectEqualityComparer);
                difSettings.ToList().ForEach(kvp => SettingCollectionFactory.SystemSettingCollection[kvp.Key] = kvp.Value);
            }
        }
        private class SystemSettingObjectEqualityComparer : IEqualityComparer<object>
        {
            public new bool Equals(object x, object y)
            {
                // 自己搞
                return true;
            }

            public int GetHashCode(object obj)
            {
                return obj.GetHashCode();
            }
        }
        public static SystemSettingCollection SystemSettingCollection
        {
            get
            {
                //return SettingCollectionFactory.systemSettingCollectionLazy.Value;
                if (SettingCollectionFactory.systemSettingCollection == null)
                {
                    lock (SettingCollectionFactory.syncObject)
                    {
                        if (SettingCollectionFactory.systemSettingCollection == null)
                        {
                            FileSettingProvider<SystemSettingCollection, SystemSettingEnum, object, string> fileSettingProvider =
                              new FileSettingProvider<SystemSettingCollection, SystemSettingEnum, object, string>(new FileInfo("D:\\123.dat"));
                            SettingCollectionFactory.systemSettingCollection = fileSettingProvider.load() as SystemSettingCollection;
                        }
                    }
                }
                return SettingCollectionFactory.systemSettingCollection;
            }
        }
    }
}
