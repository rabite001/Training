using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        #region V1
        ////private static void sleep3000()
        ////{
        ////    System.Threading.Thread.Sleep(3000);
        ////}

        ////private static void sleep3000(int i, string j)
        ////{
        ////    System.Threading.Thread.Sleep(3000);
        ////}
        //static void Main(string[] args)
        //{
        //    //Task.Run(new Action(sleep3000));
        //    //Task.Run(() =>
        //    //{
        //    //    System.Threading.Thread.Sleep(3000);
        //    //});
        //    //Action<int, string> action = new Action<int, string>((i, j) =>
        //    //{
        //    //});



        //    Bank bank = new Bank();
        //    Console.Write("請輸入來源: ");
        //    string sourcePerson = Console.ReadLine();
        //    List<Task> taskList = new List<Task>();
        //    Task<bool> sourcePersonCheckTask = Task.Run<bool>(() =>
        //    {
        //        return bank.checkPerson(sourcePerson);
        //    });
        //    taskList.Add(sourcePersonCheckTask);
        //    //if (!bank.checkPerson(sourcePerson))
        //    //{
        //    //    Console.Write("沒人");
        //    //    Console.ReadKey();
        //    //    return;
        //    //}
        //    Console.Write("請輸入目標: ");
        //    string targetPerson = Console.ReadLine();
        //    Task<bool> targetPersonCheckTask = Task.Run<bool>(() =>
        //    {
        //        return bank.checkPerson(targetPerson);
        //    });
        //    taskList.Add(targetPersonCheckTask);
        //    //if (!bank.checkPerson(targetPerson))
        //    //{
        //    //    Console.Write("沒人");
        //    //    Console.ReadKey();
        //    //    return;
        //    //}
        //    //bank.sum(1, 2, 3, 4);
        //    Console.Write("請輸入摳摳: ");
        //    decimal amount = Decimal.Parse(Console.ReadLine());
        //    //sourcePersonCheckTask.Wait();
        //    //targetPersonCheckTask.Wait();
        //    Task.WaitAll(taskList.ToArray());
        //    if(!sourcePersonCheckTask.Result || !targetPersonCheckTask.Result)
        //    {
        //        Console.Write("沒人");
        //        Console.ReadKey();
        //        return;
        //    }
        //    bank.transferAmount(sourcePerson, targetPerson, amount);
        //    Console.WriteLine("轉帳完成!");
        //    Console.ReadKey();
        //}
        #endregion
        #region V2
        //static void Main(string[] args)
        //{
        //    test();
        //    Console.ReadKey();
        //}
        //static async void test()
        //{
        //    Bank bank = new Bank();
        //    Console.Write("請輸入來源: ");
        //    string sourcePerson = Console.ReadLine();
        //    Task<bool> sourcePersonCheckTask = Task.Run<bool>(() =>
        //    {
        //        return bank.checkPerson(sourcePerson);
        //    });
        //    Console.Write("請輸入目標: ");
        //    string targetPerson = Console.ReadLine();
        //    Task<bool> targetPersonCheckTask = Task.Run<bool>(() =>
        //    {
        //        return bank.checkPerson(targetPerson);
        //    });
        //    Console.Write("請輸入摳摳: ");
        //    decimal amount = Decimal.Parse(Console.ReadLine());
        //    //bool hasSource = await sourcePersonCheckTask;
        //    //bool hasTarget = await targetPersonCheckTask;
        //    if (!await sourcePersonCheckTask || !await targetPersonCheckTask)
        //    {
        //        Console.Write("沒人");
        //        Console.ReadKey();
        //        return;
        //    }
        //    bank.transferAmount(sourcePerson, targetPerson, amount);
        //    Console.WriteLine("轉帳完成!");
        //    Console.ReadKey();
        //}
        #endregion
        #region V3
        static void Main(string[] args)
        {
            test();
            Console.ReadKey();
        }
        static async void test()
        {
            Bank bank = new Bank();
            Console.Write("請輸入來源: ");
            string sourcePerson = Console.ReadLine();
            Task<bool> sourcePersonCheckTask = bank.checkPersonAsync(sourcePerson);
            Console.Write("請輸入目標: ");
            string targetPerson = Console.ReadLine();
            Task<bool> targetPersonCheckTask = bank.checkPersonAsync(targetPerson);
            Console.Write("請輸入摳摳: ");
            decimal amount = Decimal.Parse(Console.ReadLine());
            if (!await sourcePersonCheckTask || !await targetPersonCheckTask)
            {
                Console.Write("沒人");
                Console.ReadKey();
                return;
            }
            bank.transferAmount(sourcePerson, targetPerson, amount);
            Console.WriteLine("轉帳完成!");
            Console.ReadKey();
        }
        #endregion
    }
}
