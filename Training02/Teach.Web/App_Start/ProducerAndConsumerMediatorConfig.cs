using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Teach.Core;
using TEC.Core.Scheduler.Timers;

namespace Teach.Web
{
    public class ProducerAndConsumerMediatorConfig
    {
        public static void initializeProducerAndConsumerMediator()
        {
            ProducerAndConsumerMediatorConfig.ProducerAndConsumerMediator = new ProducerAndConsumerMediator();
        }

        /// <summary>
        /// 設定或取得排程器管理物件
        /// </summary>
        internal static ProducerAndConsumerMediator ProducerAndConsumerMediator { set; get; }
    }
}