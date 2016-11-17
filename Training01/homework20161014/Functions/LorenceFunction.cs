using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace homework20161014.Functions
{
    public class LorenceFunction:IDisposable
    {
        public LorenceFunction()
        {
            this.IntThreadSafeObservableCollection = new TEC.Core.Collections.ThreadSafeObservableCollection<int>();
            this.IntThreadSafeObservableCollection.CollectionChanging += this.IntThreadSafeObservableCollection_CollectionChanging;
        }

        private void IntThreadSafeObservableCollection_CollectionChanging(object sender, TEC.Core.Collections.CollectionChangingEventArgs e)
        {
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                if (this.IntThreadSafeObservableCollection.Contains((int)e.NewItems[0]))
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 執行與釋放 (Free)、釋放 (Release) 或重設 Unmanaged 資源相關聯之應用程式定義的工作。
        /// </summary>
        public void Dispose()
        {
            this.IntThreadSafeObservableCollection.CollectionChanging -= this.IntThreadSafeObservableCollection_CollectionChanging;
            this.IntThreadSafeObservableCollection.Clear();
            this.IntThreadSafeObservableCollection = null;
        }

        public void test(int x)
        {
            //Do something
            this.IntThreadSafeObservableCollection.Add(x);
        }
        private TEC.Core.Collections.ThreadSafeObservableCollection<int> IntThreadSafeObservableCollection { set; get; }
    }
}