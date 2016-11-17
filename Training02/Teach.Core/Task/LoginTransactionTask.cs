using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.Transactions.EnlistmentNotifications;
using Teach.Util.Extensions;

namespace Teach.Core.Task
{
    internal class LoginTransactionTask : EnlistmentNotificationBase
    {
        protected override void executeInternal()
        {
            BankUIData bankUIData = new BankUIData();
            bankUIData.setLastLoginDate(this.AccountId, this.LoginDateTime);
        }
        protected override void rollbackInternal()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo($@"D:\Teach\{this.AccountId}");
            if (directoryInfo.Exists)
            {
                FileInfo fileInfo = new FileInfo(Path.Combine(directoryInfo.FullName, $"{this.LoginDateTime.ToString("yyyyMMdd_HHmmss")}.txt"));
                if (fileInfo.Exists)
                {
                    fileInfo.Attributes = FileAttributes.Normal;
                    fileInfo.Delete();
                }
            }
            base.rollbackInternal();
        }
        protected override void commitInternal()
        {
            base.commitInternal();
        }
        protected override void prepareInternal()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo($@"D:\Teach\{this.AccountId}");
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            FileInfo fileInfo = new FileInfo(Path.Combine(directoryInfo.FullName, $"{this.LoginDateTime.ToString("yyyyMMdd_HHmmss")}.txt"));
            System.IO.File.AppendAllText(fileInfo.FullName, $@"ID:{this.AccountId}
Time:{this.LoginDateTime}
Machine Name:{Environment.MachineName}");
            base.prepareInternal();
        }
        private Guid AccountId
        {
            get
            {
                return this.getContextValue<Guid>();
                //return (Guid)base.getContextValue("accountId");
            }
        }
        private DateTime LoginDateTime
        {
            get
            {
                return this.getContextValue<DateTime>();
                //return (DateTime)base.getContextValue("loginDateTime");
            }
        }
        //private void setContextValue<T>(T value)
        //{
        //    base.setContextValue(value.GetType().FullName, value);
        //}
        //private T getContextValue<T>()
        //{
        //    return (T)base.getContextValue(typeof(T).FullName);
        //}
    }
}
