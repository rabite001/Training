using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teach.Core.Infos;

namespace Teach.Core.ObservableConcurrentQueue
{
    public class ObservableConcurrentQueue<T> : ConcurrentQueue<T>, INotifyCollectionChanged
    {
        // TryDequeue問題
        public event NotifyCollectionChangedEventHandler CollectionChanged;
      
        public new virtual void Enqueue(T item)
        {
            base.Enqueue(item);
        }
        public new virtual bool TryDequeue(out T result)
        {
            T baseResult;
            bool baseTryDequeueBool;
            baseTryDequeueBool=base.TryDequeue(out baseResult);
            result = baseResult;
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, result));
            return baseTryDequeueBool;

        }
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            this.RaiseCollectionChanged(e);
        }
        private void RaiseCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (this.CollectionChanged != null)
                this.CollectionChanged(this, e);
        }


    }
}

