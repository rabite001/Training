using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teach.Core.Infos
{
    public class EventInfo
    {
        /// <summary>
        /// 設定或取得此事件的執行時間
        /// </summary>
        public TimeSpan ExecuteDuration { set; get; }
        /// <summary>
        /// 設定或取得事件名稱
        /// </summary>
        public string EventName { set; get; }
        /// <summary>
        /// 設定或取得建立時間
        /// </summary>
        public DateTime CreatedDateTime { set; get; }
    }
}
