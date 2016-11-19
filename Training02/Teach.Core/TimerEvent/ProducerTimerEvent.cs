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
        public ProducerTimerEvent(Hear hear)
        {
            this.Hear = hear;
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
        public string Name { private set; get; } = $"生產者_{Guid.NewGuid()}";

        private Hear Hear { set; get; }
    }
}
