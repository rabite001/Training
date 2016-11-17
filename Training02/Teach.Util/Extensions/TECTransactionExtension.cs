using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.Transactions;
using TEC.Core.Transactions.EnlistmentNotifications;

namespace Teach.Util.Extensions
{
    public static class TECTransactionExtension
    {
        public static void setContextValue<T>(this SequentialTransactionManager sequentialTransactionManager, T value)
        {
            sequentialTransactionManager.setContextValue(value.GetType().FullName, value);
        }
        public static void setContextValue<T>(this EnlistmentNotificationBase enlistmentNotificationBase, T value)
        {
            enlistmentNotificationBase.setContextValue(value.GetType().FullName, value);
        }

        public static T getContextValue<T>(this SequentialTransactionManager sequentialTransactionManager)
        {
            return (T)sequentialTransactionManager.getContextValue(typeof(T).FullName);
        }
        public static T getContextValue<T>(this EnlistmentNotificationBase enlistmentNotificationBase)
        {
            return (T)enlistmentNotificationBase.getContextValue(typeof(T).FullName);
        }
    }
}
