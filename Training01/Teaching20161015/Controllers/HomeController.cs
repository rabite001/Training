using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teaching20161015.Info;

namespace Teaching20161015.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }
        private void setSession<T>(string key, T value)
        {
            this.Session[key] = value;
        }
        private T getSession<T>(string key)
        {
            if (this.Session[key] == null)
            {
                return default(T);
            }
            return (T)this.Session[key];
        }
        public AccountInfo CurrentAccountInfo
        {
            set
            {
                this.setSession<AccountInfo>(nameof(CurrentAccountInfo), value);
                //this.Session["CurrentAccountInfo"] = value;
            }
            get
            {
                return this.getSession<AccountInfo>(nameof(CurrentAccountInfo));
                //if (this.Session["CurrentAccountInfo"] == null)
                //{
                //    return null;
                //}
                //return this.Session["CurrentAccountInfo"] as AccountInfo;
            }
        }
        public List<ProductInfo> CurrentAccountProduct
        {
            set
            {
                this.setSession(nameof(CurrentAccountProduct), value);
                //this.Session["CurrentAccountProduct"] = value;
            }
            get
            {
                return this.getSession<List<ProductInfo>>(nameof(CurrentAccountProduct));
                //if (this.Session["CurrentAccountProduct"] == null)
                //{
                //    return new List<ProductInfo>();
                //}
                //return this.Session["CurrentAccountProduct"] as List<ProductInfo>;
            }
        }
    }
}