using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Teach.Core.Infos;
using TEC.Core.Scheduler.Timers;

namespace Teach.Core.TimerEvent
{
    public class ConsumerTimerEvent : ITimerEvent
    {
        public ConsumerTimerEvent(ProducerAndConsumerMediator hear)
        {
            this.Hear = hear;
            this.Id = Guid.NewGuid();
            this.Name = $"消費者_{this.Id}";
        }
        public void execute()
        {
            EventInfo eventInfo = this.Hear.pop();
            if (eventInfo != null)
            {
                Thread.Sleep(eventInfo.ExecuteDuration);
            }
        }
        public void Dispose()
        {
        }
        public Guid Id { private set; get; }
        public string Name { private set; get; }

        private ProducerAndConsumerMediator Hear { set; get; }
    }
}
