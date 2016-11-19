using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Teach.Core;
using TEC.Core.Scheduler.Timers;

namespace Teach.Web
{
    public class HearConfig
    {
        public static void initializeHear()
        {
            HearConfig.Hear = new Hear();
        }

        /// <summary>
        /// 設定或取得排程器管理物件
        /// </summary>
        internal static Hear Hear { set; get; }
    }
}