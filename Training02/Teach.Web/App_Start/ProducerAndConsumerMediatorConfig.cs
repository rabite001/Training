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
            ((INotifyCollectionChanged)ProducerAndConsumerMediatorConfig.ProducerAndConsumerMediator.EventInfoConcurrentQueue).CollectionChanged += ProducerAndConsumerMediatorConfig.ProducerAndConsumerMediatorConfig_CollectionChanged;
        }

        private static void ProducerAndConsumerMediatorConfig_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems!=null)
            {

            }

            if (e.OldItems!=null)
            {

            }


        }

        /// <summary>
        /// 設定或取得排程器管理物件
        /// </summary>
        internal static ProducerAndConsumerMediator ProducerAndConsumerMediator { set; get; }
    }
}