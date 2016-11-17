using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Antony
    {
        /// <summary>
        /// 開始揍人
        /// </summary>
        /// <param name="personName">被揍的人</param>
        public void punchSomeBody(string personName)
        {
            string tool = "Apple";
            int count = 2;
            PunchingEventArgs punchingEventArgs = new PunchingEventArgs(personName, count, tool);
            this.OnPunching?.Invoke(this, punchingEventArgs);
            if (punchingEventArgs.Cancel)
            {
                return;
            }
            System.Threading.Thread.Sleep(3000);
            PunchedEventArgs punchedEventArgs = new PunchedEventArgs(personName, count, tool);
            //if (this.Punch != null)
            //{
            //    this.Punch(this, EventArgs.Empty);
            //}
            //  ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
            this.OnPunched?.Invoke(this, punchedEventArgs);
            //打完了
        }
        public event EventHandler<PunchingEventArgs> OnPunching;
        public event EventHandler<PunchedEventArgs> OnPunched;
    }
}
