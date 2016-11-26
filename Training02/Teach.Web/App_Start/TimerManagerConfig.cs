using Microsoft.AspNet.SignalR;
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
            TimerManagerConfig.sendTimerData();
        }

        private static void TimerStorage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            TimerStorageBase timerStorageBase = sender as TimerStorageBase;
            if (e.PropertyName == nameof(timerStorageBase.TimerStatus) && timerStorageBase.TimerStatus == TimerStatus.Stopped)
            {
                timerStorageBase.Dispose();
            }
            TimerManagerConfig.sendTimerData();
        }
        private static void sendTimerData()
        {
            string result = String.Join("", TimerManagerConfig.TimerManager.ManagedTimerReadOnlyObservableCollection
                    .ToList()
                    .Cast<TimerStorageBase>()
                    .Select(timerStorageBase =>
                    {
                        string color = String.Empty;
                        switch (timerStorageBase.TimerStatus)
                        {
                            case TimerStatus.Executing:
                                color = "success";
                                break;
                            case TimerStatus.NotStart:
                                color = "default";
                                break;
                            case TimerStatus.Pending:
                                color = "warning";
                                break;
                            case TimerStatus.Stopped:
                                color = "info";
                                break;
                        }
                        return $@"
<tr>
    <td>{(((dynamic)timerStorageBase.ITimerEvent).Name)}</td>
    <td>{timerStorageBase.TimePeriodCollection.First().Start} ~ {timerStorageBase.TimePeriodCollection.First().End}</td>
    <td>{(timerStorageBase.NextExecuteDateTime.HasValue ? timerStorageBase.NextExecuteDateTime.Value.ToString() : "已結束")}</td>
    <td>
        <span class='label label-{color}'>
            {timerStorageBase.TimerStatus.ToString()}
        </span>
    </td>

</tr>";
                    }));
            GlobalHost.ConnectionManager.GetHubContext<Controllers.TestHub>()
                        .Clients.All.receiveTimersData(result);
        }
        /// <summary>
        /// 設定或取得排程器管理物件
        /// </summary>
        internal static TimerManager TimerManager { set; get; }
    }
}