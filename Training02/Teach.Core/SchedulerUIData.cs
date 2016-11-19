using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teach.Core.TimerEvent;
using TEC.Core.Scheduler.Timers;

namespace Teach.Core
{
    public class SchedulerUIData
    {
        public SchedulerUIData(TimerManager timerManager)
        {
            //if (Object.ReferenceEquals(null, timerManager))
            if (timerManager == null)
            {
                throw new ArgumentNullException(nameof(timerManager));
            }
            this.TimerManager = timerManager;
            this.ConsumerTimerStorage = this.TimerManager.createTimersTimer(new ConsumerTimerEvent(),
                  new TimePeriodCollection(new[] { new TimeRange(DateTime.Now, DateTime.Now.AddSeconds(15)) }),
                  null, 3000, NextTimeEvaluationType.ExecutionEndTime);
            this.ProducerTimerStorage = this.TimerManager.createTimersTimer(new ProducerTimerEvent(),
                 new TimePeriodCollection(new[] { new TimeRange(DateTime.Now.AddSeconds(10), DateTime.Now.AddSeconds(35)) }),
                 null, 3000, NextTimeEvaluationType.ExecutionEndTime);
        }
        public void initial()
        {
            this.ConsumerTimerStorage.start();
            this.ProducerTimerStorage.start();
        }
        /// <summary>
        /// 設定或取得排程器管理物件
        /// </summary>
        private TimerManager TimerManager { set; get; }
        /// <summary>
        /// 設定或取得消費者排程器物件
        /// </summary>
        private TimersTimerStorage ConsumerTimerStorage { set; get; }
        /// <summary>
        /// 設定或取得生產者排程器物件
        /// </summary>
        private TimersTimerStorage ProducerTimerStorage { set; get; }
    }
}
