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
            SchedulerUIData schedulerUIData = new SchedulerUIData(TimerManagerConfig.TimerManager, HearConfig.Hear);
            schedulerUIData.initial();
            return View(new IndexModel()
            {
                TimerManager = TimerManagerConfig.TimerManager
            });
        }
        [HttpPost]
        public ActionResult Index(IndexModel indexModel)
        {
          
            return View(indexModel);
        }
    }
}