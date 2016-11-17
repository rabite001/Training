using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.Scheduler.Timers;

namespace ConsoleApplication4
{
    public class PrintDateTimeTimerEvent : ITimerEvent
    {
        public void execute()
        {
            Console.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}");
            Console.WriteLine(String.Format("{0}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
            Console.WriteLine(String.Format("{0:yyyy/MM/dd HH:mm:ss}", DateTime.Now));
            //Console.WriteLine("{0:yyyy/MM/dd HH:mm:ss}", DateTime.Now);
        }
        public void Dispose()
        {
        }

    }
}
