using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Antony antony = new Antony();
            antony.OnPunching -= Program.Antony_OnPunching;
            antony.OnPunching += Program.Antony_OnPunching;
            antony.OnPunched -= Program.Antony_OnPunched;
            antony.OnPunched += Program.Antony_OnPunched;
            antony.punchSomeBody("Yumi");
            Console.ReadKey();
        }

        private static void Antony_OnPunching(object sender, PunchingEventArgs e)
        {
            Console.WriteLine("Antony 要打{1}啦! @{0:yyyy/MM/dd HH:mm:ss}", DateTime.Now, e.Name);
            e.Cancel = true;
        }

        private static void Antony_OnPunched(object sender, PunchedEventArgs e)
        {
            Console.WriteLine("Antony 打了{1}({2}下)! @{0:yyyy/MM/dd HH:mm:ss}", DateTime.Now, e.Name, e.Count);
        }
    }
}
