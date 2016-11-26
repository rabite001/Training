using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teach.Core.Infos;

namespace Teach.Core
{
    /// <summary>
    /// 消費者與生產者中介物件
    /// </summary>
    public class ProducerAndConsumerMediator
    {
        public ProducerAndConsumerMediator()
        {
            this.EventInfoConcurrentQueue = new ConcurrentQueue<EventInfo>();
        }
        /// <summary>
        /// 佇列待執行的事件
        /// </summary>
        /// <param name="eventInfo">用於佇列的資訊</param>
        /// <exception cref="ArgumentNullException">當 <paramref name="eventInfo"/> 參考至 null 時擲出。</exception>
        public void push(EventInfo eventInfo)
        {
            if (eventInfo == null)
            {
                throw new ArgumentNullException(nameof(eventInfo));
            }
            this.EventInfoConcurrentQueue.Enqueue(eventInfo);
        }
        /// <summary>
        /// 沒有了傳回 null
        /// </summary>
        /// <returns></returns>
        public EventInfo pop()
        {
            EventInfo eventInfo;
            if (!this.EventInfoConcurrentQueue.TryDequeue(out eventInfo))
            {
                return null;
            }
            return eventInfo;
        }
        /// <summary>
        /// 設定或取得執行的佇列
        /// </summary>
        private ConcurrentQueue<EventInfo> EventInfoConcurrentQueue { set; get; }
    }
}
