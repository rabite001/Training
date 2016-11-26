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
        public SchedulerUIData(TimerManager timerManager, ProducerAndConsumerMediator producerAndConsumerMediator)
        {
            //if (Object.ReferenceEquals(null, timerManager))
            if (timerManager == null)
            {
                throw new ArgumentNullException(nameof(timerManager));
            }
            if (producerAndConsumerMediator == null)
            {
                throw new ArgumentNullException(nameof(producerAndConsumerMediator));
            }
            this.TimerManager = timerManager;
            this.ProducerAndConsumerMediator = producerAndConsumerMediator;
        }
        /// <summary>
        /// 建立生產者排程器
        /// </summary>
        /// <returns></returns>
        public TimerStorageBase createProducerTimer()
        {
            return this.TimerManager.createTimersTimer(new ProducerTimerEvent(this.ProducerAndConsumerMediator),
                    new TimePeriodCollection(new[] { new TimeRange(DateTime.Now, DateTime.MaxValue) }),
                    null, 3000, NextTimeEvaluationType.ExecutionEndTime);
        }
        /// <summary>
        /// 建立消費者排程器
        /// </summary>
        /// <returns></returns>
        public TimerStorageBase createConsumerTimer()
        {
            return this.TimerManager.createTimersTimer(new ConsumerTimerEvent(this.ProducerAndConsumerMediator),
                  new TimePeriodCollection(new[] { new TimeRange(DateTime.Now, DateTime.MaxValue) }),
                  null, 3000, NextTimeEvaluationType.ExecutionEndTime);
        }
        /// <summary>
        /// 設定或取得中介物件
        /// </summary>
        private ProducerAndConsumerMediator ProducerAndConsumerMediator { set; get; }
        /// <summary>
        /// 設定或取得排程器管理物件
        /// </summary>
        private TimerManager TimerManager { set; get; }
        /// <summary>
        /// 設定或取得消費者排程器物件
        /// </summary>
        public List<TimersTimerStorage> ConsumerTimerStorage
        {
            get
            {
                return this.TimerManager.getManagedTimerStorage(typeof(ConsumerTimerEvent))
                    .Cast<TimersTimerStorage>()
                    .ToList();
            }
        }
        /// <summary>
        /// 設定或取得生產者排程器物件
        /// </summary>
        private List<TimersTimerStorage> ProducerTimerStorage
        {
            get
            {
                return this.TimerManager.getManagedTimerStorage(typeof(ProducerTimerEvent))
                    .Cast<TimersTimerStorage>()
                    .ToList();
            }
        }
    }
}
