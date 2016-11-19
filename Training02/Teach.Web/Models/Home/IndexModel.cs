using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEC.Core.Scheduler.Timers;

namespace Teach.Web.Models.Home
{
    public class IndexModel
    {
        /// <summary>
        /// 設定或取得排程器
        /// </summary>
        public TimerManager TimerManager { set; get; }
    }
}