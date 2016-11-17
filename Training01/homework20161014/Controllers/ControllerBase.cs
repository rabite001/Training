using homework20161014.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace homework20161014.Controllers
{
    public abstract class ControllerBase : Controller
    {
        static ControllerBase()
        {
            ControllerBase.AccountInfoList = new List<AccountInfo>()
            {
                new AccountInfo()
                {
                   Account="a",
                   Id=new Guid("B7031593-DC76-4CCC-A96A-C15BAF8AB764"),
                   Name="a",
                   Password="a"
                },
                new AccountInfo()
                {
                   Account="b",
                   Id=new Guid("B7031593-DC76-4CCC-A96A-C15BAF8AB765"),
                   Name="b",
                   Password="b"
                }
            };
        }
        /// <summary>
        /// 取得系統中儲存的所有帳戶資料清單
        /// </summary>
        private static List<AccountInfo> AccountInfoList { set; get; }
        /// <summary>
        /// 取得系統中儲存的所有帳戶資料清單
        /// </summary>
        protected List<AccountInfo> AccountInfoListInternal
        {
            get
            {
                return ControllerBase.AccountInfoList;
            }
        }
        /// <summary>
        /// 取得目前瀏覽的使用者是否已經登入
        /// </summary>
        public bool IsAuthenticated
        {
            get
            {
                return this.CurrentLogonUser != null;
            }
        }
        /// <summary>
        /// 設定或取得目前登入的使用者，若無登入則傳回<c>null</c>參考
        /// </summary>
        public AccountInfo CurrentLogonUser
        {
            protected set
            {
                this.Session["CurrentLogonUser"] = value;
            }
            get
            {
                return this.Session["CurrentLogonUser"] as AccountInfo;
            }
        }
    }
}