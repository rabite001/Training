using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teach.Core.Infos;

namespace Teach.Core
{
    /// <summary>
    /// 聽!
    /// </summary>
    public class Hear
    {
        public Hear()
        {
            this.EventInfoList = new List<EventInfo>();
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
            this.EventInfoList.Add(eventInfo);
        }
        /// <summary>
        /// 沒有了傳回 null
        /// </summary>
        /// <returns></returns>
        public EventInfo pop()
        {
            if (this.EventInfoList.Count == 0)
            {
                return null;
            }
            EventInfo eventInfo = this.EventInfoList.First();
            this.EventInfoList.Remove(eventInfo);
            return eventInfo;
        }
        /// <summary>
        /// 設定或取得執行的佇列
        /// </summary>
        private List<EventInfo> EventInfoList { set; get; }
    }
}
