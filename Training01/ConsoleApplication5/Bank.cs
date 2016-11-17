using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class Bank
    {
        #region V2
        //public bool checkPerson(string person)
        //{
        //    System.Threading.Thread.Sleep(5000);
        //    return true;
        //}

        //public int sum(params int[] value)
        //{
        //    return value.Sum();
        //}
        #endregion
        public async Task<bool> checkPersonAsync(string person)
        {
            #region Bad
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Reset();
            //stopwatch.Start();
            ////By CPU
            //Guid getActivityId = Guid.NewGuid();
            ////By Network
            //System.Threading.Thread.Sleep(5000);
            ////By CPU
            //int index = 0;
            //while (index < 1000000)
            //{
            //    index++;
            //}
            //stopwatch.Stop();
            //TimeSpan elapseTimeSpan = stopwatch.Elapsed;
            //return Task.FromResult(true);
            #endregion
            #region Good
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            Task<bool> checkPersonByNetworkTask =
                Task.Run<bool>(() =>
                {
                    //By Network
                    System.Threading.Thread.Sleep(5000);
                    return true;
                });
            //By CPU
            Guid getActivityId = Guid.NewGuid();
            //By CPU
            int index = 0;
            while (index < 1000000)
            {
                index++;
            }
            bool checkByNetwork = await checkPersonByNetworkTask;
            stopwatch.Stop();
            TimeSpan elapseTimeSpan = stopwatch.Elapsed;
            if (checkByNetwork && index > 90000)
            {
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }
        public void transferAmount(string sourcePerson, string targetPerson, decimal amount)
        {

        }
    }
}
