using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TEC.Core.Scheduler.Timers;

namespace Teach.Core.TimerEvent
{
    public class ConsumerTimerEvent : ITimerEvent
    {
        public ConsumerTimerEvent()
        {
        }
        public void execute()
        {
            Thread.Sleep(new Random(Guid.NewGuid().GetHashCode()).Next(2000) + 1000);
        }
        public void Dispose()
        {
        }
        public string Name { private set; get; } = $"消費者_{Guid.NewGuid()}";
    }
}
