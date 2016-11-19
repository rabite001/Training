using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using TEC.Core.Scheduler.Timers;

namespace Teach.Web
{
    public class TimerManagerConfig
    {
        public static void initializeTimerManager()
        {
            TimerManagerConfig.TimerManager = new TimerManager();
            ((INotifyCollectionChanged)TimerManagerConfig.TimerManager.ManagedTimerReadOnlyObservableCollection).CollectionChanged
                += TimerManagerConfig.TimerManagerConfig_CollectionChanged;
        }

        private static void TimerManagerConfig_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                e.NewItems.Cast<TimerStorageBase>().ToList()
                    .ForEach(timerStorage =>
                    {
                        timerStorage.PropertyChanged += TimerManagerConfig.TimerStorage_PropertyChanged;
                    });
            }
            if (e.OldItems != null)
            {
                e.OldItems.Cast<TimerStorageBase>().ToList()
                   .ForEach(timerStorage =>
                   {
                       timerStorage.PropertyChanged -= TimerManagerConfig.TimerStorage_PropertyChanged;
                   });
            }
        }

        private static void TimerStorage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            TimerStorageBase timerStorageBase = sender as TimerStorageBase;
            if (e.PropertyName == nameof(timerStorageBase.TimerStatus) && timerStorageBase.TimerStatus == TimerStatus.Stopped)
            {
                timerStorageBase.Dispose();
            }
        }

        /// <summary>
        /// 設定或取得排程器管理物件
        /// </summary>
        internal static TimerManager TimerManager { set; get; }
    }
}