using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TEC.Core.Scheduler.Timers;

namespace Teach.Core.TimerEvent
{
    public class ProducerTimerEvent : ITimerEvent
    {
        public ProducerTimerEvent(ProducerAndConsumerMediator hear)
        {
            this.Hear = hear;
            this.Id = Guid.NewGuid();
            this.Name = $"生產者_{this.Id}";
        }
        public void execute()
        {
            this.Hear.push(new Infos.EventInfo()
            {
                CreatedDateTime = DateTime.Now,
                EventName = $"事件_{this.Name}_" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                ExecuteDuration = TimeSpan.FromMilliseconds(new Random(Guid.NewGuid().GetHashCode()).Next(2000))
            });
        }
        public void Dispose()
        {
        }
        public Guid Id { private set; get; }
        public string Name { private set; get; }

        private ProducerAndConsumerMediator Hear { set; get; }
    }
}
