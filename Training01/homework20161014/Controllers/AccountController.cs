using homework20161014.Functions;
using homework20161014.Info;
using homework20161014.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace homework20161014.Controllers
{
    public class AccountController : ControllerBase
    {
        #region Login/Logout
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            using (LorenceFunction lorenceFunction = new LorenceFunction())
            {
                lorenceFunction.test(1);
                lorenceFunction.test(1);
            }
            LorenceFunction lorenceFunction2 = new LorenceFunction();
            lorenceFunction2.test(1);
            lorenceFunction2.test(1);
            lorenceFunction2.Dispose();
            lorenceFunction2.test(1);

            if (!base.IsAuthenticated)
            {
                if (this.CookieUserId.HasValue)
                {
                    base.CurrentLogonUser = base.AccountInfoListInternal
                           .FirstOrDefault(t => this.CookieUserId.Value == t.Id);
                    return this.RedirectToAction("Index", "Home");
                }
                //HttpCookie cookie = this.Request.Cookies["Auth"];
                //if (cookie != null)
                //{
                //    Guid id;
                //    if (Guid.TryParse(cookie.Value.ToString(), out id))
                //    {
                //        base.CurrentLogonUser = base.AccountInfoListInternal
                //            .FirstOrDefault(t => id == t.Id);
                //        return this.RedirectToAction("Index", "Home");
                //    }
                //}
            }
            //if (this.Request.Cookies["Cookie1"] == null)
            //{
            //    this.Response.Cookies["Cookie1"].Value = "123";
            //}
            return View(new LoginModel());
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            //HttpCookie cookie = this.Request.Cookies["Cookie1"];
            //if (cookie != null)
            //{
            //    cookie.Expires = DateTime.Now.AddDays(-1);
            //    this.Response.Cookies.Add(cookie);
            //}
            AccountInfo accountInfo = base.AccountInfoListInternal
                .FirstOrDefault(t => String.Compare(t.Account, loginModel.Account, true) == 0 && t.Password == loginModel.Password);
            if (accountInfo == null)
            {
                loginModel.Message = "查無帳號密碼";
                return this.View(loginModel);
            }
            //this.Response.Cookies["Auth"].Value = accountInfo.Id.ToString();
            //this.Response.Cookies["Auth"].Expires = DateTime.Now.AddYears(1);
            this.CookieUserId = accountInfo.Id;
            base.CurrentLogonUser = accountInfo;
            return this.RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            this.CookieUserId = null;
            //this.Response.Cookies["Auth"].Expires = DateTime.MinValue;
            base.CurrentLogonUser = null;
            return this.RedirectToAction("Login", "Account");
        }
        #endregion
        #region Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            base.AccountInfoListInternal.Add(new Info.AccountInfo()
            {
                Account = registerModel.Account,
                Password = registerModel.Password,
                Name = registerModel.Name,
                Id = Guid.NewGuid()
            });
            //Guid? id1 = Guid.NewGuid();
            //Nullable<Guid> id2 = Guid.NewGuid();
            return this.RedirectToAction("Login");
        }
        #endregion
        /// <summary>
        /// 設定或取得於客戶端瀏覽器認證 Cookie 中的 User Id
        /// </summary>
        private Guid? CookieUserId
        {
            set
            {
                if (!value.HasValue)
                {
                    this.Response.Cookies["Auth"].Expires = DateTime.MinValue;
                }
                else
                {
                    using (TEC.Core.Security.Cryption.SymmetricCryption symmetricCryption = new TEC.Core.Security.Cryption.SymmetricCryption(TEC.Core.Security.Cryption.AlgorithmName.AES,
                           System.Configuration.ConfigurationManager.AppSettings["CryptionKey"],
                           System.Configuration.ConfigurationManager.AppSettings["CryptionIV"]))
                    {
                        this.Response.Cookies["Auth"].Value = symmetricCryption.encrypt(value.Value.ToString());
                    }
                    this.Response.Cookies["Auth"].Expires = DateTime.Now.AddDays(1);
                }
            }
            get
            {
                HttpCookie cookie = this.Request.Cookies["Auth"];
                if (cookie != null)
                {
                    string idString;
                    try
                    {
                        using (TEC.Core.Security.Cryption.SymmetricCryption symmetricCryption = new TEC.Core.Security.Cryption.SymmetricCryption(TEC.Core.Security.Cryption.AlgorithmName.AES,
                               System.Configuration.ConfigurationManager.AppSettings["CryptionKey"],
                               System.Configuration.ConfigurationManager.AppSettings["CryptionIV"]))
                        {
                            idString = symmetricCryption.decrypt(cookie.Value.ToString());
                        }
                        //TEC.Core.Security.Cryption.SymmetricCryption symmetricCryption = new TEC.Core.Security.Cryption.SymmetricCryption(TEC.Core.Security.Cryption.AlgorithmName.AES,
                        //       System.Configuration.ConfigurationManager.AppSettings["CryptionKey"],
                        //       System.Configuration.ConfigurationManager.AppSettings["CryptionIV"]);
                        //    idString = symmetricCryption.decrypt(cookie.Value.ToString());
                        //symmetricCryption.Dispose();
                    }
                    catch
                    {
                        return null;
                    }
                    Guid id;
                    if (Guid.TryParse(idString, out id))
                    {
                        return id;
                    }
                }
                return null;
            }
        }
    }
}