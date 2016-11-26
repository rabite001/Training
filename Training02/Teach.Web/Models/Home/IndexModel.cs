﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Teach.Core.Infos;
using TEC.Core.Scheduler.Timers;

namespace Teach.Web.Models.Home
{
    public class IndexModel
    {
        /// <summary>
        /// 設定或取得排程器
        /// </summary>
        public TimerManager TimerManager { set; get; }

        public List<EventInfo> EventInfoListLog { set; get; }
    }
}