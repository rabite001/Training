using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Teach.Core;
using Teach.Core.Infos;
using Teach.Web.Models.Home;
using TEC.Core.Text.RandomText;

namespace Teach.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            new BankUIData().testAutoMapper();
            return View(new IndexModel()
            {
                Account = "Antony",
                Password = "Antony"
            });
        }
        [HttpPost]
        public ActionResult Index(IndexModel indexModel)
        {
            BankUIData bankUIData = new BankUIData();
            BankUserInfo bankUserInfo = bankUIData.getBankUserInfos(indexModel.Account);
            if (bankUserInfo != null)
            {
                bankUIData.loginAccount(bankUserInfo.BankUserId);
            }
            //            BankUserInfo bankUserInfo = bankUIData.getBankUserInfos(indexModel.Account);
            //            if (bankUserInfo != null)
            //            {
            //                using (TransactionScope transactionScope = new TransactionScope())
            //                {
            //                    DirectoryInfo directoryInfo = new DirectoryInfo($@"D:\Teach\{bankUserInfo.BankUserId}");
            //                    if (!directoryInfo.Exists)
            //                    {
            //                        directoryInfo.Create();
            //                    }
            //                    FileInfo fileInfo = new FileInfo(Path.Combine(directoryInfo.FullName, $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt"));
            //                    System.IO.File.AppendAllText(fileInfo.FullName, $@"ID:{bankUserInfo.BankUserId}
            //Time:{DateTime.Now}
            //Machine Name:{Environment.MachineName}");
            //                    transactionScope.Complete();
            //                }


            //                bankUIData.setLastLoginDate(bankUserInfo.BankUserId, DateTime.Now);
            //                //FileInfo fileInfo = new FileInfo($@"D:\Teach\{bankUserInfo.BankUserId}\{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt");
            //                //                System.IO.File.AppendAllText($@"D:\Teach\{bankUserInfo.BankUserId}\{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt",
            //                //                    $@"ID:{bankUserInfo.BankUserId}
            //                //Time:{DateTime.Now}
            //                //Machine Name:{Environment.MachineName}");
            //            }

            return View(indexModel);
        }
    }
}