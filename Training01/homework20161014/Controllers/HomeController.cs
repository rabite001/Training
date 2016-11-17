using homework20161014.Info;
using homework20161014.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace homework20161014.Controllers
{
    public class HomeController : ControllerBase
    {
        // GET: Home
        public ActionResult Index()
        {
            if (!base.IsAuthenticated)
            {
                return this.RedirectToAction("Login", "Account");
            }
            AccountInfo accountInfo = base.CurrentLogonUser;
            return View(new IndexModel()
            {
                DisplayName = accountInfo.Name
            });
        }
    }
}