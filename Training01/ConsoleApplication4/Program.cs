using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TEC.Core.Scheduler.Timers;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerManager timerManager = new TimerManager();
            //Bind Changed Event
            ((INotifyCollectionChanged)timerManager.ManagedTimerReadOnlyObservableCollection)
                .CollectionChanged += Program.Program_CollectionChanged;
            PrintDateTimeTimerEvent printDateTimeTimerEvent = new PrintDateTimeTimerEvent();
            List<TimeRange> effectiveTimeRangeList = new List<TimeRange>()
            {
                new TimeRange(DateTime.Now,DateTime.MaxValue)
            };
            TimersTimerStorage timersTimerStorage = timerManager.createTimersTimer(printDateTimeTimerEvent,
                new TimePeriodCollection(effectiveTimeRangeList), null, 1000,
                NextTimeEvaluationType.ExecutionEndTime);
            // DEMO 加入兩個一樣的東西
            //printDateTimeTimerEvent = new PrintDateTimeTimerEvent();
            //timersTimerStorage = timerManager.createTimersTimer(printDateTimeTimerEvent,
            //    new TimePeriodCollection(effectiveTimeRangeList), null, 1000,
            //    NextTimeEvaluationType.ExecutionEndTime);

            timersTimerStorage.PropertyChanged += Program.TimersTimerStorage_PropertyChanged;
            timersTimerStorage.start();
            new Thread(new ParameterizedThreadStart(arg =>
            {
                System.Threading.Thread.Sleep(3000);
                timersTimerStorage.Dispose();
            })).Start();
            //timerManager.getManagedTimerStorage(typeof(PrintDateTimeTimerEvent));
            //timerManager.getManagedTimerStorage(printDateTimeTimerEvent);
            //timerManager.ManagedTimerReadOnlyObservableCollection.Where(t => ((TimerStorageBase)t).TimerStatus == TimerStatus.Executing);
            Console.ReadKey();
        }

        private static void Program_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            TimerStorageBase timerStorageBase;
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                timerStorageBase = e.NewItems[0] as TimerStorageBase;
                Console.WriteLine($"{timerStorageBase.ITimerEvent.GetType().Name} 已被安排排程作業");
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                timerStorageBase = e.OldItems[0] as TimerStorageBase;
                Console.WriteLine($"{timerStorageBase.ITimerEvent.GetType().Name} 已被移除排程作業");

            }
        }

        private static void TimersTimerStorage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            TimerStorageBase timerStorageBase = sender as TimerStorageBase;
            if (e.PropertyName == nameof(timerStorageBase.TimerStatus))
            {
                Console.WriteLine($"{e.PropertyName} 的狀態變化為 {timerStorageBase.TimerStatus}");
            }
            else if (e.PropertyName == nameof(timerStorageBase.NextExecuteDateTime))
            {
                Console.WriteLine($"{e.PropertyName} 的時間變化為 {timerStorageBase.NextExecuteDateTime}");

            }
        }
    }
}
