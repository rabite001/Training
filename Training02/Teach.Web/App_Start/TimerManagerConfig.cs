using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
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
                        TimerManagerConfig.sendTimerData(timerStorage, false);
                        timerStorage.PropertyChanged += TimerManagerConfig.TimerStorage_PropertyChanged;
                    });
            }
            if (e.OldItems != null)
            {
                e.OldItems.Cast<TimerStorageBase>().ToList()
                   .ForEach(timerStorage =>
                   {
                       TimerManagerConfig.sendTimerData(timerStorage, true);
                       timerStorage.PropertyChanged -= TimerManagerConfig.TimerStorage_PropertyChanged;
                   });
            }
        }

        private static void TimerStorage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            TimerStorageBase timerStorageBase = sender as TimerStorageBase;
            TimerManagerConfig.sendTimerData(timerStorageBase, false);
            if (e.PropertyName == nameof(timerStorageBase.TimerStatus) && timerStorageBase.TimerStatus == TimerStatus.Stopped)
            {
                timerStorageBase.Dispose();
            }
        }
        /// <summary>
        /// 發送
        /// </summary>
        /// <param name="timerStorageBase"></param>
        private static void sendTimerData(TimerStorageBase timerStorageBase, bool isRemoved)
        {

            
            if (timerStorageBase.TimePeriodCollection == null)
            {
                GlobalHost.ConnectionManager.GetHubContext<Controllers.TimerManagerHub>()
                       .Clients.All.data(JsonConvert.SerializeObject(new
                       {
                           @DataId = ((dynamic)timerStorageBase.ITimerEvent).Id,
                           @Name = ((dynamic)timerStorageBase.ITimerEvent).Name,
                           @StartDateTime = String.Empty,
                           @EndDateTime = String.Empty,
                           @NextExecutionDateTime = String.Empty,
                           @Status = ((TimerStatus)timerStorageBase.TimerStatus).ToString(),
                           @IsRemoved = isRemoved
                       }));
            }
            else
            {
                GlobalHost.ConnectionManager.GetHubContext<Controllers.TimerManagerHub>()
                       .Clients.All.data(JsonConvert.SerializeObject(new
                       {
                           @DataId = ((dynamic)timerStorageBase.ITimerEvent).Id,
                           @Name = ((dynamic)timerStorageBase.ITimerEvent).Name,
                           @StartDateTime = timerStorageBase.TimePeriodCollection.First().Start,
                           @EndDateTime = timerStorageBase.TimePeriodCollection.First().End,
                           @NextExecutionDateTime = timerStorageBase.NextExecuteDateTime,
                           @Status = ((TimerStatus)timerStorageBase.TimerStatus).ToString(),
                           @IsRemoved = isRemoved
                       }));
            }
        }
        /// <summary>
        /// 設定或取得排程器管理物件
        /// </summary>
        internal static TimerManager TimerManager { set; get; }
    }
}